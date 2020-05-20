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
        // Guarda o ID e Username do utilizador que está a usar o cliente
        public static AuthenticatedUser AuthUser { get; private set; }

        // Endereço do servidor a qual é feita a conexão
        public static GrpcChannel ConnectionChannel { get; private set; }

        public static AuthView AuthView { get; private set; }
        public static ConnectView ConnectView { get; private set; }
        public static LoginView LoginView { get; private set; }
        public static PlayView PlayView { get; private set; }
        public static RegisterView RegisterView { get; private set; }

        public static AuthController AuthController { get; private set; }
        public static ConnectController ConnectController { get; private set; }
        public static PlayController PlayController { get; private set; }

        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            AuthView = new AuthView();
            ConnectView = new ConnectView();
            LoginView = new LoginView();
            PlayView = new PlayView();
            RegisterView = new RegisterView();

            AuthController = new AuthController();
            ConnectController = new ConnectController();
            PlayController = new PlayController();

            Application.Run(ConnectView);
        }

        // Método para atribuir um valor ao field ServerAddress, que é usado para iniciar os channels das conexões GRPC
        public static void SetConnectionChannel(string address)
        {
            ConnectionChannel = GrpcChannel.ForAddress(address);
        }

        // Método usado para repor o channel usado para comunicar com o servidor
        public static void ResetConnection()
        {
            ConnectionChannel = null;
        }

        public static void SetAuthenticatedUser(string sessionID, string username)
        {
            AuthUser = new AuthenticatedUser(sessionID, username);
        }

        public static void ResetAuthenticatedUser()
        {
            AuthUser = null;
        }
    }
}
