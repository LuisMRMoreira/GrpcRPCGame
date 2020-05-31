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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textboxLosses = new System.Windows.Forms.TextBox();
            this.textboxTies = new System.Windows.Forms.TextBox();
            this.textboxWins = new System.Windows.Forms.TextBox();
            this.textboxGamesPlayed = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonPlayPaper
            // 
            this.buttonPlayPaper.Enabled = false;
            this.buttonPlayPaper.Location = new System.Drawing.Point(526, 147);
            this.buttonPlayPaper.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonPlayPaper.Name = "buttonPlayPaper";
            this.buttonPlayPaper.Size = new System.Drawing.Size(98, 35);
            this.buttonPlayPaper.TabIndex = 0;
            this.buttonPlayPaper.Text = "Play Paper";
            this.buttonPlayPaper.UseVisualStyleBackColor = true;
            this.buttonPlayPaper.Click += new System.EventHandler(this.ButtonPlayPaper_Click);
            // 
            // buttonPlayRock
            // 
            this.buttonPlayRock.Enabled = false;
            this.buttonPlayRock.Location = new System.Drawing.Point(526, 85);
            this.buttonPlayRock.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonPlayRock.Name = "buttonPlayRock";
            this.buttonPlayRock.Size = new System.Drawing.Size(98, 35);
            this.buttonPlayRock.TabIndex = 0;
            this.buttonPlayRock.Text = "Play Rock";
            this.buttonPlayRock.UseVisualStyleBackColor = true;
            this.buttonPlayRock.Click += new System.EventHandler(this.ButtonPlayRock_Click);
            // 
            // buttonPlayScissors
            // 
            this.buttonPlayScissors.Enabled = false;
            this.buttonPlayScissors.Location = new System.Drawing.Point(526, 20);
            this.buttonPlayScissors.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonPlayScissors.Name = "buttonPlayScissors";
            this.buttonPlayScissors.Size = new System.Drawing.Size(98, 35);
            this.buttonPlayScissors.TabIndex = 0;
            this.buttonPlayScissors.Text = "Play Scissors";
            this.buttonPlayScissors.UseVisualStyleBackColor = true;
            this.buttonPlayScissors.Click += new System.EventHandler(this.ButtonPlayScissors_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(108, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Client";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(107, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Server";
            // 
            // textboxClientPlay
            // 
            this.textboxClientPlay.Enabled = false;
            this.textboxClientPlay.Location = new System.Drawing.Point(43, 50);
            this.textboxClientPlay.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textboxClientPlay.Name = "textboxClientPlay";
            this.textboxClientPlay.Size = new System.Drawing.Size(171, 23);
            this.textboxClientPlay.TabIndex = 3;
            // 
            // textboxServerPlay
            // 
            this.textboxServerPlay.Enabled = false;
            this.textboxServerPlay.Location = new System.Drawing.Point(43, 110);
            this.textboxServerPlay.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textboxServerPlay.Name = "textboxServerPlay";
            this.textboxServerPlay.Size = new System.Drawing.Size(171, 23);
            this.textboxServerPlay.TabIndex = 3;
            // 
            // labelOutcome
            // 
            this.labelOutcome.AutoSize = true;
            this.labelOutcome.Location = new System.Drawing.Point(95, 146);
            this.labelOutcome.Name = "labelOutcome";
            this.labelOutcome.Size = new System.Drawing.Size(51, 15);
            this.labelOutcome.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textboxServerPlay);
            this.groupBox1.Controls.Add(this.textboxClientPlay);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.labelOutcome);
            this.groupBox1.Location = new System.Drawing.Point(231, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(275, 171);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textboxLosses);
            this.groupBox2.Controls.Add(this.textboxTies);
            this.groupBox2.Controls.Add(this.textboxWins);
            this.groupBox2.Controls.Add(this.textboxGamesPlayed);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(12, 11);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(213, 171);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Stats";
            // 
            // textboxLosses
            // 
            this.textboxLosses.Enabled = false;
            this.textboxLosses.Location = new System.Drawing.Point(107, 143);
            this.textboxLosses.Name = "textboxLosses";
            this.textboxLosses.Size = new System.Drawing.Size(100, 23);
            this.textboxLosses.TabIndex = 9;
            // 
            // textboxTies
            // 
            this.textboxTies.Enabled = false;
            this.textboxTies.Location = new System.Drawing.Point(107, 107);
            this.textboxTies.Name = "textboxTies";
            this.textboxTies.Size = new System.Drawing.Size(100, 23);
            this.textboxTies.TabIndex = 9;
            // 
            // textboxWins
            // 
            this.textboxWins.Enabled = false;
            this.textboxWins.Location = new System.Drawing.Point(107, 71);
            this.textboxWins.Name = "textboxWins";
            this.textboxWins.Size = new System.Drawing.Size(100, 23);
            this.textboxWins.TabIndex = 9;
            // 
            // textboxGamesPlayed
            // 
            this.textboxGamesPlayed.Enabled = false;
            this.textboxGamesPlayed.Location = new System.Drawing.Point(107, 32);
            this.textboxGamesPlayed.Name = "textboxGamesPlayed";
            this.textboxGamesPlayed.Size = new System.Drawing.Size(100, 23);
            this.textboxGamesPlayed.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 146);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 15);
            this.label6.TabIndex = 8;
            this.label6.Text = "Losses";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 110);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 15);
            this.label5.TabIndex = 7;
            this.label5.Text = "Ties";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "Games Played";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Wins";
            // 
            // PlayView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(651, 193);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonPlayScissors);
            this.Controls.Add(this.buttonPlayRock);
            this.Controls.Add(this.buttonPlayPaper);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "PlayView";
            this.Text = "Paper, Rock and Scissors";
            this.Load += new System.EventHandler(this.PlayView_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textboxLosses;
        private System.Windows.Forms.TextBox textboxTies;
        private System.Windows.Forms.TextBox textboxWins;
        private System.Windows.Forms.TextBox textboxGamesPlayed;
    }
}