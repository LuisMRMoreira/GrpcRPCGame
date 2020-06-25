using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace GrpcClientWindowsForms.Views
{
    public partial class AuthView : Form
    {
        public event SimpleRequest GRPCStartRequest;
        public event SimpleRequest GRPCGetGames;
        public event APIValidateReference APIValidateReference;

        public AuthView()
        {
            InitializeComponent();
        }

        private void AuthView_Load(object sender, EventArgs e)
        {
            GRPCStartRequest?.Invoke();



            
        }

        // Sempre que o utilizador clica no X, esta view é escondida, e é aberta a view de conexão
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
                Program.ConnectView.Show();
            }
        }

        internal void SetGames(int games)
        {
            if (games == 0)
            {
                games_label.Visible = true;
                games_label.Text = "You don't have any game, please by some to play.";
                play_button.Enabled = false;
                play_button.Enabled = false;
            }
            else
            {
                games_label.Text = "You have " + games + " left to play.";
                play_button.Enabled = true;
                games_label.Visible = true;
                play_button.Enabled = true;
            }
        }

        private void ButtonPlay_Click(object sender, EventArgs e)
        {

            // Mostar o input text para inserção de uma referencia
            if (buyGames_button.Text == "Buy games")
            {


                buyGames_button.Text = "Confirm";
                invalidReference_label.Visible = false;
                insertReference_label.Visible = true;
                reference_textBox.Visible = true;

            }
            else
            {
                if (reference_textBox.Text.ToString().Length == 0 || reference_textBox.Text.ToString() == null || !IsDigitsOnly(reference_textBox.Text.ToString()))
                {
                    reference_textBox.Text = "";
                    return;
                }
                buyGames_button.Text = "Buy games";
                invalidReference_label.Visible = false;
                insertReference_label.Visible = false;
                reference_textBox.Visible = false;
                // TODO: Criar uma nova creditnote com o valor indicado, caso seja possível
                APIValidateReference?.Invoke(reference_textBox.Text);

            }


        }

        private bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }

        private void BPlay_Click(object sender, EventArgs e)
        {

            Hide();
            Program.PlayView.Show();

            


        }


        internal void InvalidateReference()
        {
            invalidReference_label.Visible = true;
        }

        internal void ValidateReference()
        {
            // Obter o número total de jogos do utilizador
            GRPCGetGames?.Invoke();
            buyGames_button.Text = "Buy games";
            invalidReference_label.Visible = false;
            insertReference_label.Visible = false;
            reference_textBox.Visible = false;
        }

        // Abre a view para o utilizador realizar o registo
        private void ButtonRegister_Click(object sender, EventArgs e)
        {
            buttonRegister.Enabled = false;
            buttonLogin.Enabled = false;

            // No caso de o registo ser feito com sucesso
            if (Program.RegisterView.ShowDialog() == DialogResult.OK)
            {
                labelOutcome.Text = "The registration process was successful!";
                labelOutcome.Visible = true;
            }

            buttonLogin.Enabled = true;
            buttonRegister.Enabled = true;
        }

        // Abre a view para o utilizador realizar o login
        private void ButtonLogin_Click(object sender, EventArgs e)
        {
            buttonRegister.Enabled = false;
            buttonLogin.Enabled = false;

            // Se o login for feito com sucesso
            if (Program.LoginView.ShowDialog() == DialogResult.OK)
            {
                labelOutcome.Visible = false;
                buttonLogin.Visible = false;
                buttonRegister.Visible = false;
                textboxWelcome.Text = Program.AuthUser.Username.ToString();
                buyGames_button.Enabled = true;
                buyGames_button.Visible = true;
                play_button.Enabled = true;
                play_button.Visible = true;
                Button_gotoCreditBank.Enabled = true;
                Button_gotoCreditBank.Visible = true;
                // Obter o número total de jogos do utilizador
                GRPCGetGames?.Invoke();

            }
            else
            {
                buttonLogin.Enabled = true;
                buttonRegister.Enabled = true;
            }
        }

        public void EnableAuthButtons()
        {
            buyGames_button.Visible = false;
            buyGames_button.Enabled = false;
            play_button.Enabled = false;
            play_button.Visible = false;
            Button_gotoCreditBank.Enabled = false;
            Button_gotoCreditBank.Visible = false;
            buttonRegister.Enabled = true;
            buttonRegister.Visible = true;
            buttonLogin.Enabled = true;
            buttonLogin.Visible = true;
        }

        public void ResetView()
        {
            buyGames_button.Visible = false;
            buyGames_button.Enabled = false;
            play_button.Enabled = false;
            play_button.Visible = false;
            Button_gotoCreditBank.Enabled = false;
            Button_gotoCreditBank.Visible = false;
            textboxWelcome.Text = "";
            buttonLogin.Enabled = true;
            buttonRegister.Enabled = true;
            buttonLogin.Visible = true;
            buttonRegister.Visible = true;
        }

        private void Button_gotoCreditBank_Click(object sender, EventArgs e)
        {

            Program.CreditBankMenurView.ShowDialog();

        }

        private void reference_textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))//&& (e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }
    }
}
