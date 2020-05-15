using Grpc.Net.Client;
using GrpcServerRPS;
using System;
using System.Collections.Generic;
using System.Text;

namespace GrpcClientWindowsForms.Controllers
{
    class PlayController
    {
        // Channel e Client usados para jogar
        public static GrpcChannel PlayChannel { get; private set; }
        public static Game.GameClient PlayClient { get; private set; }


        public PlayController()
        {
            Program.PlayView.GRPCStartRequest += StartGRPCConnection;
            Program.PlayView.PlayRequest += Play;
        }

        // Método usado para criar uma conexão GRPC com o servidor
        private async void StartGRPCConnection()
        {
            // No caso de a conexão já ter sido inicializada, retorna uma mensagem de erro para a view
            if (PlayChannel != null || PlayClient != null)
            {
                Program.PlayView.ShowError("Connection already established!");
                return;
            }

            // TODO: Receber endereço IP por windows forms
            // Estabelece uma conexão com o servidor com o address especificado com o utilizador
            // No caso de não ter sido especificado endereço IP, retorna uma mensagem de erro para a view
            try
            {
                PlayChannel = GrpcChannel.ForAddress("https://localhost:5001");
                PlayClient = new Game.GameClient(PlayChannel);
            }
            // No caso de o endereço especificado ter um formato errado
            catch (UriFormatException)
            {
                Program.PlayView.ShowError("No address set to connect!");
                return;
            }
            // No caso de não ter sido especificado um endereço
            catch (ArgumentNullException)
            {
                Program.PlayView.ShowError("No address set to connect!");
                return;
            }

            // Após ter sido criada a conexão, é enviada um pedido para obter as estatísticas do jogador, que é usada tanto para
            // testar a conexão e obter as estatísticas do jogador para serem apresentadas na view
            try
            {
                var statsRequest = new StatsLookupModel
                {
                    UserId = 1
                };

                var stats = await PlayClient.StatsAsync(statsRequest);
            }
            // No caso de a conexão falhar é apanhada a exceção respetiva, e é apresentada uma mensagem de erro na view
            catch (Grpc.Core.RpcException)
            {
                Program.PlayView.ShowError("Error establishing connection!");
                return;
            }

            // TODO: Carregar stats para a view
            // Se a conexão for feita com sucesso, são carregadas as estatísticas para a view, e são ativados os butões para jogar
            Program.PlayView.UpdateButtonsToEnabled();
            return;
        }

        private async void Play(int play)
        {
            // No caso de conexão ainda não ter sido feita
            if (PlayChannel == null || PlayClient == null)
            {
                Program.PlayView.ShowError("Connection already established!");
                return;
            }

            try
            {
                var outcome = await PlayClient.PlayAsync(
                    new PlayLookupModel
                    {
                        UserId = 1,
                        Play = play
                    }
                );

                Program.PlayView.ShowGameOutcome(outcome.Result, outcome.ServerPlay);
            }
            // No caso de a conexão falhar é apanhada a exceção respetiva, e é apresentada uma mensagem de erro na view
            catch (Grpc.Core.RpcException)
            {
                Program.PlayView.ShowError("Error establishing connection!");
            }
        }
    }
}
