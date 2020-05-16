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

        private void buttonPlay_Click(object sender, EventArgs e)
        {

        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            buttonRegister.Enabled = false;
            buttonLogin.Enabled = false;
            if (Program.RegisterView.ShowDialog() == DialogResult.OK)
            {
                // TODO: Mensagem de sucesso de registo
            }
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            buttonRegister.Enabled = false;
            buttonLogin.Enabled = false;
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
