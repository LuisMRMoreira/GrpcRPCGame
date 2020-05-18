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
            Program.LoginView.LoginRequest += Login;
            Program.RegisterView.RegisterRequest += Register;
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
        private async void Register(string username, string email, string password, string passwordConfirmation)
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
                Program.RegisterView.ShowError(-1);
            }

            // Tenta registar o utilizador
            try
            {
                UserRegistLookupModel registerRequest = new UserRegistLookupModel
                {
                    Username = username,
                    Email = email,
                    Password = password
                };

                var outcome = await AuthClient.RegistAsync(registerRequest);

                // No caso de o registo falhar, é necessário verificar porquê falhou, e enviar o código de erro respetivo a view
                if (outcome.Valid == false)
                {
                    switch (outcome.WihchInvalid)
                    {
                        // Já existe uma conta registada com o mesmo username
                        case 1:
                            Program.RegisterView.ShowError(-2);
                            return;
                        // Já existe uma conta registada com o mesmo email
                        case 2:
                            Program.RegisterView.ShowError(-3);
                            return;
                        // Já existe uma conta registada com o mesmo username e mail
                        case 3:
                            Program.RegisterView.ShowError(-4);
                            return;
                        // Erro desconhecido
                        default:
                            Program.RegisterView.ShowError(-99);
                            return;
                    }
                }
            }
            // No caso de a conexão com o servidor falhar, é chamado o método de ConnectController para finalizar todas as conexões
            catch (Grpc.Core.RpcException)
            {
                Program.ConnectController.ConnectionError();
                return;
            }

            // Após o registo ser feito com sucesso, é enviada uma mensagem de sucesso para a view de autenticação
            Program.RegisterView.SuccessfulRegistration();
        }

        // Método usado para enviar um pedido para o servidor GRPC com o intuito de autenticar um utilizador
        private async void Login(string username, string password)
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
                UserLoginLookupModel loginRequest = new UserLoginLookupModel
                {
                    Username = username,
                    Password = password
                };

                var outcome = await AuthClient.LoginAsync(loginRequest);

                // No caso de autenticação falhar, é enviada a mensagem de erro ao utilizador
                if (outcome.Valid == false)
                {
                    return;
                }

                // Se a autenticação for feita com sucesso, é guardado o ID e o Username do utilizador no client
                Program.SetAuthenticatedUser(outcome.UserId, username);
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

        // Se for necessário finalizar a conexão, devido a algum erro ou por opção do utilizador, é apagar as informações do utilizador que
        // está autenticado e é reposto o client usado para a autenticação
        public void EndConnection()
        {
            Program.ResetAuthenticatedUser();
            AuthClient = null;
        }
    }
}
