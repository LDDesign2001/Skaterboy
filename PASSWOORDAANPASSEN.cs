using System;
using System.Windows.Forms;

namespace Skaterboy
{
    public partial class PASSWOORDAANPASSEN : Form
    {
        ClDatacontrol objdata;
        clHash hassh;
        clPasswoord objpass;
        string user;
        bool admin;
        int teller = 0;
        public PASSWOORDAANPASSEN(string us, bool ad)
        {
            InitializeComponent();
            init(us, ad);
        }

        private void init(string u, bool a)
        {
            objdata = new ClDatacontrol();
            objpass = new clPasswoord();
            user = u;
            admin = a;
        }

        public void alert(string error, DialogFormError.enmType type)
        {
            DialogFormError frm = new DialogFormError();
            frm.toonAlert(error, type);
        }
        private void Button_WOC1_Click(object sender, EventArgs e)//Knop om je passwoord aan te passen
        {

            if (txtNieuw.Text.Length == 0 || txtControle.Text.Length == 0)
            {
                this.alert("U bent iets vergeten invullen, gelieve alles in te vullen!", DialogFormError.enmType.Error);
            }
            else
            {
                bool CheckAllesOK = objpass.clPasswoordCheck(txtNieuw.Text, txtControle.Text);
                if (CheckAllesOK)
                {

                    hassh = new clHash(txtNieuw.Text);
                    string sql = "UPDATE `EX2_Accounts` SET `passwoord` = '" + txtNieuw.Text + "',hashedpw='" + hassh.getHash() + "' WHERE `EX2_Accounts`.`username` = @nick";
                    objdata.checkData(user, sql);
                    this.alert("Nieuwe passwoord succesvol opgelsagen!\r\nDeze pagina sluit automatisch!", DialogFormError.enmType.Succes);
                    button_WOC1.Enabled = false;
                    tmrSluit.Start();
                }
                else
                {
                    this.alert("Je passwoord is niet in orde!\r\nGelieve 1hoofdletter, 1cijfer en minstens 8 tekens te gebruiken!", DialogFormError.enmType.Error);
                }

            }
        }

        private void Button_WOC2_Click(object sender, EventArgs e)//Button om terug naar Account form te gaan
        {
            ActiveForm.Close();
            Account frm = new Account(user, admin);
            frm.Show();
        }

        private void tmrSluit_Tick(object sender, EventArgs e)
        {
            teller++;
            if (teller == 8)//Tijd dat het neemt om deze pagina te sluiten
            {
                PASSWOORDAANPASSEN.ActiveForm.Close();
                Account frm = new Account(user, admin);
                frm.Show();
            }
        }
    }
}
