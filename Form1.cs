using System;
using System.Windows.Forms;

namespace Skaterboy
{
    public partial class Form1 : Form
    {
        Byte[] img = null;
        clHash hassh;
        ClDatacontrol objdata;
        public Form1()
        {
            InitializeComponent();
            init();
        }
        public void alert(string error, DialogFormError.enmType type)
        {
            DialogFormError frm = new DialogFormError();
            frm.toonAlert(error, type);
        }

        private void init()
        {
            objdata = new ClDatacontrol();
        }

        private void button_WOC2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button_WOC1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Hide();
            FRMNieuwAccount frm = new FRMNieuwAccount();
            frm.Show();
        }

        private void btnInlog_Click(object sender, EventArgs e)
        {
            hassh = new clHash(txtPass.Text);
            Console.WriteLine(hassh.getHash());
            string sql = "SELECT username FROM EX2_Accounts WHERE username = @nick AND hashedpw = '" + hassh.getHash() + "'";
            if (txtUser.Text.Length == 0 || txtPass.Text.Length == 0)
            {
                this.alert("Passwoord of usernaam niet correct ingevoerd, " + "\r\n" +
                    "gelieve het juist in te voeren of als u nog niet over een account " + "\r\n" +
                    "beschikt een account aan te maken. ", DialogFormError.enmType.Error);
            }
            else
            {
                objdata.checkData(txtUser.Text, "", sql, img);
                Console.WriteLine(objdata.getInlog());
                if (objdata.getInlog() == "ingelogd")
                {
                    sql = "UPDATE EX2_Accounts SET TijdstipLaatsteInlog = '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' WHERE Username = @nick";
                    objdata.checkData(txtUser.Text, sql);
                    string chackAdmin = "SELECT admin FROM EX2_Accounts WHERE username = @nick";
                    objdata.admin(txtUser.Text, chackAdmin);
                    if (objdata.getAdmin() == true)
                    {
                        this.alert("Succesvol " + objdata.getInlog() + "!", DialogFormError.enmType.Succes);
                        this.Hide();
                        GAME frm = new GAME(txtUser.Text, true);
                        frm.Show();
                    }
                    else
                    {
                        this.alert("Succesvol " + objdata.getInlog() + "!", DialogFormError.enmType.Succes);
                        this.Hide();
                        GAME frm = new GAME(txtUser.Text, false);
                        frm.Show();
                    }
                }
                else
                {
                    this.alert("Passwoord of usernaam niet correct ingevoerd, " + "\r\n" +
                        "gelieve het juist in te voeren of als u nog niet over een account " + "\r\n" +
                        "beschikt een account aan te maken. ", DialogFormError.enmType.Error);
                }
            }
        }
    }
}
