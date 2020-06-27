using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Linq;

namespace GrpcClientWindowsForms.Views
{
    public partial class AuthView : Form
    {
        public event SimpleRequest GRPCStartRequest;
        public event SimpleRequest GRPCGetGames;
        public event APIValidateReference APIValidateReference;

        public AuthView()
        {
            InitializeComponent();
        }

        private void AuthView_Load(object sender, EventArgs e)
        {
            // Evento que irá ser recebido pelo AuthController de forma a inicializar o cliente gRPC que será importante para a comunicação entre o cliente e o servidor.
            GRPCStartRequest?.Invoke(); 
        }

        // Sempre que o utilizador clica no X, esta view é escondida, e é aberta a view de conexão
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
                Program.ConnectView.Show();
            }
        }

        // Permite definir o conteudo da label games_label de acordo com o número de jogos que o utilizador ainda possui. Este metódo será chamado através authController que por sua vez, de forma a obter o número de jogos que o utilziador tem, comunica com o servidor.
        internal void SetGames(int games)
        {
            if (games == 0)
            {
                games_label.Visible = true;
                games_label.Text = "You don't have any game,\n please buy some to play.";
                play_button.Enabled = false;
                play_button.Enabled = false;
            }
            else
            {
                games_label.Text = "You have " + games + " games\n left to play.";
                play_button.Enabled = true;
                games_label.Visible = true;
                play_button.Enabled = true;
            }
        }

        // Evento de click no botão de comprar jogos. O primeiro click faz a aprecer uma label, uma text box para que o utilizador insira uma refereni e altera o conteudo do botão ("Confirm") a.
        // Quando o utilizador clicar novamente no botão, será enviado um evento para o CreditBankController, de forma a que a referência seja validada pelo serviço de créditos e que, no caso de ser válida, os créditos sejam transferidos para a conta do servidor.
        private void ButtonPlay_Click(object sender, EventArgs e)
        {

            
            if (buyGames_button.Text == "Buy games")
            {
                // Mostar a text box para inserção de uma referencia.
                buyGames_button.Text = "Confirm";
                invalidReference_label.Visible = false;
                insertReference_label.Visible = true;
                reference_textBox.Visible = true;

            }
            else
            {
                // Na text box apenas podem ser inseridos números. No click é feita essa validação, e caso não vá de acordo com esse requisito, será apresentada uma mensagem ao servidor.
                if (reference_textBox.Text.ToString().Length == 0 || reference_textBox.Text.ToString() == null || !IsDigitsOnly(reference_textBox.Text.ToString()))
                {
                    reference_textBox.Text = "";
                    return;
                }
                buyGames_button.Text = "Buy games";
                invalidReference_label.Visible = false;
                insertReference_label.Visible = false;
                reference_textBox.Visible = false;
                
                // Evento enviado para o CreditBankController, com o objetivo de validar a referencia e transferir, no caso de ser valida, o montante contido na nota de crédito referenciada pela referencia. 
                APIValidateReference?.Invoke(reference_textBox.Text);

            }


        }

        // Verifica se todos os carateres de uma string são digitos
        private bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }

        // Depois de se ter enviado o evento APIValidateReference para o creditBankController, de forma a validar a referência, no caso desta não ser válida, será chamado este método, que apresentará uma mensagem na view.
        internal void InvalidateReference()
        {
            invalidReference_label.Visible = true;
        }

        // Depois de se ter enviado o evento APIValidateReference para o creditBankController, de forma a validar a referência, no caso desta ser válida, será chamado este método, que alterará a view para o estado inicial e enviará um evento para o AuthController para obter do servidor, o número atual de jogos do utilizador (este evento depois chamará o método SetGames).
        internal void ValidateReference()
        {
            // Obter o número total de jogos do utilizador
            GRPCGetGames?.Invoke();

            // Reset da view para o estado inicial
            buyGames_button.Text = "Buy games";
            invalidReference_label.Visible = false;
            insertReference_label.Visible = false;
            reference_textBox.Visible = false;
        }

        // No caso do utilizador ter jogos ainda para jogar (não neessitar de comprar), o botão de jogos estará ativo. O seu clique abrirá uma nova janela que terá todas as opções de jogo, assim como todas as informações o histórico do jogador.
        private void BPlay_Click(object sender, EventArgs e)
        {
            Hide();
            Program.PlayView.Show();
        }



        // Abre a view para o utilizador realizar o registo
        private void ButtonRegister_Click(object sender, EventArgs e)
        {
            buttonRegister.Enabled = false;
            buttonLogin.Enabled = false;

            // No caso de o registo ser feito com sucesso
            if (Program.RegisterView.ShowDialog() == DialogResult.OK)
            {
                labelOutcome.Text = "The registration process was successful!";
                labelOutcome.Visible = true;
            }

            buttonLogin.Enabled = true;
            buttonRegister.Enabled = true;
        }

        // Abre a view para o utilizador realizar o login
        private void ButtonLogin_Click(object sender, EventArgs e)
        {
            buttonRegister.Enabled = false;
            buttonLogin.Enabled = false;

            // Se o login for feito com sucesso
            if (Program.LoginView.ShowDialog() == DialogResult.OK)
            {
                labelOutcome.Visible = false;
                buttonLogin.Visible = false;
                buttonRegister.Visible = false;
                textboxWelcome.Text = Program.AuthUser.Username.ToString();
                buyGames_button.Enabled = true;
                buyGames_button.Visible = true;
                play_button.Enabled = true;
                play_button.Visible = true;
                Button_gotoCreditBank.Enabled = true;
                Button_gotoCreditBank.Visible = true;

                // Obter o número total de jogos do utilizador no caso do login ser bem sucedido.
                GRPCGetGames?.Invoke();

            }
            else
            {
                buttonLogin.Enabled = true;
                buttonRegister.Enabled = true;
            }
        }

        // Método que tranforma o menu de jogo no menu de autenticação. Como a view de autencicação e do menu é a mesma, apenas se escondem os botões, é necessário fazer estas operações.
        public void EnableAuthButtons()
        {
            buyGames_button.Visible = false;
            buyGames_button.Enabled = false;
            play_button.Enabled = false;
            play_button.Visible = false;
            Button_gotoCreditBank.Enabled = false;
            Button_gotoCreditBank.Visible = false;
            buttonRegister.Enabled = true;
            buttonRegister.Visible = true;
            buttonLogin.Enabled = true;
            buttonLogin.Visible = true;
        }


        // Método que tranforma o menu de jogo no menu de autenticação. Como a view de autencicação e do menu é a mesma, apenas se escondem os botões, é necessário fazer estas operações.
        public void ResetView()
        {
            buyGames_button.Visible = false;
            buyGames_button.Enabled = false;
            play_button.Enabled = false;
            play_button.Visible = false;
            Button_gotoCreditBank.Enabled = false;
            Button_gotoCreditBank.Visible = false;
            textboxWelcome.Text = "";
            buttonLogin.Enabled = true;
            buttonRegister.Enabled = true;
            buttonLogin.Visible = true;
            buttonRegister.Visible = true;
        }

        // Click do botão do banco de créditos. O utilizador será redirecionado para a view do banco de créditos, sem que a atual seja fechada.
        private void Button_gotoCreditBank_Click(object sender, EventArgs e)
        {
            Program.CreditBankMenurView.ShowDialog();
        }

        // Invalida que o utilizado insira uma referencia com caracteres que não sejam digitos.
        private void reference_textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }


        // De forma a atualizar o número de jogos que o jogar ainda pode fazer, na AuthView (depois de ter sido feita a autenticação), sempre que a visibilidade da view mudar, o evento que faz essa atualização é chamado.
        private void AuthView_VisibleChanged(object sender, EventArgs e)
        {
            // No caso do utilziador estar autenticado.
            if (Program.AuthUser != null)
            {
                // Obter o número total de jogos do utilizador
                GRPCGetGames?.Invoke();

            }

        }
    }
}
