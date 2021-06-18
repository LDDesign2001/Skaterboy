using System;
using System.Windows.Forms;

namespace Skaterboy
{
    public partial class admin : Form
    {
        string gamer;
        bool aAdmin;
        ClDatacontrol objdata;
        public admin(string user, bool adm)
        {
            InitializeComponent();
            init(user, adm);
        }

        private void init(string us, bool dmin)
        {
            objdata = new ClDatacontrol();
            aAdmin = dmin;
            gamer = us;
        }

        private void btnDBLEGEN_Click(object sender, EventArgs e)//Knop om alles te verwijderen
        {
            string sql = "DELETE  FROM EX2_Scores";
            objdata.DelAlles(sql);
            string sql2 = "DELETE  FROM EX2_Accounts WHERE admin = 0";
            objdata.DelAlles(sql2);

        }

        private void button_WOC1_Click(object sender, EventArgs e)//Knop om enkel de scores te verwijderen
        {
            string sql = "DELETE  FROM EX2_Scores";
            objdata.DelAlles(sql);
        }

        private void button_WOC2_Click(object sender, EventArgs e)//Knop om terug naar het hoofdmenu te keren
        {
            admin.ActiveForm.Close();
            GAME frm = new GAME(gamer, aAdmin);
            frm.Show();
        }
    }
}
