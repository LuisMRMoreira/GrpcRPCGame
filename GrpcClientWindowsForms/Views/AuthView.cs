using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GrpcClientWindowsForms.Views
{
    public partial class AuthView : Form
    {
        public event SimpleRequest GRPCStartRequest;
        
        public AuthView()
        {
            InitializeComponent();
        }

        private void AuthView_Load(object sender, EventArgs e)
        {
            GRPCStartRequest?.Invoke();
        }

        private void ButtonPlay_Click(object sender, EventArgs e)
        {
            Hide();
            Program.PlayView.Show();
        }

        private void ButtonRegister_Click(object sender, EventArgs e)
        {
            buttonRegister.Enabled = false;
            buttonLogin.Enabled = false;
            if (Program.RegisterView.ShowDialog() == DialogResult.OK)
            {
                labelOutcome.Text = "The registration process was successful!";
            }

            buttonLogin.Enabled = true;
            buttonRegister.Enabled = true;
        }

        private void ButtonLogin_Click(object sender, EventArgs e)
        {
            buttonRegister.Enabled = false;
            buttonLogin.Enabled = false;
            if (Program.LoginView.ShowDialog() == DialogResult.OK)
            {
                textboxWelcome.Text = Program.AuthUser.Username.ToString();
                labelOutcome.Visible = false;
                labelWelcome.Visible = true;
                textboxWelcome.Visible = true;

                buttonLogin.Visible = false;
                buttonRegister.Visible = false;
                buttonPlay.Enabled = true;
                buttonPlay.Visible = true;
            }
        }

        public void EnableAuthButtons()
        { 
            buttonPlay.Visible = false;
            buttonPlay.Enabled = false;        
            buttonRegister.Enabled = true;
            buttonRegister.Visible = true;
            buttonLogin.Enabled = true;
            buttonLogin.Visible = true;
        }

        public void ShowError(int errorCode)
        {

        }
    }
}
