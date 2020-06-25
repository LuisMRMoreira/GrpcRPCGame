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
            
            APIGetDataOnLoadRequest?.Invoke(1); // Username

            //APIGetDataOnLoadRequest?.Invoke(2); // CreditNotes by user
            APIGetDataOnLoadRequest?.Invoke(3); // Historic

        }

        private void createCredit_button_Click(object sender, EventArgs e)
        {

            if (createCredit_button.Text == "Confirm")
            {
                // TODO: Criar uma nova creditnote com o valor indicado, caso seja possível
                APICreateCredinote?.Invoke( float.Parse(createCreditNoteValue_TextBox.Text));
                
                createCredit_button.Text = "Create credit";
                CreateCreditnote_label.Visible = false;
                createCreditNoteValue_TextBox.Visible = false;
                errorMessage_label.Visible = false;

            }
            else {

                createCredit_button.Text = "Confirm";

                CreateCreditnote_label.Visible = true;
                createCreditNoteValue_TextBox.Visible = true;
                errorMessage_label.Visible = false;

            }



        }

        private void createCreditNoteValue_TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))//&& (e.KeyChar != '.')
            {
                e.Handled = true;
            }

            //// only allow one decimal point
            //if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            //{
            //    e.Handled = true;
            //}
        }

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

        internal void PopulateUserData(Account account)
        {
            username_label.Text = account.name;

            amount_value_lable.Text = account.amount.ToString() + " créditos" ;

            if (account.notes != null)
                PopulateCreditNoteTable(account.notes);


        }

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


        internal void AddCreditNoteRowToTable(CreditNote creditNote)
        {
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

        private void creditNotes_listView_KeyUp(object sender, KeyEventArgs e)
        {
            if (sender != creditNotes_listView) return;

            if (e.Control && e.KeyCode == Keys.C)
                CopySelectedValuesToClipboard();
        }

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

        internal void UnableToCreateCreditNote()
        {
            errorMessage_label.Text = "Unable to create a credit note!";
            createCredit_button.Text = "Confirm";
            CreateCreditnote_label.Visible = true;
            createCreditNoteValue_TextBox.Visible = true;
            errorMessage_label.Visible = true;
        }
    }
}
