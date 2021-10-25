using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flappy0sv3
{
    public class FlappyDB
    {
        MySqlConnection connection;

        public FlappyDB()
        {
            string server = "localhost";
            int port = 3306;
            string database = "flappy";
            string username = "root";
            string password = "usbw";

            string connectionString =
                 "SERVER="   + server +
                ";PORT="     + port +
                ";DATABASE=" + database +
                ";UID="      + username +
                ";PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);

            if (OpenConnection())
            {
                // Yay gelukt!
                connection.Close();
            }
            else
            {
                MessageBox.Show("Could not connect to the database.");
            }
        }
    

        private bool OpenConnection()
        {
            connection.Open();
            return true;
        }

        // Read all highscores.
        // Read score to beat.
        // Add new score to the database
        // Reset the highscore list?

        public void readHighScore()
        {
            // Execute this query
            string query = "SELECT * FROM high_score";

            // Open the connection
            connection.Open();

            // Send the query to the db server.
            MySqlCommand cmd = new MySqlCommand(query, connection);

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                string name = reader.GetString("name");
                int score = reader.GetInt32("score");

                Console.WriteLine(name + " : " + score);
            }

            reader.Close();

            connection.Close();
        }
    }
}
