using Grpc.Core;
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
            Random rnd = new Random();
            int serverPlay = rnd.Next(1, 4);

            PlayModel output = new PlayModel();
            History h;
            h = _context.History.Include(i => i.User).FirstOrDefault(u => u.userId == request.UserId);
            if (h == null) // No caso do utilizador nunca ter jogado
            {
                _context.Database.EnsureCreated();


                Models.User user = _context.User.FirstOrDefault(u => u.Id == request.UserId);

                h = new Models.History();
                h.userId = request.UserId;
                h.User = user;

                _context.History.Add(h);
                _context.SaveChanges();

            }



            switch (request.Play)
            {
                case 1: // Pedra

                    switch (serverPlay)
                    {
                        case 1: // Pedra
                            output.ServerPlay = "Pedra";
                            output.Result = 0; // Empate
                            h.draw++;
                            break;
                        case 2: // Papel
                            output.ServerPlay = "Papel";
                            output.Result = 2; // Servidor venceu
                            h.lost++;
                            break;
                        case 3: // Tesoura
                            output.ServerPlay = "Tesoura";
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
                            output.ServerPlay = "Pedra";
                            output.Result = 1; // Utilizador venceu
                            h.win++;
                            break;
                        case 2: // Papel
                            output.ServerPlay = "Papel";
                            output.Result = 0; // Empate
                            h.draw++;
                            break;
                        case 3: // Tesoura
                            output.ServerPlay = "Tesoura";
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
                            output.ServerPlay = "Pedra";
                            output.Result = 2; // Servidor venceu
                            h.lost++;
                            break;
                        case 2: // Papel
                            output.ServerPlay = "Papel";
                            output.Result = 1; // Utilizador venceu
                            h.win++;
                            break;
                        case 3: // Tesoura
                            output.ServerPlay = "Tesoura";
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
            Models.History h = new Models.History();
            h = _context.History.FirstOrDefault(u => u.userId == request.UserId);
            if (h == null) // No caso do utilizador nunca ter jogado, cria-se uma entrada.
            {
                _context.Database.EnsureCreated();

                h = new History
                {
                    Games = 0,
                    win = 0,
                    lost = 0,
                    draw = 0,
                    userId = request.UserId
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


    }
}
