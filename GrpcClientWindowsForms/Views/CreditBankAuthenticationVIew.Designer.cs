namespace GrpcClientWindowsForms.Views
{
    partial class CreditBankAuthenticationVIew
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.password_label = new System.Windows.Forms.Label();
            this.password_textBox = new System.Windows.Forms.TextBox();
            this.username_textBox = new System.Windows.Forms.TextBox();
            this.username_label = new System.Windows.Forms.Label();
            this.cancel_button = new System.Windows.Forms.Button();
            this.login_button = new System.Windows.Forms.Button();
            this.errorMessage_label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(197, 46);
            this.label1.TabIndex = 0;
            this.label1.Text = "CreditBank";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.label2.Location = new System.Drawing.Point(145, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(164, 37);
            this.label2.TabIndex = 0;
            this.label2.Text = "Your choice";
            // 
            // password_label
            // 
            this.password_label.AutoSize = true;
            this.password_label.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.password_label.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.password_label.Location = new System.Drawing.Point(39, 158);
            this.password_label.Name = "password_label";
            this.password_label.Size = new System.Drawing.Size(101, 28);
            this.password_label.TabIndex = 0;
            this.password_label.Text = "Password";
            // 
            // password_textBox
            // 
            this.password_textBox.Location = new System.Drawing.Point(151, 166);
            this.password_textBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.password_textBox.Name = "password_textBox";
            this.password_textBox.PasswordChar = '*';
            this.password_textBox.Size = new System.Drawing.Size(216, 23);
            this.password_textBox.TabIndex = 4;
            // 
            // username_textBox
            // 
            this.username_textBox.Location = new System.Drawing.Point(151, 133);
            this.username_textBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.username_textBox.Name = "username_textBox";
            this.username_textBox.Size = new System.Drawing.Size(216, 23);
            this.username_textBox.TabIndex = 4;
            // 
            // username_label
            // 
            this.username_label.AutoSize = true;
            this.username_label.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.username_label.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.username_label.Location = new System.Drawing.Point(40, 125);
            this.username_label.Name = "username_label";
            this.username_label.Size = new System.Drawing.Size(106, 28);
            this.username_label.TabIndex = 0;
            this.username_label.Text = "Username";
            // 
            // cancel_button
            // 
            this.cancel_button.BackColor = System.Drawing.SystemColors.HotTrack;
            this.cancel_button.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.cancel_button.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.cancel_button.Location = new System.Drawing.Point(63, 246);
            this.cancel_button.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cancel_button.Name = "cancel_button";
            this.cancel_button.Size = new System.Drawing.Size(118, 49);
            this.cancel_button.TabIndex = 0;
            this.cancel_button.Text = "Cancel";
            this.cancel_button.UseVisualStyleBackColor = false;
            this.cancel_button.Visible = false;
            this.cancel_button.Click += new System.EventHandler(this.cancel_button_Click);
            // 
            // login_button
            // 
            this.login_button.BackColor = System.Drawing.SystemColors.HotTrack;
            this.login_button.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.login_button.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.login_button.Location = new System.Drawing.Point(255, 245);
            this.login_button.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.login_button.Name = "login_button";
            this.login_button.Size = new System.Drawing.Size(118, 49);
            this.login_button.TabIndex = 0;
            this.login_button.Text = "Login";
            this.login_button.UseVisualStyleBackColor = false;
            this.login_button.Visible = false;
            this.login_button.Click += new System.EventHandler(this.login_button_Click);
            // 
            // errorMessage_label
            // 
            this.errorMessage_label.AutoSize = true;
            this.errorMessage_label.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.errorMessage_label.ForeColor = System.Drawing.Color.Firebrick;
            this.errorMessage_label.Location = new System.Drawing.Point(44, 213);
            this.errorMessage_label.Name = "errorMessage_label";
            this.errorMessage_label.Size = new System.Drawing.Size(50, 19);
            this.errorMessage_label.TabIndex = 5;
            this.errorMessage_label.Text = "label3";
            this.errorMessage_label.Visible = false;
            // 
            // CreditBankAuthenticationVIew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(741, 450);
            this.Controls.Add(this.errorMessage_label);
            this.Controls.Add(this.login_button);
            this.Controls.Add(this.cancel_button);
            this.Controls.Add(this.username_label);
            this.Controls.Add(this.username_textBox);
            this.Controls.Add(this.password_textBox);
            this.Controls.Add(this.password_label);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "CreditBankAuthenticationVIew";
            this.Text = "CreditBankAuthenticationVIew";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CreditBankAuthenticationVIew_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label password_label;
        private System.Windows.Forms.TextBox password_textBox;
        private System.Windows.Forms.TextBox username_textBox;
        private System.Windows.Forms.Label username_label;
        private System.Windows.Forms.Button cancel_button;
        private System.Windows.Forms.Button login_button;
        private System.Windows.Forms.Label errorMessage_label;
    }
}