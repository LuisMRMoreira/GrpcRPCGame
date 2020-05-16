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

        public void ShowError(int errorCode)
        {

        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            RegisterRequest?.Invoke(textboxUsername.Text, textboxEmail.Text, textboxPassword.Text, textboxPasswordConfirmation.Text);
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void ResetView()
        {

        }

        public void SuccessfulRegistration()
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
