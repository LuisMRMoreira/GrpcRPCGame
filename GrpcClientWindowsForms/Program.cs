using Grpc.Net.Client;
using GrpcClientWindowsForms.Controllers;
using GrpcClientWindowsForms.Views;
using GrpcServerRPS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GrpcClientWindowsForms
{
    static class Program
    {
        // Endereço do servidor a qual é feita a conexão
        public static string ServerAddress { get; private set; }
        public static AuthView AuthView { get; private set; }
        public static PlayView PlayView { get; private set; }
        public static RegisterView RegisterView { get; private set; }
        public static AuthController AuthController { get; private set; }
        public static PlayController PlayController { get; private set; }

        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            AuthView = new AuthView();
            PlayView = new PlayView();
            RegisterView = new RegisterView();

            AuthController = new AuthController();
            PlayController = new PlayController();

            Application.Run(AuthView);
        }

        // Método para atribuir um valor ao field ServerAddress, que é usado para iniciar os channels das conexões GRPC
        public static void SetServerAddress(string ipAddress)
        {
            ServerAddress = "https://" + ipAddress + ":5001";
        }
    }
}
