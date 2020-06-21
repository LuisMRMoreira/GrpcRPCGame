using Grpc.Core;
using GrpcServerRPS.APICommunication;
using GrpcServerRPS.Data;
using GrpcServerRPS.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrpcServerRPS.Services
{
    public class GameService : Game.GameBase
    {
        private readonly ILogger<GameService> logger;
        private readonly RPSGameDbContext _context;

        public GameService(ILogger<GameService> logger, RPSGameDbContext context)
        {
            this.logger = logger;
            _context = context;
        }

        public override Task<PlayModel> Play(PlayLookupModel request, ServerCallContext context)
        {
            PlayModel output = new PlayModel();

            // Obtemos o utilizador da base de dados com o ID de sessão, para depois obtermos o seu ID, se não existir é retornado o código
            // de erro para o cliente
            Models.User user = _context.User.FirstOrDefault(u => u.SessionID == request.SessionId);
            if (user == null)
            {
                output.Result = -1;
                return Task.FromResult(output);
            }

            History h = _context.History.Include(i => i.User).FirstOrDefault(u => u.userId == user.Id);
            if (h == null) // No caso do utilizador nunca ter jogado, criamos uma linha na tabela de estatísticas para este
            {
                _context.Database.EnsureCreated();


                h = new History
                {
                    userId = user.Id,
                    User = user
                };

                _context.History.Add(h);
                _context.SaveChanges();

            }

            // É gerada a jogada do servidor
            Random rnd = new Random();
            int serverPlay = rnd.Next(1, 4);


            switch (request.Play)
            {
                case 1: // Pedra

                    switch (serverPlay)
                    {
                        case 1: // Pedra
                            output.ServerPlay = "Rock";
                            output.Result = 0; // Empate
                            h.draw++;
                            break;
                        case 2: // Papel
                            output.ServerPlay = "Paper";
                            output.Result = 2; // Servidor venceu
                            h.lost++;
                            break;
                        case 3: // Tesoura
                            output.ServerPlay = "Scissors";
                            output.Result = 1; // Utilizador venceu
                            h.win++;
                            break;
                        default:
                            break;
                    }


                    break;
                case 2: // Papel
                    switch (serverPlay)
                    {
                        case 1: // Pedra
                            output.ServerPlay = "Rock";
                            output.Result = 1; // Utilizador venceu
                            h.win++;
                            break;
                        case 2: // Papel
                            output.ServerPlay = "Paper";
                            output.Result = 0; // Empate
                            h.draw++;
                            break;
                        case 3: // Tesoura
                            output.ServerPlay = "Scissors";
                            output.Result = 2; // Servidor venceu
                            h.lost++;
                            break;
                        default:
                            break;
                    }
                    break;
                case 3: // Tesoura
                    switch (serverPlay)
                    {
                        case 1: // Pedra
                            output.ServerPlay = "Rock";
                            output.Result = 2; // Servidor venceu
                            h.lost++;
                            break;
                        case 2: // Papel
                            output.ServerPlay = "Paper";
                            output.Result = 1; // Utilizador venceu
                            h.win++;
                            break;
                        case 3: // Tesoura
                            output.ServerPlay = "Scissors";
                            output.Result = 0; // Empate
                            h.draw++;
                            break;
                        default:
                            break;
                    }
                    break;

                default:
                    break;
            }

            h.Games++;

            _context.SaveChanges();


            return Task.FromResult(output);
        }

        public override Task<StatsModel> Stats(StatsLookupModel request, ServerCallContext context)
        {
            StatsModel output = new StatsModel();

            // Obtemos o utilizador da base de dados com o ID de sessão, para depois obtermos o seu ID, se não existir é retornado o código
            // de erro para o cliente
            Models.User user = _context.User.FirstOrDefault(u => u.SessionID == request.SessionId);
            if (user == null)
            {
                output.GamesPlayed = -1;
                return Task.FromResult(output);
            }

            History h = _context.History.FirstOrDefault(u => u.userId == user.Id);
            if (h == null) // No caso do utilizador nunca ter jogado, cria-se uma entrada na base de dados para este jogador.
            {
                _context.Database.EnsureCreated();

                h = new History
                {
                    Games = 0,
                    win = 0,
                    lost = 0,
                    draw = 0,
                    userId = user.Id
                };

                _context.History.Add(h);
                _context.SaveChanges();

            }

            output.Draws = h.draw;
            output.GamesPlayed = h.Games;
            output.Losts = h.lost;
            output.Wins = h.win;

            return Task.FromResult(output);
        }

        public async override Task<ValidadeReferenceModel> ValidadeReference(ValidadeReferenceLookuoModel request, ServerCallContext context)
        {
            ValidadeReferenceModel output = new ValidadeReferenceModel();

            Models.User user = _context.User.FirstOrDefault(u => u.SessionID == request.SessionId);
            if (user == null)
            {
                output.IsItValid = 0;
                output.BoughtGames = -1;
                return await Task.FromResult(output);
            }


            if (await APIServerCommunication.validateReference(request.Reference, user.Id))
            {
                output.IsItValid = 1;
            }
            else
            {
                output.IsItValid = 0;
            }
            

            // TODO: Enviar para o cliente os dados do ValidadeReferenceModel, de acordo com aquilo que recebe da API (tem de receber o número de jogos e se é válido)                   


            return await Task.FromResult(output);
        }
    }
}
