using GrpcClientConsoleApp.Models;
using GrpcClientWindowsForms.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GrpcClientWindowsForms.Views
{
    public partial class CreditBankMenuView : Form
    {

        public event APICreateCredinoteRequest APICreateCredinote;
        public event APIGetDataOnLoadRequest APIGetDataOnLoadRequest;
        public event SimpleRequest GRPCSTartRequest;

        public CreditBankMenuView()
        {
            InitializeComponent();
        }

        private void CreditBankMenuView_Load(object sender, EventArgs e)
        {
            // Quando a página do banco de créditos for carregada, envia-se um evento para se obter, tanto o utilizador (com as respetivas notas de crédito), como o historico de transações.
            APIGetDataOnLoadRequest?.Invoke(1); // Utilizador com as notas de crédito.
            APIGetDataOnLoadRequest?.Invoke(3); // Transações
        }

        // Clique para criação de uma nova nota de crédito.
        private void createCredit_button_Click(object sender, EventArgs e)
        {
            // O primeiro clique no botão, altera o texto do botão para Confirm e faz aparecer a text box e a label. O segundo clique, mete a view no estado inicial e envia um evento para o CreditBankMenuController para tratar a validação da referência. 
            if (createCredit_button.Text == "Confirm")
            {
                // Envia evento para o CreditBankMenuController para validar a referência.
                APICreateCredinote?.Invoke(float.Parse(createCreditNoteValue_TextBox.Text));

                createCredit_button.Text = "Create credit";
                CreateCreditnote_label.Visible = false;
                createCreditNoteValue_TextBox.Visible = false;
                errorMessage_label.Visible = false;

            }
            else
            {

                createCredit_button.Text = "Confirm";

                CreateCreditnote_label.Visible = true;
                createCreditNoteValue_TextBox.Visible = true;
                errorMessage_label.Visible = false;

            }
        }


        // Bloqueia o input da text box de ser caracteres, que não digitos.
        private void createCreditNoteValue_TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        
        // Popular a listView com as notas de crédito do utilizador atual (verde => Ainda não foram usados; vermelho => Já foram usados)
        internal void PopulateCreditNoteTable(List<CreditNote> creditNotes)
        {
            creditNotes_listView.Items.Clear();
            foreach (CreditNote creditnote in creditNotes)
            {
                var row = new string[] { creditnote.reference.ToString(), creditnote.amount.ToString(), creditnote.dateExpiry };
                var lvi = new ListViewItem(row);
                lvi.Tag = creditnote;
                if (creditnote.used)
                    lvi.BackColor = Color.Red;
                else
                    lvi.BackColor = Color.Green;

                creditNotes_listView.Items.Add(lvi);

            }

        }

        // Método chamado após ser obtido da API e do servidor de jogo o utilizador com as respetivas notas de crédito. O pedido desta informação veio da chamada do evento no load desta view.
        internal void PopulateUserData(Account account)
        {
            username_label.Text = account.name;

            amount_value_lable.Text = account.amount.ToString() + " créditos" ;

            if (account.notes != null)
                PopulateCreditNoteTable(account.notes);


        }

        // Método chamado após ser obtido da API todas as transações feitas em que o utilizador atual participou (Verde => lucro; Vermelho => Perda). O pedido desta informação veio da chamada do evento no load desta view.
        internal void PopulateHistoricTable(List<Transaction> transactions)
        {
            if (transactions == null)
            {
                return;
            }

            historic_listView.Items.Clear();
            foreach (Transaction transaction in transactions)
            {
                var row = new string[] { transaction.idSender.name, transaction.idReceiver.name, transaction.amount.ToString(), transaction.date }; // TODO: Alterar do id do recetor para o número da conta do receto (ou nome do recetor).
                var lvi = new ListViewItem(row);
                lvi.Tag = transaction;
                if (transaction.idReceiver.accountNumber == 0) 
                    lvi.BackColor = Color.Red;
                else
                    lvi.BackColor = Color.Green;

                historic_listView.Items.Add(lvi);

            }

        }

        // No caso da referencia for válida, depois de ser criada a transação, este método é chamado, de forma a atualizar o montante e a ListView das notas de crédito. Recebe como parâmetro a nota de credito criada (vinda da API).
        internal void AddCreditNoteRowToTable(CreditNote creditNote)
        {
            // Determina o número (digitos) na label com o valor do montante total do utilizador e subtrai-lhe o valor da nota de crédito criada.
            string numberString = new String(amount_value_lable.Text.ToString().Where(Char.IsDigit).ToArray());
            int number = int.Parse(numberString) - Convert.ToInt32(creditNote.amount);
            amount_value_lable.Text = number + " créditos";

            var row = new string[] { creditNote.reference.ToString(), creditNote.amount.ToString(), creditNote.dateExpiry };
            var lvi = new ListViewItem(row);
            lvi.Tag = creditNote;
            if (creditNote.used)
                lvi.BackColor = Color.Red;
            else
                lvi.BackColor = Color.Green;

            creditNotes_listView.Items.Add(lvi);

        }

        // Evento chamado sempre que for selecionada uma row da lista.
        private void creditNotes_listView_KeyUp(object sender, KeyEventArgs e)
        {
            if (sender != creditNotes_listView) return;

            if (e.Control && e.KeyCode == Keys.C)
                CopySelectedValuesToClipboard();
        }

        // Copia a referência da row da listView atualmente selecionada.
        private void CopySelectedValuesToClipboard()
        {
            var builder = new StringBuilder();
            foreach (ListViewItem item in creditNotes_listView.SelectedItems)
            {
                builder.AppendLine(item.SubItems[0].Text);
                break;
            }

            Clipboard.SetText(builder.ToString());
        }

        // Método chamado pelo CreditBankController quando for recebida da API a infromação de que não foi possível criar a nota de crédito com aquele valor.
        internal void UnableToCreateCreditNote()
        {
            errorMessage_label.Text = "Unable to create a credit note!";
            createCredit_button.Text = "Confirm";
            CreateCreditnote_label.Visible = true;
            createCreditNoteValue_TextBox.Visible = true;
            errorMessage_label.Visible = true;
        }

        private void EndSession_button_Click(object sender, EventArgs e)
        {
            Close();
            DialogResult = DialogResult.OK;
        }
    }
}
