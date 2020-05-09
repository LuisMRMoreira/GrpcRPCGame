using System;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Grpc.Net.Client;
using GrpcServerRPS;
using GrpcServicerRPC;

namespace GrpcClientConsoleApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Boolean valido1 = false;
            String loginOuRegisto = "";
            int userDBId = -1;

            while ( !valido1 )
            {
                Console.WriteLine("Antes de continuar, já tem conta ou não (Y/N)?\n");
                loginOuRegisto = Console.ReadLine();
                loginOuRegisto.ToUpper();

                if ((loginOuRegisto.Equals("N") || loginOuRegisto.Equals("Y")))
                    valido1 = true;

            }

            String username, password, email, confirmacaoPassword;
            Boolean valido = false;
            loginOuRegisto.ToUpper();

            while ( !valido )
            { 
                if (loginOuRegisto.Equals("Y"))
                {
                    Console.WriteLine("\nUsername: ");
                    username = Console.ReadLine();
                    Console.WriteLine("\nPassword: ");
                    password = Console.ReadLine();

                    // Verificar a existência destes valores na base de dados do servidor.
                    var clientRequest = new UserLoginLookupModel { Username = username, Password = password };
                    var channel = GrpcChannel.ForAddress("https://localhost:5001");
                    var client = new User.UserClient(channel);
                    var reply = await client.LoginAsync(clientRequest);
                    valido = reply.Valid; // Caso a autenticação seja bem sucedida, o valor retornado é true. Quando o valor da variavel "valido" é true, a execução já não entrará novamente no ciclo while, passando para a nova fase.

                    if (valido)
                    {
                        Console.WriteLine("\nEstás autenticado! ");
                        userDBId = reply.UserId;
                    }
                    else
                    {
                        Console.WriteLine("\nNão estás autenticado! ");
                    }



                }
                else if (loginOuRegisto.Equals("N"))
                {
                    Console.WriteLine("\nUsername: ");
                    username = Console.ReadLine();
                    Console.WriteLine("\nEmail: ");
                    email = Console.ReadLine();
                    Console.WriteLine("\nPassword: ");
                    password = Console.ReadLine();
                    Console.WriteLine("\nConfirmação da password: ");
                    confirmacaoPassword = Console.ReadLine();

                    if (!password.Equals(confirmacaoPassword))
                    {
                        Console.WriteLine("\nO campo Pasword e o de confirmação de password não são iguais. Tente novamente.");
                        continue;
                    }

                    // Verificar a existência destes valores na base de dados do servidor e registar o utilizador.
                    var clientRequest = new UserRegistLookupModel { Username = username, Email = email, Password = password };
                    var channel = GrpcChannel.ForAddress("https://localhost:5001");
                    var client = new User.UserClient(channel);
                    var reply = await client.RegistAsync(clientRequest);
                    valido = reply.Valid; // Caso o registo seja bem sucedida, o valor retornado é true. Quando o valor da variavel "valido" é true, a execução já não entrará novamente no ciclo while, passando para a nova fase.

                    if (!valido)
                    {
                        Console.WriteLine("\nErro no registo! ");
                    }
                    else
                    {
                        valido = false;
                        loginOuRegisto = "Y"; // Vai continuar no ciclo, mas desta vez para fazer a autenticação.
                    }


                }

            }

            Console.WriteLine("Agora que está autenticado, vamos jogar!\n");
            Console.WriteLine("Comandos possíveis:\n");
            Console.WriteLine("\t -> play pedra: Jogada pedra;\n");
            Console.WriteLine("\t -> play tesoura: jogada tesoura;\n");
            Console.WriteLine("\t -> play papel: Jogada papel;\n");
            Console.WriteLine("\t -> stats: Ver as suas estatísticas;\n");
            Console.WriteLine("\t -> end: Finalizar o jogo;\n");
            Console.WriteLine("\t -> help: Ver esta tabela novamente;\n");

            bool validoJogo = true;

            while (validoJogo)
            {
                string input = Console.ReadLine();

                var channel = GrpcChannel.ForAddress("https://localhost:5001");
                var client = new Game.GameClient(channel);

                if (input.Equals("play pedra"))
                {

                    var clientRequest = new PlayLookupModel { UserId = userDBId, Play = 1 };
                    var reply = await client.PlayAsync(clientRequest);

                    if (reply.Result == 1)
                        Console.WriteLine("Resumo do jogo:\n\tCliente: Pedra\n\tServidor: " + reply.ServerPlay + "\n\tResultado final: O cliente ganhou!\n\n");
                    else if (reply.Result == 2)
                        Console.WriteLine("Resumo do jogo:\n\tCliente: Pedra\n\tServidor: " + reply.ServerPlay + "\n\tResultado final: O servidor ganhou!\n\n");
                    else if (reply.Result == 0)
                        Console.WriteLine("Resumo do jogo:\n\tCliente: Pedra\n\tServidor: " + reply.ServerPlay + "\n\tResultado final: Empate!\n\n");

                }
                else if (input.Equals("play papel"))
                {
                    var clientRequest = new PlayLookupModel { UserId = userDBId, Play = 2 };
                    var reply = await client.PlayAsync(clientRequest);

                    if (reply.Result == 1)
                        Console.WriteLine("Resumo do jogo:\n\tCliente: Pedra\n\tServidor: " + reply.ServerPlay + "\n\tResultado final: O cliente ganhou!\n\n");
                    else if (reply.Result == 2)
                        Console.WriteLine("Resumo do jogo:\n\tCliente: Pedra\n\tServidor: " + reply.ServerPlay + "\n\tResultado final: O servidor ganhou!\n\n");
                    else if (reply.Result == 0)
                        Console.WriteLine("Resumo do jogo:\n\tCliente: Pedra\n\tServidor: " + reply.ServerPlay + "\n\tResultado final: Empate!\n\n");

                }
                else if (input.Equals("play tesoura"))
                {
                    var clientRequest = new PlayLookupModel { UserId = userDBId, Play = 3 };
                    var reply = await client.PlayAsync(clientRequest);

                    if (reply.Result == 1)
                        Console.WriteLine("Resumo do jogo:\n\tCliente: Pedra\n\tServidor: " + reply.ServerPlay + "\n\tResultado final: O cliente ganhou!\n\n");
                    else if (reply.Result == 2)
                        Console.WriteLine("Resumo do jogo:\n\tCliente: Pedra\n\tServidor: " + reply.ServerPlay + "\n\tResultado final: O servidor ganhou!\n\n");
                    else if (reply.Result == 0)
                        Console.WriteLine("Resumo do jogo:\n\tCliente: Pedra\n\tServidor: " + reply.ServerPlay + "\n\tResultado final: Empate!\n\n");
                }
                else if (input.Equals("stats"))
                {
                    if (userDBId != -1)
                    {
                        var clientRequest = new StatsLookupModel { UserId = userDBId };
                        var reply = await client.StatsAsync(clientRequest);

                        Console.WriteLine("\nAs suas estatísticas:\n\t-> Jogos feitos: " + reply.GamesPlayed.ToString() + "\n\t->Ganhos: " + reply.Wins.ToString() + "\n\t->Perdidos: " + reply.Losts.ToString() + "\n\t->Empatados: " + reply.Draws.ToString() + "\n\n");

                    }

                }
                else if (input.Equals("end"))
                {
                    // TODO: Fechar conexão com o gRPC
                    validoJogo = false;
                }
                else if (input.Equals("help"))
                {
                    Console.WriteLine("Comandos possíveis:\n");
                    Console.WriteLine("\t -> play rock: Jogada pedra;\n");
                    Console.WriteLine("\t -> play scissors: jogada tesoura;\n");
                    Console.WriteLine("\t -> play paper: Jogada papel;\n");
                    Console.WriteLine("\t -> stats: Ver as suas estatísicas;\n");
                    Console.WriteLine("\t -> end: Finalizar o jogo;\n");
                    Console.WriteLine("\t -> help: Ver esta tabela novamente;\n");
                }
                else
                {
                    Console.WriteLine("Comando inválido");
                }
            }




        }
    }
}
