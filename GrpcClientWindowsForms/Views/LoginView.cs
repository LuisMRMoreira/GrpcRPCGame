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

        private void ButtonLogin_Click(object sender, EventArgs e)
        {
            LoginRequest?.Invoke(textboxUsername.Text, textboxPassword.Text);
        }

        public void SuccessfulLogin()
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
