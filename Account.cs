using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Skaterboy
{
    public partial class Account : Form
    {
        ClDatacontrol objdata;
        string pic;
        ClBestandSelecteren objFoto;
        string gamer;
        bool admin;
        int quit = 0;
        public Account(string us, bool ad)
        {
            InitializeComponent();
            init(us, ad);
        }

        private void init(string user, bool x)
        {
            objdata = new ClDatacontrol();
            string sqlH = "SELECT Score FROM `EX2_Scores` WHERE Gamertag = @nick ORDER BY Score DESC LIMIT 1";
            lblHighScore.Text = "Jouw hoogste score: " + objdata.getHIGHSCORE(user, sqlH);
            gamer = user;
            admin = x;
            objdata = new ClDatacontrol();
            lblGamertag.Text = "GAMERTAG : " + user;
            string sql = "SELECT profielFoto FROM EX2_Accounts WHERE username = @nick";
            DataTable dt = objdata.getTabel(sql, user);
            if (dt.Rows.Count > 0)
            {
                try
                {
                    MemoryStream ms = new MemoryStream((byte[])dt.Rows[0]["profielFoto"]);
                    pcPic.Image = new Bitmap(ms);
                }
                catch (Exception)
                {
                    this.alert("Je hebt nog geen profielfoto, voeg een profielfoto toe", DialogFormError.enmType.Succes);
                }
            }
        }

        private void button_WOC2_Click(object sender, EventArgs e)
        {
            Account.ActiveForm.Close();
            GAME frm = new GAME(gamer, admin);
            frm.Show();
        }
        public void alert(string error, DialogFormError.enmType type)
        {
            DialogFormError frm = new DialogFormError();
            frm.toonAlert(error, type);
        }
        private void btnNieuwe_Click(object sender, EventArgs e)
        {
            try
            {
                objFoto = new ClBestandSelecteren();
                objdata = new ClDatacontrol();
                pic = objFoto.getBestand();
                pcPic.Image = Image.FromFile(pic);
                Console.WriteLine(pic);
                try
                {
                    MemoryStream ms = new MemoryStream();
                    pcPic.Image.Save(ms, pcPic.Image.RawFormat);
                    Byte[] img = ms.ToArray();
                    string sql = "UPDATE EX2_Accounts SET  profielFoto = @img,laatsteUpdate = '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' WHERE username ='" + gamer + "' ";
                    objdata.nieuwPic(sql, img);
                    this.alert("Jouw foto werd opgeslagen!", DialogFormError.enmType.Succes);

                }
                catch (MySqlException)
                {
                    this.alert("U hebt geen foto gekozen.", DialogFormError.enmType.Error);
                }

            }
            catch (Exception)
            {
                this.alert("U hebt geen foto gekozen.", DialogFormError.enmType.Error);
            }

        }

        private void Button_WOC1_Click(object sender, EventArgs e)
        {
            Account.ActiveForm.Close();
            PASSWOORDAANPASSEN frm = new PASSWOORDAANPASSEN(gamer, admin);
            frm.Show();
        }

        private void Button_WOC3_Click(object sender, EventArgs e)
        {
            DialogResult opslanenofnie = MessageBox.Show("Ben je zeker dat je jouw account wilt verwijderen en ook je highscore?", "Account verwijderen?", MessageBoxButtons.YesNo);
            if (opslanenofnie == DialogResult.Yes)
            {
                string sql = "";
                try
                {
                    button_WOC2.Enabled = false;
                    button_WOC3.Enabled = false;
                    btnNieuwe.Enabled = false;
                    string sql1 = "SELECT Score FROM EX2_Accounts WHERE username = @nick";
                    DataTable dt = objdata.getTabel(sql1, gamer);
                    sql = "DELETE a FROM EX2_Accounts a WHERE a.username = @nick";
                    objdata.DELData(gamer, sql);
                    this.alert("Account succesvol verwijderd, bedankt om te spelen!", DialogFormError.enmType.Succes);
                    ;
                    tmrverwijderd.Start();
                }
                catch (MySqlException)
                {
                    button_WOC2.Enabled = false;
                    button_WOC3.Enabled = false;
                    btnNieuwe.Enabled = false;
                    sql = "DELETE a,s FROM EX2_Accounts a,EX2_Scores s WHERE a.username = @nick AND s.Gamertag = @nick";
                    objdata.DELData(gamer, sql);
                    this.alert("Account succesvol verwijderd, bedankt om te spelen!", DialogFormError.enmType.Succes);
                    tmrverwijderd.Start();
                }

            }


        }

        private void Tmrverwijderd_Tick(object sender, EventArgs e)
        {
            Account.ActiveForm.Close();
            quit++;
            if (quit == 10)
            {
                tmrverwijderd.Stop();
                Application.Exit();
            }
        }
    }
}
