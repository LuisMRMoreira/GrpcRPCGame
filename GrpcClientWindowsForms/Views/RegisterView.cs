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

        // Sempre que esta view é fechada pelo utilizador, é sempre reposta para o estado inicial
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (e.CloseReason == CloseReason.UserClosing)
            {
                ResetView();
            }
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

        // No caso de o registo ser feito com sucesso, é fechada a view com DialogResult OK
        public void SuccessfulRegistration()
        {
            labelOutcome.Visible = false;
            DialogResult = DialogResult.OK;
            Close();
        }

        // Apresenta erros na view
        public void ShowError(string error)
        {
            labelOutcome.Text = error;
            labelOutcome.Visible = true;
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
    }
}
