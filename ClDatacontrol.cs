using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace Skaterboy
{/*
    Ik ben Dewil Lucas, een 20 jarige leerling uit het GO! Atheneum Oudenaarde en ik studeer in 6 informaticabeheer.
    We kregen de opdracht van mevrouw Bauwens om een game te maken als eindexamen en ik besloot om een soort van 'Google Dinosaur'
    te maken, maar dan liefst iets dat mij een beetje typeerd. Dus kwam het idée om een skater te gebruiken als hoofdpersonage,
    en dit omdat ik zelf ook skate.Met deze game is het de bedoeling dat je zolang mogelijk overleefd, er zijn 2hindernissen , nl. een rail
    om er op te grinden en een vuilbak die je zeker moeten ontwijken. als je tegen een vuilbak botst verlies je het spel,
    en als je niet op de rail gesprongen hebt verlies je ook, je verdiend punten door de tijd die je overleefd, 
    hoe sneller de game zal gaan, hoe sneller je punten gaat verdienen.
    Met deze game heb ik denk ik kunnen bewijzen wat ik echt kon,en ik wou ook een succesvolle en vooral
    werkende game maken. Dit is dus mijn eindexamen, ik hoop dat u zich ook een beetje kan amuseren met mijn spel.

    04-06-2021
     */
    class ClDatacontrol
    {
        MySqlConnection connectie;
        MySqlDataAdapter daGegevens;
        private string connectieString;
        MySqlCommand com;
        string ingelogd;
        private int id;
        private int highScore;
        bool waarde;
        private bool datastatusOK;
        DataTable dtgegevens;
        private MySqlCommand cmd;
        int snelheid;
        public ClDatacontrol()
        {
            string pw = "lucDWil6Info@21";
            connectieString = "Server=83.217.67.11;Port=3306;SslMode = none;Database=06InfoLucas;Uid=06InfoLucas;Pwd=" + pw;
            connectie = new MySqlConnection();
            connectie.ConnectionString = connectieString;

            try
            {
                connectie.Open();
                datastatusOK = true;
                connectie.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.ToString());
                datastatusOK = false;
            }

        }
        public void checkData(string user, string pass, string sql, Byte[] img)
        {
            connectie.Open();
            ingelogd = "";
            try
            {
                object obj;
                com = new MySqlCommand(sql, connectie);
                com.CommandType = CommandType.Text;
                com.Parameters.AddWithValue("@nick", user);
                com.Parameters.AddWithValue("@pass", pass);
                com.Parameters.AddWithValue("@img", img);
                obj = com.ExecuteScalar();
                bool inlogOK = Convert.ToString(obj).Length != 0;//-1 of 0
                if (inlogOK == true)
                {
                    ingelogd = "ingelogd";
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex);
                if (ex.ErrorCode == -2147467259)//Errorcode voor Duplicate-> mag niet in mijn database
                {
                    ingelogd = "Account bestaat al!";
                }
                else
                {
                    ingelogd = ex.ToString();
                }

            }
            catch (Exception ex)
            {
                ingelogd = "Error " + ex.ToString();
            }
            connectie.Close();
        }

        public void Insert(string user, string pass, string sql, Byte[] img, Byte[] img2, Byte[] img3, Byte[] img4)
        {
            connectie.Open();
            ingelogd = "";
            try
            {
                object obj;
                com = new MySqlCommand(sql, connectie);
                com.CommandType = CommandType.Text;
                com.Parameters.AddWithValue("@nick", user);
                com.Parameters.AddWithValue("@pass", pass);
                com.Parameters.AddWithValue("@img", img);
                com.Parameters.AddWithValue("@img2", img2);
                com.Parameters.AddWithValue("@img3", img3);
                com.Parameters.AddWithValue("@img4", img4);
                obj = com.ExecuteScalar();
                bool inlogOK = Convert.ToString(obj).Length != 0;//-1 of 0
                if (inlogOK == true)
                {
                    ingelogd = "ingelogd";
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex);
                if (ex.ErrorCode == -2147467259)//Errorcode voor Duplicate-> mag niet in mijn database
                {
                    ingelogd = "Account bestaat al!";
                }
                else
                {
                    ingelogd = ex.ToString();
                }

            }
            connectie.Close();
        }


        public void checkData(string user, string sql)
        {
            ingelogd = "";
            try
            {
                connectie.Open();
                object obj;
                com = new MySqlCommand(sql, connectie);
                com.CommandType = CommandType.Text;
                com.Parameters.AddWithValue("@nick", user);
                obj = com.ExecuteNonQuery();
                bool inlogOK = Convert.ToString(obj).Length != 0;//-1 of 0
                if (inlogOK == true)
                {
                    ingelogd = "ingelogd";
                }
                connectie.Close();
            }
            catch (MySqlException ex)
            {
                ingelogd = ex.ToString();
            }

        }


        public void DELData(string user, string sql)
        {
            try
            {
                object obj;
                com = new MySqlCommand(sql, connectie);
                com.CommandType = CommandType.Text;
                com.Parameters.AddWithValue("@nick", user);
                obj = com.ExecuteNonQuery();
                connectie.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex);
            }

        }

        public void admin(string nick, string sql)
        {
            try
            {
                connectie.Open();

                com = new MySqlCommand(sql, connectie);
                com.CommandType = CommandType.Text;
                com.Parameters.AddWithValue("@nick", nick);
                waarde = (bool)com.ExecuteScalar();
                connectie.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex);
            }

        }






        public void nieuwPic(string sql, Byte[] img)
        {
            connectie.Open();
            try
            {
                object obj;
                com = new MySqlCommand(sql, connectie);
                com.CommandType = CommandType.Text;
                com.Parameters.AddWithValue("@img", img);
                obj = com.ExecuteNonQuery();

            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex);
            }
            connectie.Close();
        }
        public void DelAlles(string sql)
        {
            connectie.Open();
            try
            {
                object obj;
                com = new MySqlCommand(sql, connectie);
                com.CommandType = CommandType.Text;
                obj = com.ExecuteNonQuery();

            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex);
            }
            connectie.Close();
        }


        public DataTable getTabel(string sqldata, string us)
        {
            if (datastatusOK)
            {
                cmd = new MySqlCommand(sqldata, connectie);
                cmd.Parameters.AddWithValue("@nick", us);
                dtgegevens = new DataTable();
                daGegevens = new MySqlDataAdapter(cmd);//bv trein naar Ronse vanuit Gent
                try
                {
                    connectie.Open();
                    daGegevens.Fill(dtgegevens);
                    connectie.Close();
                }
                catch (MySqlException ex)
                {

                    Console.WriteLine(ex.ToString());
                    datastatusOK = false;
                }
            }
            return dtgegevens;
        }
        public int gamesnelheid(string user, string sql)
        {
            try
            {
                MySqlCommand com = connectie.CreateCommand();
                connectie.Open();
                com = new MySqlCommand(sql, connectie);
                com.CommandType = CommandType.Text;
                com.Parameters.AddWithValue("@nick", user);
                snelheid = Convert.ToInt32(com.ExecuteScalar());
                connectie.Close();
            }
            catch (MySqlException ex)
            {

                Console.WriteLine(ex.ToString());
                datastatusOK = false;
            }
            return snelheid;
        }

        public int ID(string user, string sql)
        {
            try
            {
                MySqlCommand com = connectie.CreateCommand();
                connectie.Open();
                com = new MySqlCommand(sql, connectie);
                com.CommandType = CommandType.Text;
                com.Parameters.AddWithValue("@nick", user);
                id = Convert.ToInt32(com.ExecuteScalar());
                connectie.Close();
            }
            catch (MySqlException ex)
            {

                Console.WriteLine(ex.ToString());
                datastatusOK = false;
            }
            return id;
        }

        public int getHIGHSCORE(string user, string sql)
        {
            try
            {
                MySqlCommand com = connectie.CreateCommand();
                connectie.Open();
                com = new MySqlCommand(sql, connectie);
                com.CommandType = CommandType.Text;
                com.Parameters.AddWithValue("@nick", user);
                highScore = Convert.ToInt32(com.ExecuteScalar());
                connectie.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.ToString());
                datastatusOK = false;
            }

            return highScore;
        }
        public int getSnelheid()
        {
            return snelheid;
        }
        public string getInlog()
        {
            return ingelogd;
        }
        public bool getAdmin()
        {
            return waarde;
        }
    }
}
