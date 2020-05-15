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
        // Channel e Client usados para autenticação
        public static GrpcChannel AuthChannel { get; private set; }
        public static User.UserClient AuthClient { get; private set; }

        public static PlayView PlayView { get; private set; }
        public static PlayController PlayController { get; private set; }

        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            PlayView = new PlayView();
            PlayController = new PlayController();

            Application.Run(PlayView);
        }
    }
}
