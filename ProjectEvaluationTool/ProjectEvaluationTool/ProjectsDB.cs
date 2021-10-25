using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectEvaluationTool
{
    public class ProjectsDB
    {
        private readonly MySqlConnection connection;
        private readonly Dictionary<int, CreditMethod> cmethods = null;
        // All criteria
        private readonly Dictionary<int, Criterium> criteria = null;
        // All CritGroups...
        private readonly Dictionary<int, CriteriumGroup> critGroups = null;
        // CritGroups that are the main group of a project.
        private readonly Dictionary<int, CriteriumGroup> projectCritGroups = new Dictionary<int, CriteriumGroup>();
        private readonly Dictionary<int, Project> projects = null;

        public ProjectsDB(string server, int port, string database, string username, string password)
        {
            string connectionString =
                "SERVER=" + server +
                ";PORT=" + port +
                ";DATABASE=" + database +
                ";UID=" + username +
                ";PASSWORD=" + password + ";";
            this.connection = new MySqlConnection(connectionString);
            if (!isConnectionOK())
            {
                return;
            }
            this.cmethods = ReadCreditMethods();
            this.criteria = ReadCriteria();
            this.critGroups = ReadCriteriaGroups();
            this.projects = ReadProjects();
        }

        public bool isConnectionOK()
        {
            bool result = OpenConnection();
            CloseConnection();
            return result;
        }

        //open connection to database
        private bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                //When handling errors, you can your application's response based 
                //on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        MessageBox.Show("Invalid username/password, please try again");
                        break;
                }
                return false;
            }
        }

        internal void SaveEvaluation(string code, int student, int groep, Dictionary<int, NumericUpDown> nums)
        {
            string today = getToday();
            foreach (KeyValuePair<int, NumericUpDown> pair in nums)
            {
                SaveEvaluation(code, student, groep, pair.Key, today, (int)pair.Value.Value);
            }
        }

        private void SaveEvaluation(string code, int student, int group, int criterium, string today, int value)
        {
            string query = "INSERT INTO beoordeling VALUES (@docent, @student, @groep, @crit, @date, @value)";

            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);

                cmd.Parameters.AddWithValue("@docent", code);
                cmd.Parameters.AddWithValue("@student", student);
                cmd.Parameters.AddWithValue("@groep", group);
                cmd.Parameters.AddWithValue("@crit", criterium);
                cmd.Parameters.AddWithValue("@date", today);
                cmd.Parameters.AddWithValue("@value", value);

                // @TODO: Add a try catch block...
                cmd.ExecuteNonQuery();

                //close Connection
                this.CloseConnection();
            }
        }

        //Close connection
        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public void ReadTeachers(ComboBox target)
        {
            string query = "SELECT * FROM docent ORDER BY achternaam, voornaam";
            target.Items.Clear();

            //Open connection
            if (OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    Teacher teacher = new Teacher(
                        dataReader.GetString("code"),
                        dataReader.GetString("voornaam"),
                        dataReader.GetString("achternaam"),
                        dataReader.GetString("aanspreekvorm")
                        );
                    target.Items.Add(teacher);
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                CloseConnection();
            }
        }

        public void SaveEvaluation(string code, int student, int seconds, string notes, int result = -1)
        {
            string query = "INSERT INTO evaluatie VALUES (@docent, @student, @date, @time, @note, @result)";

            string today = getToday();
            string time = "00:" + (seconds / 60).ToString("D2") + ":" + (seconds % 60).ToString("D2");

            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);

                cmd.Parameters.AddWithValue("@docent", code);
                cmd.Parameters.AddWithValue("@student", student);
                cmd.Parameters.AddWithValue("@date", today);
                cmd.Parameters.AddWithValue("@time", time);
                cmd.Parameters.AddWithValue("@note", notes);
                cmd.Parameters.AddWithValue("@result", result);

                // @TODO: Add a try catch block...
                cmd.ExecuteNonQuery();

                //close Connection
                this.CloseConnection();
            }

        }

        public SortedSet<Note> ReadNotes(string code, int student) //, string date)
        {
            string query = "SELECT * FROM evaluatie WHERE docentcode = @docent AND studentnummer = @student ORDER BY datum";

            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);

                cmd.Parameters.AddWithValue("@docent", code);
                cmd.Parameters.AddWithValue("@student", student);
//                cmd.Parameters.AddWithValue("@datum", date);

                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                SortedSet<Note> notes = new SortedSet<Note>();
                Console.WriteLine("Notes for " + student);
                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    Note note = new Note(
                        dataReader.GetDateTime("datum"),
                        dataReader.GetString("notitie")
                        );
                    Console.WriteLine(" (" + note.getDate() + ") --> " + note.getText());
                    notes.Add(note);
                }

                string today = getToday();
                if (notes.Count==0 || toDate(notes.Last().getDate())!= today)
                {
                    notes.Add(new Note(DateTime.Now, "", false));
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();

                return notes;
            }

            return null;
        }

        internal bool CanEvaluate(string code, int student, int group_id)
        {
            string today = getToday();
            string query = "SELECT * " +
                "FROM beoordeling " +
                "WHERE docentcode = @dcode " +
                "AND leerlingnummer = @llnr " +
                "AND groepid = @groupid " +
                "AND datum = @date";
            bool result = false;
            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);

                cmd.Parameters.AddWithValue("@dcode", code);
                cmd.Parameters.AddWithValue("@llnr", student);
                cmd.Parameters.AddWithValue("@groupid", group_id);
                cmd.Parameters.AddWithValue("@date", today);


                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                // Return false if the project was already evaluated today!
                result = !dataReader.HasRows;

                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();
            }

            return result;
        }

        public string getToday()
        {
            return toDate(DateTime.Now);
        }

        public string toDate(DateTime date)
        {
            return date.ToString("yyyy-MM-dd");
        }

        public void ReadClasses(string code, CheckedListBox target)
        {
            string query = "SELECT * FROM klas WHERE code in (SELECT klascode FROM docent_klas WHERE docentcode = @code ) ORDER BY code";
            target.Items.Clear();

            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);

                cmd.Parameters.AddWithValue("@code", code);
                
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    target.Items.Add(dataReader.GetString("code"));
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();
            }

        }

        public Dictionary<string, List<Student>> ReadStudents(string code)
        {
            Dictionary<string, List<Student>> students = new Dictionary<string, List<Student>>();

            // This query is stupid. It needs to reorder the students again. 
            // Rethink the niet_gesproken_leerlingen view...
            string query = "SELECT nummer, klas, concat_ws(' ', voornaam, tussenvoegsel, achternaam) as naam FROM niet_gesproken_leerlingen WHERE klas in (SELECT klascode FROM docent_klas WHERE docentcode = @code ) ORDER BY datum asc, rand()";

            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);

                cmd.Parameters.AddWithValue("@code", code);

                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    string klas = "" + dataReader["klas"];
                    Student student = new Student(
                        dataReader.GetInt32("nummer"),
                        dataReader.GetString("naam")
                        );
                    List<Student> list;
                    if (students.ContainsKey(klas))
                    {
                        list = students[klas];
                    } else
                    {
                        list = new List<Student>();
                        students.Add(klas, list);
                    }
                    list.Add(student);

                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();
            }

            return students;
        }

        public CreditMethod getCreditMethod(int id)
        {
            return cmethods[id];
        }

        private Dictionary<int, CreditMethod> ReadCreditMethods()
        {
            Dictionary<int, CreditMethod> result = new Dictionary<int, CreditMethod>();

            string query = "SELECT * FROM beoordeling_methode";

            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    CreditMethod cm = new CreditMethod(
                        dataReader.GetInt32("id"),
                        dataReader.GetString("naam"),
                        dataReader.GetString("omschrijving"),
                        dataReader.GetByte("min"),
                        dataReader.GetByte("max")
                        );
                    result.Add(cm.getId(), cm);
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();
            }

            return result;
        }

        private Dictionary<int, Criterium> ReadCriteria()
        {
            Dictionary<int, Criterium> result = new Dictionary<int, Criterium>();

            string query = "SELECT * FROM criterium";

            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    Criterium crit = new Criterium(
                        dataReader.GetInt32("id"),
                        dataReader.GetString("naam"),
                        dataReader.GetString("omschrijving"),
                        getCreditMethod(dataReader.GetInt32("methodeid"))
                        );
                    result.Add(crit.getId(), crit);
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();
            }

            return result;
        }

        private Dictionary<int, CriteriumGroup> ReadCriteriaGroups()
        {
            Dictionary<int, CriteriumGroup> result = new Dictionary<int, CriteriumGroup>();

            string query1 = "SELECT * FROM criterium_groep";
            string query2 = "SELECT * FROM project_criterium";

            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query1, connection);

                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    CriteriumGroup group = new CriteriumGroup(
                        dataReader.GetInt32("id"),
                        dataReader.GetByte("methode"),
                        dataReader.GetString("naam")
                        );
                    if (!dataReader.IsDBNull(1))
                    {
                        int group_id = dataReader.GetInt32("parent_groep");
                        result[group_id].Add(group);
                    }
                    else if (!dataReader.IsDBNull(2))
                    {
                        int project_id = dataReader.GetInt32("parent_project");
                        projectCritGroups.Add(project_id, group);
                    }
                    else
                    {
                        throw new Exception("Both values are null!");
                    }
                    result.Add(group.getId(), group);
                }

                //close Data Reader
                dataReader.Close();

                cmd = new MySqlCommand(query2, connection);

                dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    int groupId = dataReader.GetInt32("groepid");
                    int criteriumId = dataReader.GetInt32("criteriumid");
                    ProjectCriterium criterium = new ProjectCriterium(
                        result[groupId],
                        criteria[criteriumId],
                        dataReader.GetFloat("gewicht"),
                        dataReader.GetBoolean("actief")
                        );
                    result[groupId].Add(criterium);
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();
            }

            // Make it clear that all groups are at this point stored
            // in the database. There are no changes that should be saved.
            foreach (CriteriumGroup group in result.Values)
            {
                group.store();
            }

            return result;
        }

        public List<Project> getProjects()
        {
            List<Project> result = this.projects.Values.ToList<Project>();
            result.Add(new Project(-1, "New project", "Project description", 2, 1, new CriteriumGroup()));
            return result;
        }

        public Dictionary<int, Project> ReadProjects()
        {
            Dictionary < int,  Project> result = new Dictionary<int, Project>();

            string query = "SELECT * FROM project";

            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    int projectId = dataReader.GetInt32("id");
                    CriteriumGroup group = null;
                    if (projectCritGroups.ContainsKey(projectId))
                    {
                        group = projectCritGroups[projectId];
                    } else
                    {
                        group = new CriteriumGroup();
                    }
                    Project project = new Project(
                        projectId,
                        dataReader.GetString("naam"),
                        dataReader.GetString("omschrijving"),
                        dataReader.GetByte("semester"),
                        dataReader.GetByte("sterren"),
                        group
                        );                    
                    result.Add(projectId, project);
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();
            }

            return result;
        }
    }
}
