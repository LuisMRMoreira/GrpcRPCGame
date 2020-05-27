using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GrpcClientWindowsForms.Views
{
    public partial class LoginView : Form
    {
        public event LoginRequest LoginRequest;

        public LoginView()
        {
            InitializeComponent();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (e.CloseReason == CloseReason.UserClosing)
            {
                ResetView();
            }
        }

        private void ButtonLogin_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(textboxUsername.Text) || String.IsNullOrWhiteSpace(textboxPassword.Text))
            {
                ShowError("Please fill all the fields!");
                return;
            }

            LoginRequest?.Invoke(textboxUsername.Text, textboxPassword.Text);
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
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
            labelOutcome.Visible = false;
            textboxUsername.Text = "";
            textboxPassword.Text = "";
        }

        public void ShowError(string errorMessage)
        {
            ResetView();

            labelOutcome.Text = errorMessage;
            labelOutcome.Visible = true;
        }    
    }
}
