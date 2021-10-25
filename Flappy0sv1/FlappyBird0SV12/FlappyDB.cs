using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlappyBird0SV12
{
    public class FlappyDB
    {
        MySqlConnection myConnection;

        public void init()
        {
            string server = "localhost";
            int port = 3306;
            string database = "flappy";
            string username = "root";
            string password = "usbw";

            string connectionString =
                 "SERVER="      + server + 
                ";PORT="        + port +
                ";DATABASE="    + database +
                ";UID="         + username +
                ";PASSWORD="    + password + ";";

            myConnection = new MySqlConnection(connectionString);
        }

        public void readHighScore()
        {
            // Open de verbinding alleen als je 'm echt nodig hebt.
            myConnection.Open();

            // This is the query that we wish to run.
            string query = "SELECT * FROM high_score";

            MySqlCommand cmd = new MySqlCommand(query, myConnection);

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                string name = reader.GetString("name");
                int score = reader.GetInt32("score");

                Console.WriteLine(name + " : " + score);
            }

            // Netjes weer dicht doen.
            myConnection.Close();
        }
    }
}
