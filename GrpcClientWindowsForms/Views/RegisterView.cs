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

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (e.CloseReason == CloseReason.UserClosing)
            {
                ResetView();
            }
        }

        public void ShowError(string error)
        {
            labelOutcome.Text = error;
            labelOutcome.Visible = true;
        }

        private void ButtonRegister_Click(object sender, EventArgs e)
        {
            // Para reduzir o número de pedidos desnecessários, apenas é enviado um pedido ao servidor se todos os campos forem preenchidos
            if (String.IsNullOrWhiteSpace(textboxUsername.Text) || String.IsNullOrWhiteSpace(textboxEmail.Text) || String.IsNullOrWhiteSpace(textboxPassword.Text) || String.IsNullOrWhiteSpace(textboxPasswordConfirmation.Text))
            {
                ShowError("Please fill all the fields!");
                return;
            }

            RegisterRequest?.Invoke(textboxUsername.Text, textboxEmail.Text, textboxPassword.Text, textboxPasswordConfirmation.Text);
        }

        public void SuccessfulRegistration()
        {
            labelOutcome.Visible = false;
            DialogResult = DialogResult.OK;
            Close();
        }

        public void ResetView()
        {
            textboxUsername.Text = "";
            textboxEmail.Text = "";
            textboxPassword.Text = "";
            textboxPasswordConfirmation.Text = "";
            labelOutcome.Text = "";
            labelOutcome.Visible = false;
        }

        private void RegisterView_Load(object sender, EventArgs e)
        {

        }
    }
}
