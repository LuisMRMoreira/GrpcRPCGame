using Grpc.Net.Client;
using GrpcClientWindowsForms.Views;
using GrpcServerRPS;
using System;
using System.Collections.Generic;
using System.Text;

namespace GrpcClientWindowsForms.Controllers
{
    class PlayController
    {
        // Cliente gRPC responsável por tratar das operações de jogar e estatísticas
        public static Game.GameClient PlayClient { get; private set; }


        public PlayController()
        {
            Program.PlayView.GRPCStartRequest += StartGRPCConnection;
            Program.PlayView.PlayRequest += Play;
        }

        // Método usado para criar uma conexão GRPC com o servidor
        private async void StartGRPCConnection()
        {
            // Estabelece uma conexão com o servidor com o address especificado com o utilizador
            // No caso de não ter sido especificado endereço IP, retorna uma mensagem de erro para a view
            StatsModel stats;
            try
            {
                PlayClient = new Game.GameClient(Program.ConnectionChannel);

                // Após ter sido criada a conexão, é enviada um pedido para obter as estatísticas do jogador, que é usada tanto para
                // testar a conexão e obter as estatísticas do jogador para serem apresentadas na view
                var statsRequest = new StatsLookupModel
                {
                    SessionId = Program.AuthUser.SessionID
                };

                stats = await PlayClient.StatsAsync(statsRequest);
            }
            // No caso de a conexão falhar é apanhada a exceção respetiva, e é apresentada uma mensagem de erro na view
            catch (Grpc.Core.RpcException)
            {
                Program.ConnectController.ConnectionError();
                return;
            }


            // Se o número de jogados for -1 significa que o utilizador com o ID de sessão não existe no servidor
            if (stats.GamesPlayed == -1)
            {
                Program.ConnectController.UserNotFound();
                return;
            }


            // Se a conexão for feita com sucesso, são carregadas as estatísticas para a view, e são ativados os butões para jogar
            Program.PlayView.ShowStats(stats.GamesPlayed, stats.Wins, stats.Draws, stats.Losts);            
            Program.PlayView.EnablePlayButtons();
            return;
        }

        // Método usado para realizar uma jogada
        private async void Play(int play)
        {
            // Se o client estiver a null, significa que ocorreu algum erro, e é finalizada a conexão
            if (PlayClient == null)
            {
                Program.ConnectController.ConnectionError();
                return;
            }

            try
            {
                PlayLookupModel playRequest = new PlayLookupModel
                {
                    SessionId = Program.AuthUser.SessionID,
                    Play = play
                };

                var outcome = await PlayClient.PlayAsync(playRequest);

                Program.PlayView.ShowGameOutcome(outcome.Result, outcome.ServerPlay);
            }
            // No caso de a conexão falhar é apanhada a exceção respetiva, e é apresentada uma mensagem de erro na view
            catch (Grpc.Core.RpcException)
            {
                Program.PlayView.ResetAndHide();
                Program.ConnectController.ConnectionError();
                return;
            }


            // Após ter sido feito o pedido para jogar, é feito o pedido para obter os stats do jogador, para serem mostrados
            // a medida que o utilizador vai jogando
            try
            {
                StatsLookupModel statsRequest = new StatsLookupModel
                {
                    SessionId = Program.AuthUser.SessionID
                };

                var outcome = await PlayClient.StatsAsync(statsRequest);

                Program.PlayView.ShowStats(outcome.GamesPlayed, outcome.Wins, outcome.Draws, outcome.Losts);
            }
            // No caso de a conexão falhar
            catch (Grpc.Core.RpcException)
            {
                Program.PlayView.ResetAndHide();
                Program.ConnectController.ConnectionError();
                return;
            }
        }

        public void EndConnection()
        {
            PlayClient = null;
        }
    }
}
