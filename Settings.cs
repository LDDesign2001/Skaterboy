using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Skaterboy
{
    public partial class Settings : Form
    {
        string gamer;
        bool admin;
        ClDatacontrol objdata;
        ClBestandSelecteren objFoto;
        string pic;
        public Settings(string us, bool adm)
        {
            InitializeComponent();
            init(us, adm);
        }

        private void init(string s, bool d)
        {
            gamer = s;
            admin = d;
            objdata = new ClDatacontrol();
            string sql1 = "SELECT gameSnelheid FROM EX2_Accounts WHERE username = @nick";
            objdata.gamesnelheid(gamer, sql1);
            if (objdata.getSnelheid() != 1)
            {
                trackBar1.Value = objdata.getSnelheid() / 5;
                //Ik deel mijn ingekomen value om het juiste trackbar positie te krijgen
            }
            else
            {
                trackBar1.Value = objdata.getSnelheid() - 1;
                //Als je binnengekomen value 0 is, doe je min 1 op de trackbar om het duidelijk te maken dat je op het snelst zijt
            }
            string sql = "SELECT background,ObstakelVuilbak,ObstakelRail FROM EX2_Accounts WHERE username = @nick";
            DataTable dt = objdata.getTabel(sql, gamer);
            if (dt.Rows.Count > 0)
            {
                try
                {
                    MemoryStream ms = new MemoryStream((byte[])dt.Rows[0]["background"]);
                    ptbAchtergrond.Image = new Bitmap(ms);
                    ptbAchtergrond.BackgroundImageLayout = ImageLayout.Stretch;//achtergrond ophalen
                    MemoryStream ms2 = new MemoryStream((byte[])dt.Rows[0]["ObstakelVuilbak"]);
                    ptbObstakelVuilbak.Image = new Bitmap(ms2);
                    ptbObstakelVuilbak.BackgroundImageLayout = ImageLayout.Stretch;
                    MemoryStream ms3 = new MemoryStream((byte[])dt.Rows[0]["ObstakelRail"]);
                    ptbRail.Image = new Bitmap(ms3);
                    ptbRail.BackgroundImageLayout = ImageLayout.Stretch;
                }
                catch (Exception)
                {
                    MessageBox.Show("Fout bij het ophalen van je achtergrondsfoto of obstakels");
                }
            }
        }



        private void button_WOC2_Click(object sender, EventArgs e)//Button terug naar hoofdmenu
        {
            Settings.ActiveForm.Close();
            GAME frm = new GAME(gamer, admin);
            frm.Show();
        }






        private void button_WOC1_Click(object sender, EventArgs e)//Button om achtergrond aan te passen
        {
            try
            {
                objFoto = new ClBestandSelecteren();
                objdata = new ClDatacontrol();
                pic = objFoto.getBestand();
                ptbAchtergrond.Image = Image.FromFile(pic);
                Console.WriteLine(pic);
                try
                {
                    MemoryStream ms = new MemoryStream();
                    ptbAchtergrond.Image.Save(ms, ptbAchtergrond.Image.RawFormat);
                    Byte[] img = ms.ToArray();
                    string sql = "UPDATE EX2_Accounts SET  background = @img,laatsteUpdate = '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' WHERE username ='" + gamer + "' ";
                    objdata.nieuwPic(sql, img);
                    this.alert("Jouw foto werd opgeslagen!", DialogFormError.enmType.Succes);

                }
                catch (Exception)
                {
                    this.alert("U hebt geen foto gekozen.", DialogFormError.enmType.Error);
                }

            }
            catch (Exception)
            {
                this.alert("U hebt geen foto gekozen.", DialogFormError.enmType.Error);
            }
        }
        public void alert(string error, DialogFormError.enmType type)
        {
            DialogFormError frm = new DialogFormError();
            frm.toonAlert(error, type);
        }

        private void btnGetObstakel_Click(object sender, EventArgs e)
        {
            try
            {
                objFoto = new ClBestandSelecteren();
                objdata = new ClDatacontrol();
                pic = objFoto.getBestand();
                ptbObstakelVuilbak.Image = Image.FromFile(pic);
                Console.WriteLine(pic);
                try
                {
                    MemoryStream ms = new MemoryStream();
                    ptbObstakelVuilbak.Image.Save(ms, ptbObstakelVuilbak.Image.RawFormat);
                    Byte[] img = ms.ToArray();
                    string sql = "UPDATE EX2_Accounts SET  ObstakelVuilbak = @img,laatsteUpdate = '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' WHERE username ='" + gamer + "' ";
                    objdata.nieuwPic(sql, img);
                    this.alert("Jouw foto werd opgeslagen!", DialogFormError.enmType.Succes);

                }
                catch (Exception)
                {
                    this.alert("U hebt geen foto gekozen.", DialogFormError.enmType.Error);
                }

            }
            catch (Exception)
            {
                this.alert("U hebt geen foto gekozen.", DialogFormError.enmType.Error);
            }
        }

        private void btnAanpassenRail_Click(object sender, EventArgs e)
        {
            try
            {
                objFoto = new ClBestandSelecteren();
                objdata = new ClDatacontrol();
                pic = objFoto.getBestand();
                ptbRail.Image = Image.FromFile(pic);
                Console.WriteLine(pic);
                try
                {
                    MemoryStream ms = new MemoryStream();
                    ptbRail.Image.Save(ms, ptbRail.Image.RawFormat);
                    Byte[] img = ms.ToArray();
                    string sql = "UPDATE EX2_Accounts SET  ObstakelRail = @img,laatsteUpdate = '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' WHERE username ='" + gamer + "' ";
                    objdata.nieuwPic(sql, img);
                    this.alert("Jouw foto werd opgeslagen!", DialogFormError.enmType.Succes);

                }
                catch (Exception)
                {
                    this.alert("U hebt geen foto gekozen.", DialogFormError.enmType.Error);
                }

            }
            catch (Exception)
            {
                this.alert("U hebt geen foto gekozen.", DialogFormError.enmType.Error);
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            int trackKeuze = trackBar1.Value * 5;
            if (trackKeuze == 0) trackKeuze = 1;
            string sql = "UPDATE EX2_Accounts SET gameSnelheid = " + trackKeuze + " WHERE username = @nick";
            objdata.gamesnelheid(gamer, sql);
        }
    }
}

