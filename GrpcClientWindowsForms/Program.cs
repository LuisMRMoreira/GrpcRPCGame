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
using System.Net.Http;

namespace GrpcClientWindowsForms
{
    static class Program
    {
        // Definição do url base
        public static string URL_BASE = "http://localhost:8080/";


        // Guarda o ID e Username do utilizador que está a usar o cliente
        public static AuthenticatedUser AuthUser { get; private set; }

        // Endereço do servidor a qual é feita a conexão
        public static GrpcChannel ConnectionChannel { get; private set; }

        // Views
        public static AuthView AuthView { get; private set; }
        public static ConnectView ConnectView { get; private set; }
        public static LoginView LoginView { get; private set; }
        public static PlayView PlayView { get; private set; }
        public static RegisterView RegisterView { get; private set; }
        public static CreditBankMenuView CreditBankMenurView { get; private set; }
        public static CreditBankAuthenticationVIew CreditBankAuthenticationVIew { get; private set; }

        // Controllers
        public static AuthController AuthController { get; private set; }
        public static ConnectController ConnectController { get; private set; }
        public static PlayController PlayController { get; private set; }

        [STAThread]
        static async Task Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //HttpClient client = new HttpClient();
            //HttpResponseMessage response = await client.GetAsync("http://localhost:8080/accounts/");
            //response.EnsureSuccessStatusCode();


            AuthView = new AuthView();
            ConnectView = new ConnectView();
            LoginView = new LoginView();
            PlayView = new PlayView();
            RegisterView = new RegisterView();
            CreditBankMenurView = new CreditBankMenuView();
            CreditBankAuthenticationVIew = new CreditBankAuthenticationVIew();

            AuthController = new AuthController();
            ConnectController = new ConnectController();
            PlayController = new PlayController();
            AuthController = new AuthController();

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

        // Método usado para guardar os dados do utilizador autenticado (ID de sessão e username) no cliente
        public static void SetAuthenticatedUser(string sessionID, string username)
        {
            AuthUser = new AuthenticatedUser(sessionID, username);
        }

        // Remove os dados do utilizador autenticado no cliente
        public static void ResetAuthenticatedUser()
        {
            AuthUser = null;
        }
    }
}
