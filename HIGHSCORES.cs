using System;
using System.Windows.Forms;

namespace Skaterboy
{
    public partial class HIGHSCORES : Form
    {
        string us;
        bool addminn;
        ClDatacontrol objdata;
        string[] filter = new string[] { "Al jouw recente scores", "Beste scores van vandaag", "Beste scores van afgelopen week", "Beste scores van afgelopen jaar", "Jouw globale beste score" };
        int[] limiet = new int[] { 5, 10, 20, 50, 100 };
        int gekozenlimiet;
        string sql;
        public HIGHSCORES(string user, bool ad)
        {
            InitializeComponent();
            init(user, ad);
        }

        private void init(string user, bool admin)
        {

            MessageBox.Show("KIES EERST HET AANTAL SCORES DIE JE WILT ZIEN");
            label1.Visible = false;
            CMBkeuzePeriode.Visible = false;
            us = user;
            CMBkeuzePeriode.Items.AddRange(filter);
            foreach (var getal in limiet)
            {
                CMBAantal.Items.Add("top " + getal);
            }
            addminn = admin;
        }

        private void button_WOC2_Click(object sender, EventArgs e)// Button terug naar hoofdmenu
        {
            HIGHSCORES.ActiveForm.Close();
            GAME frm = new GAME(us, addminn);
            frm.Show();
        }

        private void toonData(string sqldata)
        {
            objdata = new ClDatacontrol();

            try
            {
                dataGridView1.DataSource = objdata.getTabel(sqldata, us);
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].Visible = false;
                dataGridView1.Columns[2].HeaderText = "Datum";
            }
            catch (Exception)
            {
                this.alert("Data niet kunnen ophalen", DialogFormError.enmType.Error);
            }
        }
        public void alert(string error, DialogFormError.enmType type)
        {
            DialogFormError frm = new DialogFormError();
            frm.toonAlert(error, type);
        }
        private void button5_Click_1(object sender, EventArgs e)//Jouw score
        {
            label1.Visible = true;
            CMBkeuzePeriode.Visible = true;
            lblHighScore.Text = button5.Text + ":";
            CMBkeuzePeriode.SelectedIndex = 0;
        }

        private void errorNogNietGespeeld()
        {
            if (dataGridView1.Rows.Count == 0)
            {
                this.alert("Je hebt nog niet gespeeld!", DialogFormError.enmType.Error);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)//Scores voorbije week
        {
            label1.Visible = false;
            CMBkeuzePeriode.Visible = false;
            lblHighScore.Text = button1.Text + ":";
            sql = "SELECT * FROM EX2_Scores WHERE DatumOpgeslagen >= curdate() - interval 1 week ORDER BY EX2_Scores.Score DESC  LIMIT " + gekozenlimiet;
            toonData(sql);
        }

        private void button2_Click_1(object sender, EventArgs e)//Scores voorbije maand
        {
            label1.Visible = false;
            CMBkeuzePeriode.Visible = false;
            sql = "SELECT * FROM EX2_Scores WHERE DatumOpgeslagen >= curdate() - interval 1 month ORDER BY EX2_Scores.Score DESC LIMIT " + gekozenlimiet;
            toonData(sql);
            lblHighScore.Text = button2.Text + ":";
        }

        private void button3_Click_1(object sender, EventArgs e)//Voorbije jaar scores zien
        {
            label1.Visible = false;
            CMBkeuzePeriode.Visible = false;
            lblHighScore.Text = button3.Text + ":";
            sql = "SELECT * FROM EX2_Scores WHERE DatumOpgeslagen >= curdate() - interval 1 year ORDER BY EX2_Scores.Score DESC LIMIT " + gekozenlimiet;
            toonData(sql);
        }

        private void button4_Click_1(object sender, EventArgs e)//Globale highscore
        {
            label1.Visible = false;
            CMBkeuzePeriode.Visible = false;
            lblHighScore.Text = button4.Text + ":";
            sql = "SELECT * FROM EX2_Scores ORDER BY `EX2_Scores`.`Score` DESC LIMIT " + gekozenlimiet;
            toonData(sql);
        }

        private void CMBkeuzePeriode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CMBkeuzePeriode.SelectedIndex == 4)
            {
                string sql1 = "SELECT * FROM EX2_Scores WHERE Gamertag = @nick ORDER BY `EX2_Scores`.`Score` DESC LIMIT " + gekozenlimiet;
                toonData(sql1);
                errorNogNietGespeeld();
            }
            if (CMBkeuzePeriode.SelectedIndex == 3)
            {
                string sql2 = "SELECT * FROM EX2_Scores WHERE Gamertag = @nick AND  DatumOpgeslagen >= curdate() - interval 1 month ORDER BY `EX2_Scores`.`Score` DESC LIMIT " + gekozenlimiet;
                toonData(sql2);
                errorNogNietGespeeld();
            }
            if (CMBkeuzePeriode.SelectedIndex == 2)
            {
                string sql3 = "SELECT * FROM EX2_Scores WHERE Gamertag = @nick AND  DatumOpgeslagen >= curdate() - interval 1 week ORDER BY `EX2_Scores`.`Score` DESC LIMIT " + gekozenlimiet;
                toonData(sql3);
                errorNogNietGespeeld();
            }
            if (CMBkeuzePeriode.SelectedIndex == 1)
            {
                string sql4 = "SELECT * FROM EX2_Scores WHERE Gamertag = @nick AND  DatumOpgeslagen >= curdate() - interval 1 day ORDER BY `EX2_Scores`.`Score` DESC LIMIT " + gekozenlimiet;
                toonData(sql4);
                errorNogNietGespeeld();
            }
            if (CMBkeuzePeriode.SelectedIndex == 0)
            {
                string sql4 = "SELECT * FROM EX2_Scores WHERE Gamertag = @nick ORDER BY `EX2_Scores`.`DatumOpgeslagen`";
                toonData(sql4);
                errorNogNietGespeeld();
            }
        }

        private void CMBAantal_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CMBAantal.SelectedIndex == 0)
            {
                gekozenlimiet = 5;
                MessageBox.Show("klik terug op de knop die je gekozen hebt om de filter op te starten");
            }
            if (CMBAantal.SelectedIndex == 1)
            {
                gekozenlimiet = 10;
                MessageBox.Show("klik terug op de knop die je gekozen hebt om de filter op te starten");
            }
            if (CMBAantal.SelectedIndex == 2)
            {
                gekozenlimiet = 20;
                MessageBox.Show("klik terug op de knop die je gekozen hebt om de filter op te starten");
            }
            if (CMBAantal.SelectedIndex == 3)
            {
                gekozenlimiet = 50;
                MessageBox.Show("klik terug op de knop die je gekozen hebt om de filter op te starten");
            }
            if (CMBAantal.SelectedIndex == 4)
            {
                MessageBox.Show("klik terug op de knop die je gekozen hebt om de filter op te starten");
                gekozenlimiet = 100;
            }
        }
    }
}
