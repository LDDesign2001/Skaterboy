namespace Skaterboy
{
    partial class Account
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
            this.lblGamertag = new System.Windows.Forms.Label();
            this.lblHighScore = new System.Windows.Forms.Label();
            this.pcPic = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button_WOC3 = new ePOSOne.btnProduct.Button_WOC();
            this.button_WOC1 = new ePOSOne.btnProduct.Button_WOC();
            this.button_WOC2 = new ePOSOne.btnProduct.Button_WOC();
            this.btnNieuwe = new ePOSOne.btnProduct.Button_WOC();
            this.tmrverwijderd = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pcPic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblGamertag
            // 
            this.lblGamertag.AutoSize = true;
            this.lblGamertag.BackColor = System.Drawing.Color.Transparent;
            this.lblGamertag.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGamertag.ForeColor = System.Drawing.Color.White;
            this.lblGamertag.Location = new System.Drawing.Point(46, 38);
            this.lblGamertag.Name = "lblGamertag";
            this.lblGamertag.Size = new System.Drawing.Size(76, 25);
            this.lblGamertag.TabIndex = 2;
            this.lblGamertag.Text = "label1";
            // 
            // lblHighScore
            // 
            this.lblHighScore.AutoSize = true;
            this.lblHighScore.BackColor = System.Drawing.Color.Transparent;
            this.lblHighScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHighScore.ForeColor = System.Drawing.Color.White;
            this.lblHighScore.Location = new System.Drawing.Point(46, 68);
            this.lblHighScore.Name = "lblHighScore";
            this.lblHighScore.Size = new System.Drawing.Size(76, 25);
            this.lblHighScore.TabIndex = 5;
            this.lblHighScore.Text = "label1";
            // 
            // pcPic
            // 
            this.pcPic.Location = new System.Drawing.Point(577, 12);
            this.pcPic.Name = "pcPic";
            this.pcPic.Size = new System.Drawing.Size(211, 199);
            this.pcPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcPic.TabIndex = 1;
            this.pcPic.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::Skaterboy.Properties.Resources._Main_Scene;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(800, 450);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // button_WOC3
            // 
            this.button_WOC3.BorderColor = System.Drawing.Color.Purple;
            this.button_WOC3.ButtonColor = System.Drawing.Color.Black;
            this.button_WOC3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_WOC3.Location = new System.Drawing.Point(579, 327);
            this.button_WOC3.Name = "button_WOC3";
            this.button_WOC3.OnHoverBorderColor = System.Drawing.Color.Black;
            this.button_WOC3.OnHoverButtonColor = System.Drawing.Color.Purple;
            this.button_WOC3.OnHoverTextColor = System.Drawing.Color.Black;
            this.button_WOC3.Size = new System.Drawing.Size(209, 54);
            this.button_WOC3.TabIndex = 7;
            this.button_WOC3.Text = "VERWIJDER JOUW ACCOUNT";
            this.button_WOC3.TextColor = System.Drawing.Color.White;
            this.button_WOC3.UseVisualStyleBackColor = true;
            this.button_WOC3.Click += new System.EventHandler(this.Button_WOC3_Click);
            // 
            // button_WOC1
            // 
            this.button_WOC1.BorderColor = System.Drawing.Color.Purple;
            this.button_WOC1.ButtonColor = System.Drawing.Color.Black;
            this.button_WOC1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_WOC1.Location = new System.Drawing.Point(579, 250);
            this.button_WOC1.Name = "button_WOC1";
            this.button_WOC1.OnHoverBorderColor = System.Drawing.Color.Black;
            this.button_WOC1.OnHoverButtonColor = System.Drawing.Color.Purple;
            this.button_WOC1.OnHoverTextColor = System.Drawing.Color.Black;
            this.button_WOC1.Size = new System.Drawing.Size(209, 54);
            this.button_WOC1.TabIndex = 6;
            this.button_WOC1.Text = "PASSWOORD AANPASSEN";
            this.button_WOC1.TextColor = System.Drawing.Color.White;
            this.button_WOC1.UseVisualStyleBackColor = true;
            this.button_WOC1.Click += new System.EventHandler(this.Button_WOC1_Click);
            // 
            // button_WOC2
            // 
            this.button_WOC2.BackColor = System.Drawing.Color.Transparent;
            this.button_WOC2.BorderColor = System.Drawing.Color.Red;
            this.button_WOC2.ButtonColor = System.Drawing.Color.Black;
            this.button_WOC2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button_WOC2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button_WOC2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_WOC2.Font = new System.Drawing.Font("Roboto", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_WOC2.Location = new System.Drawing.Point(12, 376);
            this.button_WOC2.Name = "button_WOC2";
            this.button_WOC2.OnHoverBorderColor = System.Drawing.Color.Black;
            this.button_WOC2.OnHoverButtonColor = System.Drawing.Color.Red;
            this.button_WOC2.OnHoverTextColor = System.Drawing.Color.Black;
            this.button_WOC2.Size = new System.Drawing.Size(211, 62);
            this.button_WOC2.TabIndex = 4;
            this.button_WOC2.Text = "Terug naar hoofdmenu";
            this.button_WOC2.TextColor = System.Drawing.Color.White;
            this.button_WOC2.UseVisualStyleBackColor = false;
            this.button_WOC2.Click += new System.EventHandler(this.button_WOC2_Click);
            // 
            // btnNieuwe
            // 
            this.btnNieuwe.BorderColor = System.Drawing.Color.Purple;
            this.btnNieuwe.ButtonColor = System.Drawing.Color.Black;
            this.btnNieuwe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNieuwe.Location = new System.Drawing.Point(679, 160);
            this.btnNieuwe.Name = "btnNieuwe";
            this.btnNieuwe.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnNieuwe.OnHoverButtonColor = System.Drawing.Color.Purple;
            this.btnNieuwe.OnHoverTextColor = System.Drawing.Color.Black;
            this.btnNieuwe.Size = new System.Drawing.Size(109, 51);
            this.btnNieuwe.TabIndex = 3;
            this.btnNieuwe.Text = "FOTO AANPASSEN";
            this.btnNieuwe.TextColor = System.Drawing.Color.White;
            this.btnNieuwe.UseVisualStyleBackColor = true;
            this.btnNieuwe.Click += new System.EventHandler(this.btnNieuwe_Click);
            // 
            // tmrverwijderd
            // 
            this.tmrverwijderd.Interval = 1000;
            this.tmrverwijderd.Tick += new System.EventHandler(this.Tmrverwijderd_Tick);
            // 
            // Account
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button_WOC3);
            this.Controls.Add(this.button_WOC1);
            this.Controls.Add(this.lblHighScore);
            this.Controls.Add(this.button_WOC2);
            this.Controls.Add(this.btnNieuwe);
            this.Controls.Add(this.lblGamertag);
            this.Controls.Add(this.pcPic);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Account";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Account";
            ((System.ComponentModel.ISupportInitialize)(this.pcPic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pcPic;
        private System.Windows.Forms.Label lblGamertag;
        private ePOSOne.btnProduct.Button_WOC btnNieuwe;
        private ePOSOne.btnProduct.Button_WOC button_WOC2;
        private System.Windows.Forms.Label lblHighScore;
        private ePOSOne.btnProduct.Button_WOC button_WOC1;
        private ePOSOne.btnProduct.Button_WOC button_WOC3;
        private System.Windows.Forms.Timer tmrverwijderd;
    }
}