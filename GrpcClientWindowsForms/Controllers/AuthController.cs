using Grpc.Net.Client;
using GrpcServerRPS;
using System;
using System.Collections.Generic;
using System.Text;

namespace GrpcClientWindowsForms.Controllers
{
    class AuthController
    {
        // Channel e client usados para autenticação
        public static GrpcChannel AuthChannel { get; private set; }
        public static User.UserClient AuthClient { get; private set; }

        public AuthController()
        {
            Program.PlayView.GRPCStartRequest += StartGRPCConnection;
        }

        private async void StartGRPCConnection()
        {
            // No caso de a conexão já ter sido inicializada, retorna uma mensagem de erro para a view
            if (AuthChannel != null || AuthClient != null)
            {
                Program.AuthView.ShowError("Connection already established!");
                return;
            }
        }
    }
}
