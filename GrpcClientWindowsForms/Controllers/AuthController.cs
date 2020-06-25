using Grpc.Net.Client;
using GrpcServerRPS;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace GrpcClientWindowsForms.Controllers
{
    class AuthController
    {
        // Channel e client usados para autenticação
        public static User.UserClient AuthClient { get; private set; }

        public AuthController()
        {
            Program.AuthView.GRPCStartRequest += StartGRPCConnection;
            Program.LoginView.LoginRequest += LoginView_LoginRequest;
            Program.RegisterView.RegisterRequest += Register;
            Program.AuthView.GRPCGetGames += AuthView_GRPCGetGames;
        }

        private void AuthView_GRPCGetGames()
        {
            UserGetGamesBySessionIdLookupModel req = new UserGetGamesBySessionIdLookupModel
            {
                SessionID = Program.AuthUser.SessionID
            };

            UserGetGamesBySessionIdModel outcome = AuthClient.GetGamesBySessionId(req);

            if (outcome.Games != -1)
            {
                Program.AuthView.SetGames(outcome.Games);
            }
        }

        // Método usado para enviar um pedido para o servidor GRPC com o intuito de autenticar um utilizador
        private void LoginView_LoginRequest(string username, string password)
        {
            // Se o client estiver a null, significa que ocorreu algum erro, e é finalizada a conexão
            if (AuthClient == null)
            {
                Program.ConnectController.ConnectionError();
                return;
            }

            // Tenta autenticar o utilizador
            try
            {
                UserLoginLookupModel logReq = new UserLoginLookupModel
                {
                    Username = username,
                    Password = password
                };

                UserLoginModel outcome = AuthClient.Login(logReq);

                // No caso de autenticação falhar, é enviada a mensagem de erro ao utilizador
                if (outcome.Valid == false)
                {
                    Program.LoginView.ShowError("User or/and password do not match any user!");
                    return;
                }

                // Se a autenticação for feita com sucesso, é guardado o ID de sessão do Username do utilizador no client
                Program.SetAuthenticatedUser(outcome.SessionID, username);
            }
            // No caso de a conexão com o servidor falhar, é chamado o método de ConnectController para finalizar todas as conexões
            catch (Grpc.Core.RpcException)
            {
                Program.ConnectController.ConnectionError();
                return;
            }

            // O utilizador é avisado que a autenticação foi feita com sucesso
            Program.LoginView.SuccessfulLogin();
        }

        // Método para inicializar o client GRPC usado para a autenticação
        private void StartGRPCConnection()
        {
            // No caso de a conexão já ter sido inicializada, não necessita de fazer mais nenhuma operação
            if (AuthClient != null)
            {
                return;
            }

            // É criado um client de autenticação
            AuthClient = new User.UserClient(Program.ConnectionChannel); 
        }

        // Método usado para enviar um pedido para o servidor GRPC com o intuito de registar um utilizador
        private void Register(string username, string email, string password, string passwordConfirmation)
        {
            // Se o client estiver a null, significa que ocorreu algum erro, e é finalizada a conexão
            if (AuthClient == null)
            {
                Program.ConnectController.ConnectionError();
                return;
            }

            // Verifica se as passwords inseridas são idênticas
            if (password != passwordConfirmation)
            {
                Program.RegisterView.ShowError("The passwords don't match!");
            }

            // Tenta registar o utilizador
            int validRegistration;
            try
            {
                UserRegistLookupModel registerRequest = new UserRegistLookupModel
                {
                    Username = username,
                    Email = email,
                    Password = password
                };

                var outcome = AuthClient.Regist(registerRequest);
                validRegistration = outcome.Valid;
            }
            // No caso de a conexão com o servidor falhar, é chamado o método de ConnectController para finalizar todas as conexões
            catch (Grpc.Core.RpcException)
            {
                Program.ConnectController.ConnectionError();
                return;
            }

            switch (validRegistration)
            {
                // Registo feito com sucesso
                case 1:
                    Program.RegisterView.SuccessfulRegistration();
                    return;
                // Já existe uma conta registada com o mesmo username
                case -1:
                    Program.RegisterView.ShowError("The username is already used!");
                    return;
                // Já existe uma conta registada com o mesmo email
                case -2:
                    Program.RegisterView.ShowError("The email is already used!");
                    return;
                // Já existe uma conta registada com o mesmo username e mail
                case -3:
                    Program.RegisterView.ShowError("The username and email are already taken!");
                    return;
                // Erro desconhecido
                default:
                    Program.RegisterView.ShowError("Unknown error!");
                    return;
            }     
        }



        // Se for necessário finalizar a conexão, devido a algum erro ou por opção do utilizador, é apagado as informações do utilizador que
        // está autenticado e é reposto o client usado para a autenticação
        public void EndConnection()
        {
            Program.ResetAuthenticatedUser();
            Program.AuthView.ResetView();
            AuthClient = null;
        }
    }
}
