using GrpcServerRPS.Data;
using Grpc.Core;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;


namespace GrpcServerRPS.Services
{
    public class UserService : User.UserBase
    {
        private readonly ILogger<UserService> logger;
        private readonly RPSGameDbContext _context;

        public UserService(ILogger<UserService> logger, RPSGameDbContext context)
        {
            this.logger = logger;
            _context = context;
        }


        /**
         * Login de utilizadores já existentes. Devem ser recebidos o username e password. 
         * Sempre que o login é feito com sucesso, é enviado um ID de sessão único para o cliente
         * que é usado por este para se identificar sempre que envia algum pedido.
         */
        public override Task<UserLoginModel> Login(UserLoginLookupModel request, ServerCallContext context)
        {
            UserLoginModel output = new UserLoginModel();

            // Transformação de todos os carateres do nome para upper case
            string username = request.Username.ToUpper();

            // Encriptação da password
            SHA512 sha512 = SHA512Managed.Create();
            byte[] bytes = sha512.ComputeHash(Encoding.UTF8.GetBytes(request.Password));
            string password = Convert.ToBase64String(bytes);

            // Verifica-se se o utilizador existe na base de dados e se a password está correta
            Models.User u = _context.User.FirstOrDefault(u => u.Username == request.Username && u.Password == password);

            if (u == null)
            { 
                // Se não existir nenhuma entrada na base de dados com o username e password igual, então o output tem de ser autenticação inválida.
                output.Valid = false;
                output.SessionID = "";
            }
            else
            {
                // Sempre que um utilizador se autentica, é gerado sempre um novo ID de sessão.
                // É usado um ciclo para, no caso do ID de sessão gerado já existir, poder gerar um novo
                bool success;
                do
                {
                    success = true;
                    try
                    {
                        u.GenerateSessionID();
                        _context.SaveChanges();
                    }
                    // Exceção que é lançada sempre que é quebrado o constraint UNIQUE do ID de sessão, no caso do ID de sessão gerado já existir
                    catch (DbUpdateException e) when (e.InnerException is SqlException sqlEx && (sqlEx.Number == 2627 || sqlEx.Number == 2601))
                    {
                        success = false;
                    }
                }
                while (success == false);
                
                // Se o login for feito com sucesso, é enviada uma confirmação ao cliente, com o seu ID de sessão
                output.Valid = true;
                output.SessionID = u.SessionID;
            }
                
            return Task.FromResult(output);

        }


        /**
         * Registo de novos utilizadores. Devem ser recebidos o username, email e password para criar o novo utilizador.
         * Quando é guardado um novo utilizador na base de dados, o email e username são transformados em upper case, e
         * a password é encriptada.
         */
        public override Task<UserRegistModel> Regist(UserRegistLookupModel request, ServerCallContext context)
        {
            UserRegistModel output = new UserRegistModel();

            // Transformação dos carateres do email e username para upper case
            string email = request.Email.ToUpper();
            string username = request.Username.ToUpper();

            // Verificações se um outro utilizador tem o mesmo email e/ou o mesmo username
            Models.User u1 = new Models.User(), u2 = new Models.User();
            u1 = _context.User.FirstOrDefault(u => u.Username == username);
            u2 = _context.User.FirstOrDefault(u => u.Email == email);

            // Um utilizador tem o mesmo username
            if (u1 != null)
            {
                if (u2 == null)
                    output.Valid = -3; // Um utilizador tem apenas o mesmo username
                else
                    output.Valid = -1; // Um utilizador tem o mesmo username e email
            }
            // Um utilizador tem o mesmo email
            else if (u2 != null)
            {
                output.Valid = -2; // Um utilizador tem apenas o mesmo email
            }
            // Nenhum utilizador tem o mesmo username e/ou email
            else
            {
                // Encriptação da password
                SHA512 sha512 = SHA512Managed.Create();
                byte[] bytes = sha512.ComputeHash(Encoding.UTF8.GetBytes(request.Password));
                string password = Convert.ToBase64String(bytes);

                Models.User u = new Models.User
                {
                    Username = username,
                    Email = email,
                    Password = password
                };

                // Verifica e garante que a BD existe
                _context.Database.EnsureCreated();

                // Guarda-se o novo utilizador na base de dados
                _context.User.Add(u);
                _context.SaveChanges();
                
                // Envia-se uma mensagem uma mensagem de confirmação de registo ao cliente
                output.Valid = 1; 
            }
                
            return Task.FromResult(output);
        }
    }
}