namespace GrpcClientWindowsForms.Views
{
    partial class CreditBankMenuView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.ColumnHeader ToReferenceColumn;
            this.Bank_name_label = new System.Windows.Forms.Label();
            this.credit_bank_logo_lable = new System.Windows.Forms.Label();
            this.username_label = new System.Windows.Forms.Label();
            this.sr_label = new System.Windows.Forms.Label();
            this.amount_value_lable = new System.Windows.Forms.Label();
            this.amount_lable = new System.Windows.Forms.Label();
            this.historicTable_lable = new System.Windows.Forms.Label();
            this.credinotesTable_lable = new System.Windows.Forms.Label();
            this.createCredit_button = new System.Windows.Forms.Button();
            this.EndSession_button = new System.Windows.Forms.Button();
            this.createCreditNoteValue_TextBox = new System.Windows.Forms.TextBox();
            this.CreateCreditnote_label = new System.Windows.Forms.Label();
            this.errorMessage_label = new System.Windows.Forms.Label();
            this.historic_listView = new System.Windows.Forms.ListView();
            this.amountColumn = new System.Windows.Forms.ColumnHeader("(none)");
            this.DateColumn = new System.Windows.Forms.ColumnHeader();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.creditNotes_listView = new System.Windows.Forms.ListView();
            this.referenceColumn = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.expirationDateColumn = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.FromcolumnHeader = new System.Windows.Forms.ColumnHeader();
            ToReferenceColumn = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // ToReferenceColumn
            // 
            ToReferenceColumn.Name = "ToReferenceColumn";
            ToReferenceColumn.Text = "To";
            ToReferenceColumn.Width = 110;
            // 
            // Bank_name_label
            // 
            this.Bank_name_label.AutoSize = true;
            this.Bank_name_label.Font = new System.Drawing.Font("Segoe UI", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Bank_name_label.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.Bank_name_label.Location = new System.Drawing.Point(16, 17);
            this.Bank_name_label.Name = "Bank_name_label";
            this.Bank_name_label.Size = new System.Drawing.Size(197, 46);
            this.Bank_name_label.TabIndex = 0;
            this.Bank_name_label.Text = "CreditBank";
            // 
            // credit_bank_logo_lable
            // 
            this.credit_bank_logo_lable.AutoSize = true;
            this.credit_bank_logo_lable.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.credit_bank_logo_lable.ForeColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.credit_bank_logo_lable.Location = new System.Drawing.Point(149, 55);
            this.credit_bank_logo_lable.Name = "credit_bank_logo_lable";
            this.credit_bank_logo_lable.Size = new System.Drawing.Size(164, 37);
            this.credit_bank_logo_lable.TabIndex = 0;
            this.credit_bank_logo_lable.Text = "Your choice";
            // 
            // username_label
            // 
            this.username_label.AutoSize = true;
            this.username_label.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.username_label.ForeColor = System.Drawing.Color.SteelBlue;
            this.username_label.Location = new System.Drawing.Point(550, 17);
            this.username_label.Name = "username_label";
            this.username_label.Size = new System.Drawing.Size(80, 19);
            this.username_label.TabIndex = 0;
            this.username_label.Text = "User name";
            // 
            // sr_label
            // 
            this.sr_label.AutoSize = true;
            this.sr_label.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.sr_label.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.sr_label.Location = new System.Drawing.Point(512, 9);
            this.sr_label.Name = "sr_label";
            this.sr_label.Size = new System.Drawing.Size(40, 28);
            this.sr_label.TabIndex = 0;
            this.sr_label.Text = "Sr. ";
            // 
            // amount_value_lable
            // 
            this.amount_value_lable.AutoSize = true;
            this.amount_value_lable.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.amount_value_lable.ForeColor = System.Drawing.Color.SteelBlue;
            this.amount_value_lable.Location = new System.Drawing.Point(616, 55);
            this.amount_value_lable.Name = "amount_value_lable";
            this.amount_value_lable.Size = new System.Drawing.Size(29, 19);
            this.amount_value_lable.TabIndex = 0;
            this.amount_value_lable.Text = "1 €";
            // 
            // amount_lable
            // 
            this.amount_lable.AutoSize = true;
            this.amount_lable.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.amount_lable.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.amount_lable.Location = new System.Drawing.Point(513, 47);
            this.amount_lable.Name = "amount_lable";
            this.amount_lable.Size = new System.Drawing.Size(93, 28);
            this.amount_lable.TabIndex = 0;
            this.amount_lable.Text = "Amount:";
            // 
            // historicTable_lable
            // 
            this.historicTable_lable.AutoSize = true;
            this.historicTable_lable.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.historicTable_lable.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.historicTable_lable.Location = new System.Drawing.Point(22, 130);
            this.historicTable_lable.Name = "historicTable_lable";
            this.historicTable_lable.Size = new System.Drawing.Size(86, 28);
            this.historicTable_lable.TabIndex = 0;
            this.historicTable_lable.Text = "Historic";
            // 
            // credinotesTable_lable
            // 
            this.credinotesTable_lable.AutoSize = true;
            this.credinotesTable_lable.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.credinotesTable_lable.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.credinotesTable_lable.Location = new System.Drawing.Point(446, 130);
            this.credinotesTable_lable.Name = "credinotesTable_lable";
            this.credinotesTable_lable.Size = new System.Drawing.Size(113, 28);
            this.credinotesTable_lable.TabIndex = 0;
            this.credinotesTable_lable.Text = "Credinotes";
            // 
            // createCredit_button
            // 
            this.createCredit_button.BackColor = System.Drawing.SystemColors.HotTrack;
            this.createCredit_button.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.createCredit_button.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.createCredit_button.Location = new System.Drawing.Point(747, 277);
            this.createCredit_button.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.createCredit_button.Name = "createCredit_button";
            this.createCredit_button.Size = new System.Drawing.Size(118, 49);
            this.createCredit_button.TabIndex = 0;
            this.createCredit_button.Text = "Create credit";
            this.createCredit_button.UseVisualStyleBackColor = false;
            this.createCredit_button.Click += new System.EventHandler(this.createCredit_button_Click);
            // 
            // EndSession_button
            // 
            this.EndSession_button.BackColor = System.Drawing.SystemColors.HotTrack;
            this.EndSession_button.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.EndSession_button.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.EndSession_button.Location = new System.Drawing.Point(747, 337);
            this.EndSession_button.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.EndSession_button.Name = "EndSession_button";
            this.EndSession_button.Size = new System.Drawing.Size(118, 49);
            this.EndSession_button.TabIndex = 0;
            this.EndSession_button.Text = "End session";
            this.EndSession_button.UseVisualStyleBackColor = false;
            this.EndSession_button.Click += new System.EventHandler(this.createCredit_button_Click);
            // 
            // createCreditNoteValue_TextBox
            // 
            this.createCreditNoteValue_TextBox.Location = new System.Drawing.Point(814, 201);
            this.createCreditNoteValue_TextBox.Name = "createCreditNoteValue_TextBox";
            this.createCreditNoteValue_TextBox.Size = new System.Drawing.Size(51, 23);
            this.createCreditNoteValue_TextBox.TabIndex = 3;
            this.createCreditNoteValue_TextBox.Visible = false;
            this.createCreditNoteValue_TextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.createCreditNoteValue_TextBox_KeyPress);
            // 
            // CreateCreditnote_label
            // 
            this.CreateCreditnote_label.AutoSize = true;
            this.CreateCreditnote_label.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.CreateCreditnote_label.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.CreateCreditnote_label.Location = new System.Drawing.Point(739, 199);
            this.CreateCreditnote_label.Name = "CreateCreditnote_label";
            this.CreateCreditnote_label.Size = new System.Drawing.Size(66, 19);
            this.CreateCreditnote_label.TabIndex = 0;
            this.CreateCreditnote_label.Text = "Amount:";
            this.CreateCreditnote_label.Visible = false;
            // 
            // errorMessage_label
            // 
            this.errorMessage_label.AutoSize = true;
            this.errorMessage_label.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.errorMessage_label.ForeColor = System.Drawing.Color.Firebrick;
            this.errorMessage_label.Location = new System.Drawing.Point(742, 234);
            this.errorMessage_label.Name = "errorMessage_label";
            this.errorMessage_label.Size = new System.Drawing.Size(106, 19);
            this.errorMessage_label.TabIndex = 5;
            this.errorMessage_label.Text = "error message";
            this.errorMessage_label.Visible = false;
            // 
            // historic_listView
            // 
            this.historic_listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.FromcolumnHeader,
            ToReferenceColumn,
            this.amountColumn,
            this.DateColumn});
            this.historic_listView.FullRowSelect = true;
            this.historic_listView.GridLines = true;
            this.historic_listView.HideSelection = false;
            this.historic_listView.Location = new System.Drawing.Point(24, 164);
            this.historic_listView.Name = "historic_listView";
            this.historic_listView.Size = new System.Drawing.Size(384, 255);
            this.historic_listView.TabIndex = 6;
            this.historic_listView.UseCompatibleStateImageBehavior = false;
            this.historic_listView.View = System.Windows.Forms.View.Details;
            // 
            // amountColumn
            // 
            this.amountColumn.Name = "amountColumn";
            this.amountColumn.Text = "Amount";
            // 
            // DateColumn
            // 
            this.DateColumn.Name = "DateColumn";
            this.DateColumn.Text = "Date";
            this.DateColumn.Width = 100;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Name = "columnHeader3";
            this.columnHeader3.Text = "Amount";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Name = "columnHeader4";
            this.columnHeader4.Text = "Date";
            // 
            // creditNotes_listView
            // 
            this.creditNotes_listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.referenceColumn,
            this.columnHeader6,
            this.expirationDateColumn});
            this.creditNotes_listView.FullRowSelect = true;
            this.creditNotes_listView.GridLines = true;
            this.creditNotes_listView.HideSelection = false;
            this.creditNotes_listView.Location = new System.Drawing.Point(446, 164);
            this.creditNotes_listView.Name = "creditNotes_listView";
            this.creditNotes_listView.Size = new System.Drawing.Size(276, 255);
            this.creditNotes_listView.TabIndex = 6;
            this.creditNotes_listView.UseCompatibleStateImageBehavior = false;
            this.creditNotes_listView.View = System.Windows.Forms.View.Details;
            this.creditNotes_listView.KeyUp += new System.Windows.Forms.KeyEventHandler(this.creditNotes_listView_KeyUp);
            // 
            // referenceColumn
            // 
            this.referenceColumn.Name = "referenceColumn";
            this.referenceColumn.Text = "Reference";
            this.referenceColumn.Width = 120;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Name = "amountColumn";
            this.columnHeader6.Text = "Amount";
            // 
            // expirationDateColumn
            // 
            this.expirationDateColumn.Name = "expirationDateColumn";
            this.expirationDateColumn.Text = "Expiration";
            this.expirationDateColumn.Width = 100;
            // 
            // FromcolumnHeader
            // 
            this.FromcolumnHeader.Name = "FromcolumnHeader";
            this.FromcolumnHeader.Text = "From";
            this.FromcolumnHeader.Width = 110;
            // 
            // CreditBankMenuView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(885, 450);
            this.Controls.Add(this.creditNotes_listView);
            this.Controls.Add(this.historic_listView);
            this.Controls.Add(this.errorMessage_label);
            this.Controls.Add(this.CreateCreditnote_label);
            this.Controls.Add(this.createCreditNoteValue_TextBox);
            this.Controls.Add(this.EndSession_button);
            this.Controls.Add(this.createCredit_button);
            this.Controls.Add(this.credinotesTable_lable);
            this.Controls.Add(this.historicTable_lable);
            this.Controls.Add(this.amount_lable);
            this.Controls.Add(this.amount_value_lable);
            this.Controls.Add(this.sr_label);
            this.Controls.Add(this.username_label);
            this.Controls.Add(this.credit_bank_logo_lable);
            this.Controls.Add(this.Bank_name_label);
            this.Name = "CreditBankMenuView";
            this.Text = "CreditBankMenuView";
            this.Load += new System.EventHandler(this.CreditBankMenuView_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Bank_name_label;
        private System.Windows.Forms.Label credit_bank_logo_lable;
        private System.Windows.Forms.Label username_label;
        private System.Windows.Forms.Label sr_label;
        private System.Windows.Forms.Label amount_value_lable;
        private System.Windows.Forms.Label amount_lable;
        private System.Windows.Forms.Label historicTable_lable;
        private System.Windows.Forms.Label credinotesTable_lable;
        private System.Windows.Forms.Button createCredit_button;
        private System.Windows.Forms.Button EndSession_button;
        private System.Windows.Forms.TextBox createCreditNoteValue_TextBox;
        private System.Windows.Forms.Label CreateCreditnote_label;
        private System.Windows.Forms.Label errorMessage_label;
        private System.Windows.Forms.ListView historic_listView;
        private System.Windows.Forms.ColumnHeader amountColumn;
        private System.Windows.Forms.ColumnHeader DateColumn;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ListView creditNotes_listView;
        private System.Windows.Forms.ColumnHeader referenceColumn;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader expirationDateColumn;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader FromcolumnHeader;
    }
}