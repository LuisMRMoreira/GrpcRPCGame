using GrpcClientConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GrpcClientWindowsForms.Views
{
    public partial class CreditBankAuthenticationVIew : Form
    {

        public event APILoginRequest APILoginRequest;

        public CreditBankAuthenticationVIew()
        {
            InitializeComponent();
        }


        

        private void login_button_Click(object sender, EventArgs e)
        {

            // Apenas envia pedido para o servidor se o utilizador preencher todos os campos de autenticação
            if (String.IsNullOrWhiteSpace(username_textBox.Text) || String.IsNullOrWhiteSpace(password_textBox.Text))
            {
                ShowError("Please fill all the fields!");
                return;
            }

            APILoginRequest?.Invoke(username_textBox.Text, password_textBox.Text);


        }

        private void cancel_button_Click(object sender, EventArgs e)
        {
            ResetView();
        }

        public void SuccessfulLogin()
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        public void ResetView()
        {
            errorMessage_label.Visible = false;
            username_textBox.Text = "";
            password_textBox.Text = "";
        }


        public void ShowError(string errorMessage)
        {
            ResetView();

            errorMessage_label.Text = errorMessage;
            errorMessage_label.Visible = true;
        }

        private void CreditBankAuthenticationVIew_FormClosing(object sender, FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (e.CloseReason == CloseReason.UserClosing)
            {
                ResetView();
            }
        }
    }
}
