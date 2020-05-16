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
            Program.PlayView.GRPCStartRequest += StartGRPCConnection;
        }

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
                        case 1:
                            Program.RegisterView.ShowError(-2);
                            return;
                        case 2:
                            Program.RegisterView.ShowError(-3);
                            return;
                        case 3:
                            Program.RegisterView.ShowError(-4);
                            return;
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

        public void EndConnection()
        {
            AuthClient = null;
        }
    }
}
