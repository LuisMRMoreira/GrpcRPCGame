namespace GrpcClientWindowsForms.Views
{
    partial class PlayView
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
            this.buttonPlayPaper = new System.Windows.Forms.Button();
            this.buttonPlayRock = new System.Windows.Forms.Button();
            this.buttonPlayScissors = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textboxClientPlay = new System.Windows.Forms.TextBox();
            this.textboxServerPlay = new System.Windows.Forms.TextBox();
            this.labelOutcome = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonPlayPaper
            // 
            this.buttonPlayPaper.Enabled = false;
            this.buttonPlayPaper.Location = new System.Drawing.Point(12, 130);
            this.buttonPlayPaper.Name = "buttonPlayPaper";
            this.buttonPlayPaper.Size = new System.Drawing.Size(112, 47);
            this.buttonPlayPaper.TabIndex = 0;
            this.buttonPlayPaper.Text = "Play Paper";
            this.buttonPlayPaper.UseVisualStyleBackColor = true;
            this.buttonPlayPaper.Click += new System.EventHandler(this.buttonPlayPaper_Click);
            // 
            // buttonPlayRock
            // 
            this.buttonPlayRock.Enabled = false;
            this.buttonPlayRock.Location = new System.Drawing.Point(130, 130);
            this.buttonPlayRock.Name = "buttonPlayRock";
            this.buttonPlayRock.Size = new System.Drawing.Size(112, 47);
            this.buttonPlayRock.TabIndex = 0;
            this.buttonPlayRock.Text = "Play Rock";
            this.buttonPlayRock.UseVisualStyleBackColor = true;
            this.buttonPlayRock.Click += new System.EventHandler(this.buttonPlayRock_Click);
            // 
            // buttonPlayScissors
            // 
            this.buttonPlayScissors.Enabled = false;
            this.buttonPlayScissors.Location = new System.Drawing.Point(248, 130);
            this.buttonPlayScissors.Name = "buttonPlayScissors";
            this.buttonPlayScissors.Size = new System.Drawing.Size(112, 47);
            this.buttonPlayScissors.TabIndex = 0;
            this.buttonPlayScissors.Text = "Play Scissors";
            this.buttonPlayScissors.UseVisualStyleBackColor = true;
            this.buttonPlayScissors.Click += new System.EventHandler(this.buttonPlayScissors_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Client";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Server";
            // 
            // textboxClientPlay
            // 
            this.textboxClientPlay.Enabled = false;
            this.textboxClientPlay.Location = new System.Drawing.Point(118, 19);
            this.textboxClientPlay.Name = "textboxClientPlay";
            this.textboxClientPlay.Size = new System.Drawing.Size(195, 27);
            this.textboxClientPlay.TabIndex = 3;
            // 
            // textboxServerPlay
            // 
            this.textboxServerPlay.Enabled = false;
            this.textboxServerPlay.Location = new System.Drawing.Point(118, 52);
            this.textboxServerPlay.Name = "textboxServerPlay";
            this.textboxServerPlay.Size = new System.Drawing.Size(195, 27);
            this.textboxServerPlay.TabIndex = 3;
            // 
            // labelOutcome
            // 
            this.labelOutcome.AutoSize = true;
            this.labelOutcome.Location = new System.Drawing.Point(78, 94);
            this.labelOutcome.Name = "labelOutcome";
            this.labelOutcome.Size = new System.Drawing.Size(0, 20);
            this.labelOutcome.TabIndex = 4;
            // 
            // PlayView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 232);
            this.Controls.Add(this.labelOutcome);
            this.Controls.Add(this.textboxServerPlay);
            this.Controls.Add(this.textboxClientPlay);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonPlayScissors);
            this.Controls.Add(this.buttonPlayRock);
            this.Controls.Add(this.buttonPlayPaper);
            this.Name = "PlayView";
            this.Text = "Paper, Rock and Scissors";
            this.Load += new System.EventHandler(this.PlayView_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonPlayPaper;
        private System.Windows.Forms.Button buttonPlayRock;
        private System.Windows.Forms.Button buttonPlayScissors;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textboxClientPlay;
        private System.Windows.Forms.TextBox textboxServerPlay;
        private System.Windows.Forms.Label labelOutcome;
    }
}