﻿using Grpc.Net.Client;
using GrpcServicerRPC;
using System;
using System.Collections.Generic;
using System.Text;

namespace GrpcClientWindowsForms.Controllers
{
    class ConnectController
    {
        // Channel e client usados para verificar se é possível realizar uma conexão com o endereço enviado
        public static GrpcChannel TestChannel { get; private set; }
        public static Greeter.GreeterClient ConnectClient { get; private set; }

        public ConnectController()
        {
            Program.ConnectView.ConnectRequest += ConnectToServer;
            Program.ConnectView.RestartConnectionRequest += EndConnection;
        }

        // Método usado para criar uma conexão com o servidor e testar a conexão
        private async void ConnectToServer(string address)
        {
            // Se a conexão já tiver sido estabelecida, é retornado uma mensagem de sucesso para a view
            if (TestChannel != null || ConnectClient != null)
            {
                Program.ConnectView.SuccessfulConnection();
                return;
            }

            // Estabelece uma conexão com um channel de test com o servidor com o address especificado com o utilizador
            // No caso de não ter sido especificado endereço IP, retorna uma mensagem de erro para a view
            try
            {
                TestChannel = GrpcChannel.ForAddress("https://" + address + ":5001");
                ConnectClient = new Greeter.GreeterClient(TestChannel);
            }
            // No caso de o endereço especificado ter um formato errado
            catch (UriFormatException)
            {
                EstablishingConnectionFailed();
                Program.ConnectView.ShowError("Invalid address!");
                return;
            }
            // No caso de não ter sido especificado um endereço
            catch (ArgumentNullException)
            {
                EstablishingConnectionFailed();
                Program.ConnectView.ShowError("Invalid address!");
                return;
            }

            // Após ter sido criada a conexão, é enviado um pedido Hello para verificar se conexão foi feita com sucesso
            try
            {
                var helloRequest = new HelloRequest
                {
                    Name = "Client"
                };

                var reply = await ConnectClient.SayHelloAsync(helloRequest);
            }
            // No caso de a conexão falhar é apanhada a exceção respetiva, e é apresentada uma mensagem de erro na view
            catch (Grpc.Core.RpcException)
            {
                EstablishingConnectionFailed();
                Program.ConnectView.ShowError("Connection failed!");
                return;
            }

            
            // No caso de a conexão de teste suceder, é criado um channel na class Program.cs, para ser usado por todos os 
            // os clients GRPC (AuthClient, ConnectClient e PlayClient) usados para comunicar com o servidor
            Program.SetConnectionChannel("https://" + address + ":5001");
            ConnectClient = new Greeter.GreeterClient(Program.ConnectionChannel);
            TestChannel = null;

            // É avisado o utilizador, através da view, que a conexão foi feita com sucesso
            Program.ConnectView.SuccessfulConnection();
        }

        // Usado para repor o channel e clients GRPC usados por todos os controllers
        private void EndConnection()
        {
            Program.PlayController.EndConnection();
            Program.AuthController.EndConnection();
            ConnectClient = null;
            Program.ResetConnection();
            Program.ConnectView.RestartView();
        }

        // Método que é chamado sempre que ocorre alguma falha de conexão por qualquer um dos controllers do client
        public void ConnectionError()
        {
            EndConnection();
            Program.ConnectView.Show();
            Program.ConnectView.ShowError("Connection failed!");
        }

        // Método que é chamado sempre que o utilizador autenticado com o cliente não existir no servidor
        public void UserNotFound()
        {
            EndConnection();
            Program.ConnectView.ShowError("User not found!");
        }

        // No caso da conexão inicial falhar, é usado este método para repor o canal e cliente usados para o teste de conexão
        public void EstablishingConnectionFailed()
        {
            TestChannel = null;
            ConnectClient = null;
        }
    }
}
