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
        private MySqlConnection connection;

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
            //connection = new MySqlConnection(connectionString);
        }

        public void readHighScore()
        {
            // Design the correct query.
            string query = "SELECT * FROM high_score";

            // Open the connection to the database.
            //connection.Open();

            // Prepare to send the query to the database server.
            MySqlCommand cmd = new MySqlCommand(query, connection);

            // Execute the query.
            MySqlDataReader reader = cmd.ExecuteReader();

            // Read all the available record.
            while (reader.Read())
            {
                string name = reader.GetString("name");
                int score = reader.GetInt32("score");
                DateTime time = reader.GetDateTime("time");

                Console.WriteLine(
                    name + " : " + 
                    score + " (" + 
                    time.ToString("yyyyMMdd HH:mm tt") + 
                    ")"
                );
            }

            // Stop using the reader.
            reader.Close();

            // Clear the connection.
            connection.Close();
        }
    }
}
