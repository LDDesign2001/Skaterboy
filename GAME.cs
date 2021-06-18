using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Skaterboy
{
    //Dewil Lucas 6 INFO
    public partial class GAME : Form
    {
        int Gamesnelheid;
        string us;
        private bool ad;
        bool spring = false;
        int tellerTweeKeer = 0;
        ulong score;
        ClDatacontrol objdata;
        Random RandomobjectenPositie;
        Image[] fotoS = new Image[] { Image.FromFile("start.png"), Image.FromFile("Street.jpg") };
        //Vaste waarden, vooral de skater,als je die aanpast moet je alle andere images aanpassen van dood,spring,...
        Graphics g;
        Rectangle Straat = new Rectangle(0, 390, 1000, 1000);
        Rectangle grind = new Rectangle(500, 330, 460, 70);
        Rectangle vuilbak = new Rectangle(300, 330, 60, 70);
        Rectangle skater = new Rectangle(150, 250, 80, 160);
        Bitmap vuilbakk;
        Bitmap rail;
        int snelHeidToevoegen;
        int objectSnelheid;
        public GAME(string usernaam, bool admin)
        {
            //Ik geef bij elke form mee of dat account een admin account is of niet, zo vermijd ik telkens een nieuwe database connectie te moeten maken
            this.KeyPreview = true;
            InitializeComponent();
            init(usernaam, admin);
        }

        private void init(string user, bool adm)
        {

            objdata = new ClDatacontrol();
            us = user;
            ad = adm;
            g = pnlGame.CreateGraphics();
            string sqlSnelheid = "SELECT gameSnelheid FROM EX2_Accounts WHERE username = @nick";
            objdata.gamesnelheid(us, sqlSnelheid);
            snelHeidToevoegen = objdata.getSnelheid();//Hier haal ik de snelheid uit de database
            Console.WriteLine(snelHeidToevoegen);
            pnlMenu.Width = 0;
            pnlMenu.Height = 0;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            typeof(Panel).InvokeMember("DoubleBuffered", System.Reflection.BindingFlags.SetProperty | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic, null, pnlGame, new object[] { true });
            string sql = "SELECT profielFoto,background,ObstakelVuilbak,ObstakelRail FROM EX2_Accounts WHERE username = @nick";
            DataTable dt = objdata.getTabel(sql, user);

            if (dt.Rows.Count > 0)
            {
                try // Ik haal hier alle foto's op uit de database
                {
                    MemoryStream ms = new MemoryStream((byte[])dt.Rows[0]["profielFoto"]);
                    PCpic.Image = new Bitmap(ms);//Profielfoto ophalen  

                    MemoryStream ms2 = new MemoryStream((byte[])dt.Rows[0]["background"]);
                    pnlGame.BackgroundImage = new Bitmap(ms2);
                    pnlGame.BackgroundImageLayout = ImageLayout.Stretch;//achtergrond ophalen
                    MemoryStream ms3 = new MemoryStream((byte[])dt.Rows[0]["ObstakelVuilbak"]);
                    vuilbakk = new Bitmap(ms3);//Vuilbak ophalen
                    MemoryStream ms4 = new MemoryStream((byte[])dt.Rows[0]["ObstakelRail"]);
                    rail = new Bitmap(ms4);//Rail ophalen 
                }
                catch (Exception)
                {
                    MessageBox.Show("Je hebt nog geen profielfoto, voeg een profielfoto toe");
                }
            }
            lblNaam.Text = "Hey " + user.ToUpper() + "!";
            us = user;
            if (ad == false)
            {
                btnAdmin.Visible = false;
            }
            allesFalseStart();
            TmrOpkomen.Start();
        }


        private void allesFalseStart()
        {
            btnHerbegin.Visible = false;
            btnHerbegin.Enabled = false;
            btnTerug.Enabled = false;
            btnTerug.Visible = false;
            lblDatum.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)//Dit is button nieuwe game, om je game te starten
        {
            allesFalseNaKlik();
            RandomobjectenPositie = new Random();
            grind.X = RandomobjectenPositie.Next(1000, 1500);
            vuilbak.X = RandomobjectenPositie.Next(1500, 2000);
            if (grind.IntersectsWith(vuilbak))
            {
                grind.X = RandomobjectenPositie.Next(1000, 1500);
                vuilbak.X = RandomobjectenPositie.Next(1500, 2000);
            }
            startGame();
        }

        private void allesFalseNaKlik()
        {
            PCpic.Visible = false;
            btnNieuweGame.Visible = false;
            btnAdmin.Visible = false;
            btnCustom.Visible = false;
            btnEXIT.Visible = false;
            btnScores.Visible = false;
            btnMijnAccount.Visible = false;
            pnlMenu.Visible = false;
        }

        private void startGame()
        {
            DialogResult start = MessageBox.Show("DRUK OP JE SPATIE KNOP OM TE SPRINGEN, VERMIJD DE VUILNISBAKKEN EN DE ZIJKANTEN VAN DE RAILS, JE KAN OP DE RAILS SPRINGEN!", "DRUK OP JE SPATIE KNOP OM TE SPRINGEN", MessageBoxButtons.OK);
            if (start == DialogResult.OK)//Je kan niet spelen tot je op ok geklikt hebt
            {
                allesnul();
                opstartAlles();
            }
        }

        private void opstartAlles()
        {
            objectSnelheid = 10;
            RandomobjectenPositie = new Random();
            grind.X = RandomobjectenPositie.Next(400, 1500);
            vuilbak.X = RandomobjectenPositie.Next(2000, 3000);
            if (grind.IntersectsWith(vuilbak) || vuilbak.IntersectsWith(grind))
            {
                grind.X = RandomobjectenPositie.Next(1000, 1500);
                vuilbak.X = RandomobjectenPositie.Next(2000, 2500);
            }
            tmrVoorGame.Start();
            tmrScore.Start();
        }

        private void allesnul()
        {
            btnHerbegin.Visible = false;
            btnHerbegin.Enabled = false;
            lblVerlorenScore.Visible = false;
            tellerTweeKeer = 0;
            fotoS[0] = Image.FromFile("start.png");
            lblVerloren.Visible = false;
            score = 0; Gamesnelheid = 0;
            btnNieuweGame.Enabled = false;
            btnAdmin.Enabled = false;
            btnCustom.Enabled = false;
            btnEXIT.Enabled = false;
            btnScores.Enabled = false;
            btnMijnAccount.Enabled = false;
            pnlMenu.Enabled = false;
            pnlGame.Dock = DockStyle.Fill;
            lblNaam.Location = new Point(0, 9);
            pnlMenu.Visible = false;
            lblDatum.Visible = true;
        }

        
        private void TmrOpkomen_Tick(object sender, EventArgs e)//Dit is om het menu te laten opkomen
        {
            if (pnlMenu.Width == 146 && pnlMenu.Height == 450)
            {
                TmrOpkomen.Stop();
            }
            else
            {
                pnlMenu.Height++;
                pnlMenu.Width++;
            }
        }

        private void btnScores_Click(object sender, EventArgs e)
        {
            GAME.ActiveForm.Close();
            HIGHSCORES frm = new HIGHSCORES(us, ad);
            frm.Show();
        }

        private void btnMijnAccount_Click(object sender, EventArgs e)
        {
            GAME.ActiveForm.Close();
            Account frm = new Account(us, ad);
            frm.Show();
        }

        private void btnEXIT_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            GAME.ActiveForm.Close();
            admin frm = new admin(us, ad);
            frm.Show();
        }

        private void btnCustom_Click(object sender, EventArgs e)
        {
            GAME.ActiveForm.Close();
            Settings frm = new Settings(us, ad);
            frm.Show();
        }
        private void Button3_Click(object sender, EventArgs e)//Dit is button terug, om terug naar de hoofdmenu te gaan
        {
            GAME.ActiveForm.Close();
            GAME frm = new GAME(us, ad);
            frm.Show();
        }
        private void tmrVoorGame_Tick(object sender, EventArgs e)
        {
            pnlGame.Invalidate();
            bool maxBerekeit = tmrVoorGame.Interval == 1 ? true : false;
            bool maxSprongbereikt = tmrStartSpring.Interval == 1 ? true : false;
            Gamesnelheid++;
            if (skater.IntersectsWith(vuilbak))
            {
                dood();
            }
            else if (skater.IntersectsWith(grind) && skater.Y > 190 && skater.Y <= 250)
            {
                Console.WriteLine(skater.Y);
                dood();
            }
            if (Gamesnelheid == snelHeidToevoegen)
            {
                Gamesnelheid = 0;
                if (maxBerekeit == false)
                {
                    tmrVoorGame.Interval--;
                    objectSnelheid++;
                }
                else
                {
                    tmrVoorGame.Interval = 1;
                }

                if (maxSprongbereikt == false)
                {
                    tmrStartSpring.Interval--;

                    Console.WriteLine(tmrStartSpring.Interval);
                }
                else
                {
                    tmrStartSpring.Interval = 1;
                }
            }
            lblNaam.Text = "SCORE: " + score.ToString();
            lblDatum.Text = DateTime.Now.ToString() + " \r\nSpeler: " + us;
            grind.X -= objectSnelheid;
            vuilbak.X -= objectSnelheid;

            if (grind.X < -500)
            {
                RandomobjectenPositie = new Random();
                grind.X = this.ClientSize.Width + RandomobjectenPositie.Next(500, 1100);
            }
            if (vuilbak.X < -500)
            {
                RandomobjectenPositie = new Random();
                vuilbak.X = this.ClientSize.Width + RandomobjectenPositie.Next(1100, 1500);
            }
            RandomobjectenPositie = new Random();
            if (vuilbak.IntersectsWith(grind))
            {
                int vuilbakErvoorOfErna = RandomobjectenPositie.Next(0, 2);
                if (vuilbakErvoorOfErna == 1)
                {
                    vuilbak.X += 100;
                }
                else
                {
                    vuilbak.X -= 100;
                }
            }

        }

        private void pnlGame_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(fotoS[1], Straat.X, Straat.Y);
            e.Graphics.DrawImage((Image)rail, grind.X, grind.Y, 460, 70);
            e.Graphics.DrawImage((Image)vuilbakk, vuilbak.X, vuilbak.Y, 60, 70);
            e.Graphics.DrawImage(fotoS[0], skater.X, skater.Y);
        }

        private void GAME_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Space:
                    tellerTweeKeer++;
                    if (tellerTweeKeer == 1)
                    {
                        spring = true;
                        tmrStartSpring.Start();
                    }
                    break;
            }
        }

        private void tmrStartSpring_Tick(object sender, EventArgs e)
        {
            if (spring)
            {
                if (skater.IntersectsWith(vuilbak))
                {
                    dood();
                }
                else
                {
                    fotoS[0] = Image.FromFile("spring.png");
                    skater.Y -= 20;
                    if (skater.Y <= 30)//hoogte van sprong
                    {
                        spring = false;
                    }
                }

            }
            else
            {

                if (skater.IntersectsWith(vuilbak))
                {
                    dood();
                }
                else if (skater.IntersectsWith(grind))
                {
                    skater.Y = 190;
                    fotoS[0] = Image.FromFile("grind.png");
                    tellerTweeKeer = 0;
                }
                else
                {
                    skater.Y += 10;
                    if (skater.Y >= 250)//Grond
                    {
                        fotoS[0] = Image.FromFile("start.png");
                        tmrStartSpring.Stop();
                        tellerTweeKeer = 0;
                    }
                }
            }
        }

        private void dood()
        {
            fotoS[0] = Image.FromFile("dead.png");
            tmrStartSpring.Stop();
            tmrScore.Stop();
            tmrVoorGame.Stop();
            lblVerloren.Visible = true;
            btnHerbegin.Visible = true;
            btnHerbegin.Enabled = true;
            btnTerug.Enabled = true;
            btnTerug.Visible = true;
            lblVerlorenScore.Text = "JOUW SCORE : " + score.ToString();
            lblVerlorenScore.Visible = true;

            DialogResult opslanenofnie = MessageBox.Show("Wil je je score opslanen?", "Sla je je game op?", MessageBoxButtons.YesNo);
            if (opslanenofnie == DialogResult.Yes)
            {
                string sql1 = "SELECT ID_account FROM EX2_Accounts WHERE username = @nick";
                string sql2 = "INSERT INTO EX2_Scores (`IDScore`, `IDSpeler`, `DatumOpgeslagen`, `Score`, `Gamertag`) VALUES (NULL, " + objdata.ID(us, sql1) + ", '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "', " + score.ToString() + ", @nick)";
                objdata.checkData(us, sql2);
            }

        }

        private void tmrScore_Tick(object sender, EventArgs e)
        {
            score += 2;
            bool MaxScoreSnelheidBereikt = tmrScore.Interval == 10 ? true : false;
            if (MaxScoreSnelheidBereikt == false)//Hoe verder je geraakt in het spel, hoe sneller je score vergroot
            {
                tmrScore.Interval -= 10;
            }
            else
            {
                tmrScore.Interval = 10;
            }
        }

        private void btnHerbegin_Click(object sender, EventArgs e)
        {
            startGame();
            tmrScore.Interval = 1000;
            tmrVoorGame.Interval = 50;
            tmrStartSpring.Interval = 50;
            skater = new Rectangle(150, 250, 100, 150);
            btnTerug.Visible = false;
            btnTerug.Enabled = false;
        }
        

    }
}
