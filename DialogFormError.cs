using System;
using System.Drawing;
using System.Windows.Forms;

namespace Skaterboy
{
    //CODE 5INFO(quarentaine) -->Toaster
    public partial class DialogFormError : Form
    {
        public DialogFormError()
        {
            InitializeComponent();
        }
        public enum enmType
        {
            Succes,
            Error
        }
        public enum num
        {
            wacht,
            start,
            sluit
        }
        private DialogFormError.num actie;
        private int x, y;
        public void toonAlert(string error, enmType type)
        {
            this.Opacity = 0.0;
            this.StartPosition = FormStartPosition.Manual;
            string blub;
            for (int i = 1; i < 10; i++)
            {
                blub = "Alert" + i.ToString();
                DialogFormError frm = (DialogFormError)Application.OpenForms[blub];
                if (frm == null)
                {
                    this.Name = blub;
                    this.x = Screen.PrimaryScreen.WorkingArea.Width - this.Width + 15;
                    this.y = Screen.PrimaryScreen.WorkingArea.Height - this.Height * i;
                    this.Location = new Point(this.x, this.y);
                    break;
                }
            }
            this.x = Screen.PrimaryScreen.WorkingArea.Width - base.Width - 5;

            switch (type)
            {
                case enmType.Succes:
                    this.pictureBox1.Image = Image.FromFile("succes.png");
                    this.BackColor = Color.Green;
                    break;
                case enmType.Error:
                    this.pictureBox1.Image = Image.FromFile("kisspng-computer-icons-error-closeup-vector-5adbcf1515baa6.8050010215243548370891.png");
                    this.BackColor = Color.DarkRed;
                    break;
            }

            this.lblError.Text = error;
            this.Show();
            this.actie = num.start;
            this.timer1.Interval = 1;
            timer1.Start();
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            switch (this.actie)
            {
                case num.wacht:
                    timer1.Interval = 5000;
                    actie = num.sluit;
                    break;
                case DialogFormError.num.start:
                    timer1.Interval = 1;
                    this.Opacity += 0.1;
                    if (this.x < this.Location.X)
                    {
                        this.Left--;
                    }
                    else
                    {
                        if (this.Opacity == 1.0)
                        {
                            actie = DialogFormError.num.wacht;
                        }
                    }
                    break;
                case DialogFormError.num.sluit:
                    timer1.Interval = 1;
                    this.Opacity -= 0.1;
                    this.Left -= 3;
                    if (base.Opacity == 0.0)
                    {
                        base.Close();
                    }
                    break;
            }
        }

        private void button_WOC1_Click(object sender, EventArgs e)
        {
            timer1.Interval = 1;
            actie = num.sluit;
        }
    }
}
