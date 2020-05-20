using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GrpcClientWindowsForms.Views
{
    public partial class ConnectView : Form
    {
        public event ConnectRequest ConnectRequest;
        public event SimpleRequest RestartConnectionRequest;

        public ConnectView()
        {
            InitializeComponent();
        }

        private void TextboxServerAddress_TextChanged(object sender, EventArgs e)
        {
            buttonConnect.Enabled = true;
        }

        private void ButtonConnect_Click(object sender, EventArgs e)
        {
            buttonConnect.Enabled = false;
            textboxServerAddress.Enabled = false;
            ConnectRequest?.Invoke(textboxServerAddress.Text);
        }

        private void ButtonContinue_Click(object sender, EventArgs e)
        {
            Program.ConnectView.Hide();
            Program.AuthView.Show();
        }

        private void ButtonRestart_Click(object sender, EventArgs e)
        {
            buttonContinue.Enabled = false;
            buttonRestart.Enabled = false;
            RestartConnectionRequest?.Invoke();
        }

        // Usado para mostrar erros nas views, se ocorrerem durante o processo de conexão ao servidor
        // Código de erros:
        //     -1 - A conexão já foi estabelecida com sucesso e o cliente está a tentar estabeler a conexão de novo
        //     -2 - O endereço inserido pelo cliente é inválido
        //     -3 - Não foi possível estabeler conexão com o servidor com o endereço inserido
        //     -4 - O utilizador autenticado no cliente não existe na base de dados do servidor
        public void ShowError(int error)
        {
            switch (error)
            {
                case -1:
                    SuccessfulConnection();
                    break;
                case -2:
                    RestartView();
                    labelOutcome.Text = "-2: Invalid address!";
                    labelOutcome.Visible = true;
                    break;
                case -3:
                    RestartView();
                    labelOutcome.Text = "-3: Connection failed!";
                    labelOutcome.Visible = true;
                    break;
                case -4:
                    RestartView();
                    labelOutcome.Text = "-4: User not found!";
                    labelOutcome.Visible = true;
                    break;
                default:
                    RestartView();
                    labelOutcome.Text = "Unknown error!";
                    labelOutcome.Visible = true;
                    break;
            }
        }

        // Método usado para abrir a view que pode ser chamado por controllers
        public void OpenIfClosed()
        {
            Show();
        }

        // Operações na view sempre que a conexão for feita com sucesso
        public void SuccessfulConnection()
        {
            labelOutcome.Text = "Connection successful!";
            labelOutcome.Visible = true;
            buttonConnect.Visible = false;
            buttonContinue.Enabled = true;
            buttonRestart.Enabled = true;
            buttonContinue.Visible = true;
            buttonRestart.Visible = true;
        }

        // Operações para repor a view para o estado inicial, sem alterar o endereço que foi inserido na textbox do endereço
        public void RestartView()
        {
            labelOutcome.Text = "";
            labelOutcome.Visible = false;
            buttonConnect.Enabled = true;
            buttonContinue.Enabled = false;
            buttonRestart.Enabled = false;
            buttonContinue.Visible = false;
            buttonRestart.Visible = false;
            textboxServerAddress.Enabled = true;
            buttonConnect.Visible = true;
        }   
    }
}
