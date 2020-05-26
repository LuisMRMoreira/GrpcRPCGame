﻿using System;
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

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
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

        // No caso de ocorrer algum problema com a conexão é chamado este método, que tem como função esconder e repor esta view
        public void ResetAndHide()
        {
            Hide();
            labelOutcome.Text = "";
            labelOutcome.Visible = false;
            buttonPlayPaper.Enabled = false;
            buttonPlayRock.Enabled = false;
            buttonPlayScissors.Enabled = false;
            textboxClientPlay.Text = "";
            textboxServerPlay.Text = "";
        }
    }
}
