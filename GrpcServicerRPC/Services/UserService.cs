using Grpc.Core;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.Common;
using GrpcServerRPS.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Security.Cryptography;
using System.Text;

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

        public override Task<UserLoginModel> Login(UserLoginLookupModel request, ServerCallContext context)
        {
            UserLoginModel output = new UserLoginModel();

            // Transformação de todos os carateres do nome para upper case
            string username = request.Username.ToUpper();

            // Encriptação da password
            SHA512 sha512 = SHA512Managed.Create();
            byte[] bytes = sha512.ComputeHash(Encoding.UTF8.GetBytes(request.Password));
            string password = Convert.ToBase64String(bytes);

            // Fazer as verificações necessárias na base de dados.
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
                    // Exceção que é lançada sempre que é quebrado o constraint UNIQUE do ID de sessão, no caso do ID de sessão gerada já existir
                    catch (DbUpdateException e) when (e.InnerException is SqlException sqlEx && (sqlEx.Number == 2627 || sqlEx.Number == 2601))
                    {
                        success = false;
                    }
                }
                while (success == false) ;
                
                output.Valid = true;
                output.SessionID = u.SessionID;
            }
                
            return Task.FromResult(output);

        }

        public override Task<UserRegistModel> Regist(UserRegistLookupModel request, ServerCallContext context)
        {
            UserRegistModel output = new UserRegistModel();

            // Transformação dos carateres do email e username para upper case
            string email = request.Email.ToUpper();
            string username = request.Username.ToUpper();

            // Fazer as verificações necessárias na base de dados.
            Models.User u1 = new Models.User(), u2 = new Models.User();
            u1 = _context.User.FirstOrDefault(u => u.Username == username);
            u2 = _context.User.FirstOrDefault(u => u.Email == email);

            if (u1 != null)
            {
                if (u2 == null)
                    output.Valid = -3; // username e email inválidos
                else
                    output.Valid = -1; // Apenas username inválido
            }
            else if (u2 != null)
            {
                output.Valid = -2; // Apenas email inválido
            }
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

                // verifica e garante que a BD existe
                _context.Database.EnsureCreated();

                // Inserrir credenciais
                _context.User.Add(u);
                _context.SaveChanges();
                
                output.Valid = 1; // Todos válidos
            }
                

            return Task.FromResult(output);

        }
    }
}
