using Grpc.Core;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data.Common;
using GrpcServerRPS.Data;

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

            // Fazer as verificações necessárias na base de dados.

            Models.User u = _context.User.FirstOrDefault(u => u.Username == request.Username && u.Password == request.Password);

            if (u == null)
            { 
                // Se não existir nenhuma entrada na base de dados com o username e password igual, então o output tem de ser autenticação inválida.
                output.Valid = false;
                output.SessionID = null;
            }
            else
            {
                // Sempre que um utilizador se autentica, é gerado sempre um novo ID de sessão
                u.GenerateSessionID();
                _context.SaveChanges();

                output.Valid = true;
                output.SessionID = u.SessionID;
            }
                

            return Task.FromResult(output);

        }

        public override Task<UserRegistModel> Regist(UserRegistLookupModel request, ServerCallContext context)
        {
            UserRegistModel output = new UserRegistModel();

            // Fazer as verificações necessárias na base de dados.
            Models.User u1 = new Models.User(), u2 = new Models.User();
            u1 = _context.User.FirstOrDefault(u => u.Username == request.Username);
            u2 = _context.User.FirstOrDefault(u => u.Email == request.Email);

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
                Models.User u = new Models.User
                {
                    Username = request.Username,
                    Email = request.Email,
                    Password = request.Password
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
