using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GrpcClientWindowsForms.Views
{
    public partial class RegisterView : Form
    {
        public event RegisterRequest RegisterRequest;

        public RegisterView()
        {
            InitializeComponent();
        }

        public void ShowError(string error)
        {
            labelOutcome.Text = error;
            labelOutcome.Visible = true;
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            RegisterRequest?.Invoke(textboxUsername.Text, textboxEmail.Text, textboxPassword.Text, textboxPasswordConfirmation.Text);
        }

        public void SuccessfulRegistration()
        {
            labelOutcome.Visible = false;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void RegisterView_Load(object sender, EventArgs e)
        {

        }
    }
}
