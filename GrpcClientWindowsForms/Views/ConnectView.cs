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

        // Como este é a primeira view a ser apresentada, quando é fechada, devem ser fechadas todas as outras views do cliente
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (e.CloseReason == CloseReason.UserClosing)
            {
                Program.PlayView.Close();
                Program.AuthView.Close();
            }
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
        public void ShowError(string error)
        {
            RestartView();
            labelOutcome.Text = error;
            labelOutcome.Visible = true;
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
