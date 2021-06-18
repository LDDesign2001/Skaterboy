using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Skaterboy
{
    public partial class FRMNieuwAccount : Form
    {
        ClDatacontrol objdata;
        clHash hassh;
        ClBestandSelecteren objFoto;
        clPasswoord objPassCheck;
        string pic;
        Image[] startFotos = new Image[] { Image.FromFile("sky.jpg"), Image.FromFile("bin.png"), Image.FromFile("Rail.png") };
        public FRMNieuwAccount()
        {
            InitializeComponent();
            init();
        }

        private void init()
        {
            objdata = new ClDatacontrol();
            objFoto = new ClBestandSelecteren();
            objPassCheck = new clPasswoord();
            ptbBack.Image = startFotos[0];
            ptbGrind.Image = startFotos[2];
            ptbVuil.Image = startFotos[1];
        }
        public void alert(string error, DialogFormError.enmType type)
        {
            DialogFormError frm = new DialogFormError();
            frm.toonAlert(error, type);
        }
        private void btnMaak_Click(object sender, EventArgs e)
        {
            if (txtMatch.Text.Length == 0 || txtPass.Text.Length == 0 || txtUser.Text.Length == 0)
            {
                this.alert("U bent iets vergeten invullen, gelieve alles in te vullen!", DialogFormError.enmType.Error);
            }
            else
            {
                bool CheckAllesOK = objPassCheck.clPasswoordCheck(txtPass.Text,txtMatch.Text);
                if (CheckAllesOK)
                {

                    MemoryStream ms = new MemoryStream();
                    ProfielPic.Image.Save(ms, ProfielPic.Image.RawFormat);
                    Byte[] img = ms.ToArray();//Profiel foto opslanen


                    MemoryStream ms2 = new MemoryStream();
                    ptbBack.Image.Save(ms2, ptbBack.Image.RawFormat);
                    Byte[] img1 = ms2.ToArray();//Achtergrond opslanen (de basis achtergrond)

                    MemoryStream ms3 = new MemoryStream();
                    ptbGrind.Image.Save(ms3, ptbGrind.Image.RawFormat);
                    Byte[] img2 = ms3.ToArray();//rail opslanen

                    MemoryStream ms4 = new MemoryStream();
                    ptbVuil.Image.Save(ms4, ptbVuil.Image.RawFormat);
                    Byte[] img3 = ms4.ToArray();//Vuilnisbak opslanen


                    hassh = new clHash(txtPass.Text);
                    string sql = "INSERT INTO EX2_Accounts (username,passwoord,hashedpw,admin,TijdstipLaatsteInlog,profielFoto,background,ObstakelRail,ObstakelVuilbak) VALUES(@nick,@pass,'" + hassh.getHash() + "',0,'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "',@img,@img2,@img3,@img4)";
                    objdata.Insert(txtUser.Text, txtPass.Text, sql, img, img1, img2, img3);
                    if (objdata.getInlog() == "Account bestaat al!")
                    {
                        this.alert(objdata.getInlog(), DialogFormError.enmType.Error);
                    }
                    else
                    {
                        this.alert("Account succesvol aangemaakt!", DialogFormError.enmType.Succes);
                        this.Close();
                        Form1 frm = new Form1();
                        frm.Show();
                    }
                    Console.WriteLine(objdata.getInlog());
                }
                else
                {
                    this.alert("Je passwoord is niet in orde!\r\nGelieve 1hoofdletter, 1cijfer en minstens 8 tekens te gebruiken!", DialogFormError.enmType.Error);
                }

            }


        }

        

        private void btnGet_Click_1(object sender, EventArgs e)
        {

            try
            {
                objFoto = new ClBestandSelecteren();
                pic = objFoto.getBestand();
                ProfielPic.Image = Image.FromFile(pic);
                Console.WriteLine(pic);
            }
            catch (Exception)
            {
                this.alert("U hebt geen foto gekozen, u kan doorgaan en later uw profielfoto aanpassen in het hoofdmenu knop account.", DialogFormError.enmType.Error);
            }
        }

        private void btnX_Click(object sender, EventArgs e)
        {
            FRMNieuwAccount.ActiveForm.Close();
            Form1 frm = new Form1();
            frm.Show();
        }
    }
}

