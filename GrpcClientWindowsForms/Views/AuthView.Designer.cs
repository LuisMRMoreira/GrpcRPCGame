namespace GrpcClientWindowsForms.Views
{
    partial class AuthView
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
            this.buttonRegister = new System.Windows.Forms.Button();
            this.buttonLogin = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonPlay = new System.Windows.Forms.Button();
            this.labelWelcome = new System.Windows.Forms.Label();
            this.textboxWelcome = new System.Windows.Forms.TextBox();
            this.labelOutcome = new System.Windows.Forms.Label();
            this.Button_gotoCreditBank = new System.Windows.Forms.Button();
            this.reference_textBox = new System.Windows.Forms.TextBox();
            this.insertReference_label = new System.Windows.Forms.Label();
            this.invalidReference_label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonRegister
            // 
            this.buttonRegister.Location = new System.Drawing.Point(103, 194);
            this.buttonRegister.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonRegister.Name = "buttonRegister";
            this.buttonRegister.Size = new System.Drawing.Size(118, 49);
            this.buttonRegister.TabIndex = 0;
            this.buttonRegister.Text = "Register";
            this.buttonRegister.UseVisualStyleBackColor = true;
            this.buttonRegister.Click += new System.EventHandler(this.ButtonRegister_Click);
            // 
            // buttonLogin
            // 
            this.buttonLogin.Location = new System.Drawing.Point(251, 194);
            this.buttonLogin.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(118, 49);
            this.buttonLogin.TabIndex = 0;
            this.buttonLogin.Text = "Login";
            this.buttonLogin.UseVisualStyleBackColor = true;
            this.buttonLogin.Click += new System.EventHandler(this.ButtonLogin_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 17);
            this.label1.TabIndex = 0;
            // 
            // buttonPlay
            // 
            this.buttonPlay.Location = new System.Drawing.Point(100, 192);
            this.buttonPlay.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonPlay.Name = "buttonPlay";
            this.buttonPlay.Size = new System.Drawing.Size(118, 49);
            this.buttonPlay.TabIndex = 0;
            this.buttonPlay.Text = "Play";
            this.buttonPlay.UseVisualStyleBackColor = true;
            this.buttonPlay.Visible = false;
            this.buttonPlay.Click += new System.EventHandler(this.ButtonPlay_Click);
            // 
            // labelWelcome
            // 
            this.labelWelcome.AutoSize = true;
            this.labelWelcome.Location = new System.Drawing.Point(201, 55);
            this.labelWelcome.Name = "labelWelcome";
            this.labelWelcome.Size = new System.Drawing.Size(57, 15);
            this.labelWelcome.TabIndex = 1;
            this.labelWelcome.Text = "Welcome";
            // 
            // textboxWelcome
            // 
            this.textboxWelcome.Enabled = false;
            this.textboxWelcome.Location = new System.Drawing.Point(153, 83);
            this.textboxWelcome.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textboxWelcome.Name = "textboxWelcome";
            this.textboxWelcome.Size = new System.Drawing.Size(159, 23);
            this.textboxWelcome.TabIndex = 2;
            // 
            // labelOutcome
            // 
            this.labelOutcome.AutoSize = true;
            this.labelOutcome.Location = new System.Drawing.Point(212, 120);
            this.labelOutcome.Name = "labelOutcome";
            this.labelOutcome.Size = new System.Drawing.Size(0, 15);
            this.labelOutcome.TabIndex = 3;
            this.labelOutcome.Visible = false;
            // 
            // Button_gotoCreditBank
            // 
            this.Button_gotoCreditBank.Location = new System.Drawing.Point(248, 192);
            this.Button_gotoCreditBank.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Button_gotoCreditBank.Name = "Button_gotoCreditBank";
            this.Button_gotoCreditBank.Size = new System.Drawing.Size(118, 49);
            this.Button_gotoCreditBank.TabIndex = 0;
            this.Button_gotoCreditBank.Text = "Credit bank";
            this.Button_gotoCreditBank.UseVisualStyleBackColor = true;
            this.Button_gotoCreditBank.Visible = false;
            this.Button_gotoCreditBank.Click += new System.EventHandler(this.Button_gotoCreditBank_Click);
            // 
            // reference_textBox
            // 
            this.reference_textBox.Location = new System.Drawing.Point(154, 149);
            this.reference_textBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.reference_textBox.Name = "reference_textBox";
            this.reference_textBox.Size = new System.Drawing.Size(159, 23);
            this.reference_textBox.TabIndex = 2;
            this.reference_textBox.Visible = false;
            // 
            // insertReference_label
            // 
            this.insertReference_label.AutoSize = true;
            this.insertReference_label.ForeColor = System.Drawing.Color.Maroon;
            this.insertReference_label.Location = new System.Drawing.Point(56, 124);
            this.insertReference_label.Name = "insertReference_label";
            this.insertReference_label.Size = new System.Drawing.Size(359, 15);
            this.insertReference_label.TabIndex = 1;
            this.insertReference_label.Text = "In order to play, please, isnert a valid reference (amount: 20 credits)";
            this.insertReference_label.Visible = false;
            // 
            // invalidReference_label
            // 
            this.invalidReference_label.AutoSize = true;
            this.invalidReference_label.ForeColor = System.Drawing.Color.Maroon;
            this.invalidReference_label.Location = new System.Drawing.Point(4, 11);
            this.invalidReference_label.Name = "invalidReference_label";
            this.invalidReference_label.Size = new System.Drawing.Size(185, 15);
            this.invalidReference_label.TabIndex = 1;
            this.invalidReference_label.Text = "Invalid reference. Please try again.";
            this.invalidReference_label.Visible = false;
            // 
            // AuthView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(505, 255);
            this.Controls.Add(this.invalidReference_label);
            this.Controls.Add(this.insertReference_label);
            this.Controls.Add(this.reference_textBox);
            this.Controls.Add(this.Button_gotoCreditBank);
            this.Controls.Add(this.labelOutcome);
            this.Controls.Add(this.textboxWelcome);
            this.Controls.Add(this.labelWelcome);
            this.Controls.Add(this.buttonPlay);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonLogin);
            this.Controls.Add(this.buttonRegister);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "AuthView";
            this.Text = "Authentication";
            this.Load += new System.EventHandler(this.AuthView_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonRegister;
        private System.Windows.Forms.Button buttonLogin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonPlay;
        private System.Windows.Forms.Label labelWelcome;
        private System.Windows.Forms.TextBox textboxWelcome;
        private System.Windows.Forms.Label labelOutcome;
        private System.Windows.Forms.Button Button_gotoCreditBank;
        private System.Windows.Forms.TextBox reference_textBox;
        private System.Windows.Forms.Label insertReference_label;
        private System.Windows.Forms.Label invalidReference_label;
    }
}