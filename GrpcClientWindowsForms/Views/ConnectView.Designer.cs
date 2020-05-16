namespace GrpcClientWindowsForms.Views
{
    partial class ConnectView
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
            this.textboxServerAddress = new System.Windows.Forms.TextBox();
            this.labelOutcome = new System.Windows.Forms.Label();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.buttonContinue = new System.Windows.Forms.Button();
            this.buttonRestart = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(210, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Server Address";
            // 
            // textboxServerAddress
            // 
            this.textboxServerAddress.Location = new System.Drawing.Point(161, 46);
            this.textboxServerAddress.Name = "textboxServerAddress";
            this.textboxServerAddress.Size = new System.Drawing.Size(196, 27);
            this.textboxServerAddress.TabIndex = 1;
            this.textboxServerAddress.TextChanged += new System.EventHandler(this.TextboxServerAddress_TextChanged);
            // 
            // labelOutcome
            // 
            this.labelOutcome.AutoSize = true;
            this.labelOutcome.Location = new System.Drawing.Point(214, 91);
            this.labelOutcome.Name = "labelOutcome";
            this.labelOutcome.Size = new System.Drawing.Size(103, 20);
            this.labelOutcome.TabIndex = 2;
            this.labelOutcome.Text = "labelOutcome";
            this.labelOutcome.Visible = false;
            // 
            // buttonConnect
            // 
            this.buttonConnect.Enabled = false;
            this.buttonConnect.Location = new System.Drawing.Point(199, 148);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(127, 61);
            this.buttonConnect.TabIndex = 3;
            this.buttonConnect.Text = "Connect";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.ButtonConnect_Click);
            // 
            // buttonContinue
            // 
            this.buttonContinue.Enabled = false;
            this.buttonContinue.Location = new System.Drawing.Point(282, 148);
            this.buttonContinue.Name = "buttonContinue";
            this.buttonContinue.Size = new System.Drawing.Size(118, 61);
            this.buttonContinue.TabIndex = 4;
            this.buttonContinue.Text = "Continue";
            this.buttonContinue.UseVisualStyleBackColor = true;
            this.buttonContinue.Visible = false;
            this.buttonContinue.Click += new System.EventHandler(this.ButtonContinue_Click);
            // 
            // buttonRestart
            // 
            this.buttonRestart.Enabled = false;
            this.buttonRestart.Location = new System.Drawing.Point(143, 148);
            this.buttonRestart.Name = "buttonRestart";
            this.buttonRestart.Size = new System.Drawing.Size(118, 61);
            this.buttonRestart.TabIndex = 4;
            this.buttonRestart.Text = "New Server Address";
            this.buttonRestart.UseVisualStyleBackColor = true;
            this.buttonRestart.Visible = false;
            this.buttonRestart.Click += new System.EventHandler(this.ButtonRestart_Click);
            // 
            // ConnectView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 265);
            this.Controls.Add(this.buttonRestart);
            this.Controls.Add(this.buttonContinue);
            this.Controls.Add(this.buttonConnect);
            this.Controls.Add(this.labelOutcome);
            this.Controls.Add(this.textboxServerAddress);
            this.Controls.Add(this.label1);
            this.Name = "ConnectView";
            this.Text = "Connect to Server";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textboxServerAddress;
        private System.Windows.Forms.Label labelOutcome;
        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.Button buttonContinue;
        private System.Windows.Forms.Button buttonRestart;
    }
}