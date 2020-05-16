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

        private void buttonPlayPaper_Click(object sender, EventArgs e)
        {
            textboxClientPlay.Text = "Paper";
            PlayRequest?.Invoke(1);
        }

        private void buttonPlayRock_Click(object sender, EventArgs e)
        {
            textboxClientPlay.Text = "Rock";
            PlayRequest?.Invoke(2);
        }

        private void ButtonPlayScissors_Click(object sender, EventArgs e)
        {
            textboxClientPlay.Text = "Scissors";
            PlayRequest?.Invoke(3);
        } 

        public void UpdateButtonsToEnabled()
        {
            buttonPlayPaper.Enabled = true;
            buttonPlayRock.Enabled = true;
            buttonPlayScissors.Enabled = true;
        }

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
        }

        public void ShowError(string error)
        {
            labelOutcome.Text = error;
            labelOutcome.Visible = true;
        }
    }
}
