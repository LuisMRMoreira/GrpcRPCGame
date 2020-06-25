using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GrpcClientWindowsForms.Views
{
    public partial class PlayView : Form
    {
        public event SimpleRequest GRPCStartRequest;
        public event PlayRequest PlayRequest;

        public PlayView()
        {
            InitializeComponent();
        }

        private void PlayView_Load(object sender, EventArgs e)
        {
            GRPCStartRequest?.Invoke();
        }

        // No caso de o utilizador clicar no X para fechar a form, esta é escondida e é apresentada a view de autenticação
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                ResetAndHide();
                Program.AuthView.Show();
            }
        }

        private void ButtonPlayPaper_Click(object sender, EventArgs e)
        {
            textboxClientPlay.Text = "Paper";
            DisablePlayButtons();
            PlayRequest?.Invoke(2);
        }

        private void ButtonPlayRock_Click(object sender, EventArgs e)
        {
            textboxClientPlay.Text = "Rock";
            DisablePlayButtons();
            PlayRequest?.Invoke(1);
        }

        private void ButtonPlayScissors_Click(object sender, EventArgs e)
        {
            textboxClientPlay.Text = "Scissors";
            DisablePlayButtons();
            PlayRequest?.Invoke(3);
        }

        // Sempre que é pressionado um botão para realizar uma jogada, é chamado este método para prevenir que mais jogadas sejam feitas
        // enquanto a jogada não for processada pelo servidor e apresentado o resultado ao jogador
        public void DisablePlayButtons()
        {
            buttonPlayPaper.Enabled = false;
            buttonPlayRock.Enabled = false;
            buttonPlayScissors.Enabled = false;
        }

        // Após o resultado ser apresentado ao jogador, após uma jogada, é chamado este método para ativar os botões e possibilitar outra
        // jogada do client
        public void EnablePlayButtons()
        {
            buttonPlayPaper.Enabled = true;
            buttonPlayRock.Enabled = true;
            buttonPlayScissors.Enabled = true;
        }

        // Método usado para apresentar a jogada do servidor e resultado do jogo na view
        public void ShowGameOutcome(int outcome, string serverPlay)
        {
            textboxServerPlay.Text = serverPlay;

            switch (outcome)
            {
                case 0:
                    labelOutcome.Text = "Tie!";
                    break;
                case 1:
                    labelOutcome.Text = "Client wins!";
                    break;
                case 2:
                    labelOutcome.Text = "Server wins!";
                    break;
            }

            EnablePlayButtons();
        }

        public void ShowStats(int plays, int wins, int ties, int losses, int gamesLeft)
        {
            textboxGamesPlayed.Text = plays.ToString();
            textboxWins.Text = wins.ToString();
            textboxTies.Text = ties.ToString();
            textboxLosses.Text = losses.ToString();
            gamesleft_textBox.Text = gamesLeft.ToString();
        }

        internal void UnableToPlayDueToLackOfGames()
        {
            unableToPlay_label.Visible = true;
        }

        // No caso de ocorrer algum problema com a conexão é chamado este método, que tem como função esconder e repor esta view
        public void ResetAndHide()
        {
            Hide();
            labelOutcome.Text = "";
            labelOutcome.Visible = true;
            buttonPlayPaper.Enabled = true;
            buttonPlayRock.Enabled = true;
            buttonPlayScissors.Enabled = true;
            textboxClientPlay.Text = "";
            textboxServerPlay.Text = "";
        }

        private void backToMenu_button_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
