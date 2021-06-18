using Skaterboy.Properties;

namespace Skaterboy
{
    partial class GAME
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GAME));
            this.PCpic = new System.Windows.Forms.PictureBox();
            this.lblNaam = new System.Windows.Forms.Label();
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.btnEXIT = new System.Windows.Forms.Button();
            this.btnAdmin = new System.Windows.Forms.Button();
            this.btnCustom = new System.Windows.Forms.Button();
            this.btnMijnAccount = new System.Windows.Forms.Button();
            this.btnScores = new System.Windows.Forms.Button();
            this.btnNieuweGame = new System.Windows.Forms.Button();
            this.TmrOpkomen = new System.Windows.Forms.Timer(this.components);
            this.tmrVoorGame = new System.Windows.Forms.Timer(this.components);
            this.tmrScore = new System.Windows.Forms.Timer(this.components);
            this.button2 = new System.Windows.Forms.Button();
            this.lblVerloren = new System.Windows.Forms.Label();
            this.lblVerlorenScore = new System.Windows.Forms.Label();
            this.tmrStartSpring = new System.Windows.Forms.Timer(this.components);
            this.btnHerbegin = new System.Windows.Forms.Button();
            this.pnlGame = new System.Windows.Forms.Panel();
            this.btnTerug = new System.Windows.Forms.Button();
            this.lblDatum = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PCpic)).BeginInit();
            this.pnlMenu.SuspendLayout();
            this.pnlGame.SuspendLayout();
            this.SuspendLayout();
            // 
            // PCpic
            // 
            this.PCpic.Location = new System.Drawing.Point(735, 9);
            this.PCpic.Name = "PCpic";
            this.PCpic.Size = new System.Drawing.Size(53, 52);
            this.PCpic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PCpic.TabIndex = 1;
            this.PCpic.TabStop = false;
            // 
            // lblNaam
            // 
            this.lblNaam.AutoSize = true;
            this.lblNaam.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNaam.ForeColor = System.Drawing.Color.Black;
            this.lblNaam.Location = new System.Drawing.Point(150, 9);
            this.lblNaam.Name = "lblNaam";
            this.lblNaam.Size = new System.Drawing.Size(92, 31);
            this.lblNaam.TabIndex = 0;
            this.lblNaam.Text = "label1";
            // 
            // pnlMenu
            // 
            this.pnlMenu.BackColor = System.Drawing.Color.Purple;
            this.pnlMenu.Controls.Add(this.btnEXIT);
            this.pnlMenu.Controls.Add(this.btnAdmin);
            this.pnlMenu.Controls.Add(this.btnCustom);
            this.pnlMenu.Controls.Add(this.btnMijnAccount);
            this.pnlMenu.Controls.Add(this.btnScores);
            this.pnlMenu.Controls.Add(this.btnNieuweGame);
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlMenu.Location = new System.Drawing.Point(0, 0);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(146, 450);
            this.pnlMenu.TabIndex = 1;
            // 
            // btnEXIT
            // 
            this.btnEXIT.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnEXIT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEXIT.ForeColor = System.Drawing.Color.White;
            this.btnEXIT.Location = new System.Drawing.Point(3, 379);
            this.btnEXIT.Name = "btnEXIT";
            this.btnEXIT.Size = new System.Drawing.Size(141, 68);
            this.btnEXIT.TabIndex = 5;
            this.btnEXIT.Text = "GAME VERLATEN";
            this.btnEXIT.UseVisualStyleBackColor = true;
            this.btnEXIT.Click += new System.EventHandler(this.btnEXIT_Click);
            // 
            // btnAdmin
            // 
            this.btnAdmin.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnAdmin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdmin.ForeColor = System.Drawing.Color.White;
            this.btnAdmin.Location = new System.Drawing.Point(2, 305);
            this.btnAdmin.Name = "btnAdmin";
            this.btnAdmin.Size = new System.Drawing.Size(141, 68);
            this.btnAdmin.TabIndex = 4;
            this.btnAdmin.Text = "ADMIN";
            this.btnAdmin.UseVisualStyleBackColor = true;
            this.btnAdmin.Click += new System.EventHandler(this.btnAdmin_Click);
            // 
            // btnCustom
            // 
            this.btnCustom.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnCustom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCustom.ForeColor = System.Drawing.Color.White;
            this.btnCustom.Location = new System.Drawing.Point(2, 231);
            this.btnCustom.Name = "btnCustom";
            this.btnCustom.Size = new System.Drawing.Size(141, 68);
            this.btnCustom.TabIndex = 3;
            this.btnCustom.Text = "SETTINGS";
            this.btnCustom.UseVisualStyleBackColor = true;
            this.btnCustom.Click += new System.EventHandler(this.btnCustom_Click);
            // 
            // btnMijnAccount
            // 
            this.btnMijnAccount.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnMijnAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMijnAccount.ForeColor = System.Drawing.Color.White;
            this.btnMijnAccount.Location = new System.Drawing.Point(2, 157);
            this.btnMijnAccount.Name = "btnMijnAccount";
            this.btnMijnAccount.Size = new System.Drawing.Size(141, 68);
            this.btnMijnAccount.TabIndex = 2;
            this.btnMijnAccount.Text = "ACCOUNT";
            this.btnMijnAccount.UseVisualStyleBackColor = true;
            this.btnMijnAccount.Click += new System.EventHandler(this.btnMijnAccount_Click);
            // 
            // btnScores
            // 
            this.btnScores.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnScores.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnScores.ForeColor = System.Drawing.Color.White;
            this.btnScores.Location = new System.Drawing.Point(3, 83);
            this.btnScores.Name = "btnScores";
            this.btnScores.Size = new System.Drawing.Size(141, 68);
            this.btnScores.TabIndex = 1;
            this.btnScores.Text = "HIGH SCORES";
            this.btnScores.UseVisualStyleBackColor = true;
            this.btnScores.Click += new System.EventHandler(this.btnScores_Click);
            // 
            // btnNieuweGame
            // 
            this.btnNieuweGame.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnNieuweGame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNieuweGame.ForeColor = System.Drawing.Color.White;
            this.btnNieuweGame.Location = new System.Drawing.Point(3, 9);
            this.btnNieuweGame.Name = "btnNieuweGame";
            this.btnNieuweGame.Size = new System.Drawing.Size(141, 68);
            this.btnNieuweGame.TabIndex = 0;
            this.btnNieuweGame.Text = "NIEUWE GAME";
            this.btnNieuweGame.UseVisualStyleBackColor = true;
            this.btnNieuweGame.Click += new System.EventHandler(this.button1_Click);
            // 
            // TmrOpkomen
            // 
            this.TmrOpkomen.Interval = 1;
            this.TmrOpkomen.Tick += new System.EventHandler(this.TmrOpkomen_Tick);
            // 
            // tmrVoorGame
            // 
            this.tmrVoorGame.Interval = 50;
            this.tmrVoorGame.Tick += new System.EventHandler(this.tmrVoorGame_Tick);
            // 
            // tmrScore
            // 
            this.tmrScore.Interval = 1000;
            this.tmrScore.Tick += new System.EventHandler(this.tmrScore_Tick);
            // 
            // button2
            // 
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(789, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(10, 10);
            this.button2.TabIndex = 9;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // lblVerloren
            // 
            this.lblVerloren.AutoSize = true;
            this.lblVerloren.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVerloren.Location = new System.Drawing.Point(83, 68);
            this.lblVerloren.Name = "lblVerloren";
            this.lblVerloren.Size = new System.Drawing.Size(608, 108);
            this.lblVerloren.TabIndex = 10;
            this.lblVerloren.Text = "VERLOREN!";
            this.lblVerloren.Visible = false;
            // 
            // lblVerlorenScore
            // 
            this.lblVerlorenScore.AutoSize = true;
            this.lblVerlorenScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVerlorenScore.Location = new System.Drawing.Point(278, 176);
            this.lblVerlorenScore.Name = "lblVerlorenScore";
            this.lblVerlorenScore.Size = new System.Drawing.Size(133, 25);
            this.lblVerlorenScore.TabIndex = 11;
            this.lblVerlorenScore.Text = "Jouw score: ";
            this.lblVerlorenScore.Visible = false;
            // 
            // tmrStartSpring
            // 
            this.tmrStartSpring.Interval = 50;
            this.tmrStartSpring.Tick += new System.EventHandler(this.tmrStartSpring_Tick);
            // 
            // btnHerbegin
            // 
            this.btnHerbegin.Location = new System.Drawing.Point(309, 204);
            this.btnHerbegin.Name = "btnHerbegin";
            this.btnHerbegin.Size = new System.Drawing.Size(85, 76);
            this.btnHerbegin.TabIndex = 12;
            this.btnHerbegin.Text = "HERBEGIN";
            this.btnHerbegin.UseVisualStyleBackColor = true;
            this.btnHerbegin.Click += new System.EventHandler(this.btnHerbegin_Click);
            // 
            // pnlGame
            // 
            this.pnlGame.BackColor = System.Drawing.SystemColors.Control;
            this.pnlGame.Controls.Add(this.btnTerug);
            this.pnlGame.Controls.Add(this.btnHerbegin);
            this.pnlGame.Controls.Add(this.lblDatum);
            this.pnlGame.Controls.Add(this.pnlMenu);
            this.pnlGame.Location = new System.Drawing.Point(-11, 0);
            this.pnlGame.Name = "pnlGame";
            this.pnlGame.Size = new System.Drawing.Size(810, 450);
            this.pnlGame.TabIndex = 13;
            this.pnlGame.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlGame_Paint);
            // 
            // btnTerug
            // 
            this.btnTerug.Location = new System.Drawing.Point(606, 372);
            this.btnTerug.Name = "btnTerug";
            this.btnTerug.Size = new System.Drawing.Size(193, 66);
            this.btnTerug.TabIndex = 15;
            this.btnTerug.Text = "TERUG NAAR HOOFDMENU";
            this.btnTerug.UseVisualStyleBackColor = true;
            this.btnTerug.Click += new System.EventHandler(this.Button3_Click);
            // 
            // lblDatum
            // 
            this.lblDatum.AutoSize = true;
            this.lblDatum.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDatum.Location = new System.Drawing.Point(694, 9);
            this.lblDatum.Name = "lblDatum";
            this.lblDatum.Size = new System.Drawing.Size(35, 13);
            this.lblDatum.TabIndex = 14;
            this.lblDatum.Text = "label1";
            // 
            // GAME
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblVerlorenScore);
            this.Controls.Add(this.lblVerloren);
            this.Controls.Add(this.lblNaam);
            this.Controls.Add(this.PCpic);
            this.Controls.Add(this.pnlGame);
            this.Controls.Add(this.button2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GAME";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MENU";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GAME_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.PCpic)).EndInit();
            this.pnlMenu.ResumeLayout(false);
            this.pnlGame.ResumeLayout(false);
            this.pnlGame.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.Timer TmrOpkomen;
        private System.Windows.Forms.Button btnNieuweGame;
        private System.Windows.Forms.Button btnScores;
        private System.Windows.Forms.Button btnMijnAccount;
        private System.Windows.Forms.Button btnCustom;
        private System.Windows.Forms.Button btnAdmin;
        private System.Windows.Forms.Button btnEXIT;
        private System.Windows.Forms.Label lblNaam;
        private System.Windows.Forms.PictureBox PCpic;
        private System.Windows.Forms.Timer tmrVoorGame;
        private System.Windows.Forms.Timer tmrScore;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label lblVerloren;
        private System.Windows.Forms.Label lblVerlorenScore;
        private System.Windows.Forms.Timer tmrStartSpring;
        private System.Windows.Forms.Button btnHerbegin;
        private System.Windows.Forms.Panel pnlGame;
        private System.Windows.Forms.Label lblDatum;
        private System.Windows.Forms.Button btnTerug;
    }
}