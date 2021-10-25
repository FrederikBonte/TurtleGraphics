using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectEvaluationTool
{
    public partial class Form1 : Form
    {
        private readonly Random RNG = new Random();
        //private readonly string server = "localhost";
        //private readonly string database = "projecten";
        //private readonly string uid = "root";
        //private readonly string password = "usbw";
        private ProjectsDB db = new ProjectsDB("localhost", 3306, "projecten", "root", "usbw");
        private Dictionary<string, List<Student>> students;
        private SortedSet<Note> notes = null;
        private int index = -1;
        private DateTime timeStart;
        private bool started = false;

        public Form1()
        {
            InitializeComponent();
            tabTalk.Hide();
            lstClasses.Items.Clear();
            updateStudentsAndTime();
        }

        private void loadProjects()
        {
            cmbProjects.DataSource = db.getProjects();
            cmbProjectEval.DataSource = db.getProjects();
        }

        private void cmbTeacher_SelectedIndexChanged(object sender, EventArgs e)
        {
            students = db.ReadStudents(((Teacher)cmbTeacher.SelectedItem).getCode());
            foreach (string klas in students.Keys)
            {
                lstClasses.Items.Add(klas);
            }
            updateStudentsAndTime();
        }

        
        private void updateStudentsAndTime()
        {
            cmbStudents.Items.Clear();
            for (int i = 0; i < lstClasses.CheckedItems.Count; i++)
            {
                string clazz = lstClasses.CheckedItems[i].ToString();
                string name = clazz.Split(' ')[0];
                cmbStudents.Items.AddRange(students[name].ToArray());
            }
            int total = cmbStudents.Items.Count;
            this.txtStudentCount.Text = "" + total;
            int minutes = (int)numTime.Value;
            // Set the conversation timer to the correct time.
            txtTime.Text = minutes + ":00";
            txtTime.ForeColor = Color.LightGreen;
            // Calculate the total time.
            int time = minutes * 60;
            minutes *= total;
            int hours = minutes / 60;
            minutes = minutes % 60;
            txtTotalTime.Text = hours + ":" + minutes.ToString("D2");
            if (total>0)
            {
                tableLayoutPanel2.Visible = true;
            } else
            {
                tableLayoutPanel2.Visible = false;
            }
        }

        private void lstClasses_ItemCheck(object sender, ItemCheckEventArgs e)
        {
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (tabMain.SelectedIndex==0)
            {
                updateStudentsAndTime();
            } 
            else if (tabMain.SelectedIndex==1)
            {
                updateTime();
            }
        }

        private void updateTime()
        {
            // Store the requested time per student.
            int minutes = (int)numTime.Value;
            if (started)
            {
                TimeSpan span = DateTime.Now - timeStart;
                int seconds = (int)Math.Round(span.TotalSeconds);
                minutes *= 60;
                minutes -= seconds;
                if (minutes<0)
                {
                    txtTime.Text = "0:00";
                    txtTime.ForeColor = Color.Red;
                } else
                {
                    txtTime.Text =
                        (minutes / 60).ToString() + ":" +
                        (minutes % 60).ToString("D2");
                    txtTime.ForeColor = (minutes < 30) ? ((minutes<10)?Color.Red:Color.Yellow) : Color.Green;
                }
            } else
            {
                // Set the conversation timer to the correct time.
                txtTime.Text = minutes + ":00";
                txtTime.ForeColor = Color.LightGreen;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Check that there is a connection to the database...
            if (!db.isConnectionOK())
            {
                // Let the user know that we're shutting down!
                MessageBox.Show("There is no connection to the database!", "Bad Connection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            } else
            {
                // Fill the project comboboxes.
                loadProjects();
                // Fill the teachers combobox.
                db.ReadTeachers(cmbTeacher);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Teacher teacher = (Teacher)cmbTeacher.SelectedItem;
            Student student = (Student)cmbStudents.SelectedItem;
            TimeSpan span = DateTime.Now - timeStart;
            int seconds = (int)Math.Round(span.TotalSeconds);
            if (student==null)
            {
                MessageBox.Show("Please select a student!");
            }
            db.SaveEvaluation(teacher.getCode(), student.getNumber(), seconds, txtNotes.Text);
            btnSave.Enabled = false;
            txtNotes.Enabled = false;
            btnStart.Enabled = false;
            started = false;
//            timeStart = null; // FU Micro$oft!!!
        }

        private void cmbStudents_SelectedValueChanged(object sender, EventArgs e)
        {
            Teacher teacher = (Teacher)cmbTeacher.SelectedItem;
            Student student = (Student)cmbStudents.SelectedItem;
            if (student!=null)
            {
                this.notes = db.ReadNotes(teacher.getCode(), student.getNumber());
                index = this.notes.Count-1;
                updateNote();
                UpdateEvaluateButton();
            }
            else
            {
                this.notes = null;
                index = -1;
                updateNote();
                UpdateEvaluateButton();
            }
        }

        private void updateNote()
        {
            if (index==-1)
            {
                txtNotes.Text = "";
                btnSave.Enabled = false;
                btnStart.Enabled = false;
                txtNotes.Enabled = false;
            }
            else
            {
                Note note = notes.ElementAt(index);
                txtNotes.Text = note.getText();
                btnStart.Enabled = !note.isSaved() && !started;
                txtNotes.Enabled = !note.isSaved() && started;
                btnSave.Enabled = !note.isSaved() && started;
            }
        }

        private void cmbProjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            Project p = (Project)cmbProjects.SelectedItem;
            numSemester.Value = p.getSemester();
            numStars.Value = p.getStars();
            txtDescription.Text = p.getDescription();
            lstCriteria.Items.Clear();
            if (p.getGroup()!=null)
            {
                foreach (ProjectCriterium criterium in p.getGroup().getCriteria())
                {
                    lstCriteria.Items.Add(criterium);
                }
            }
            btnAddCrit.Enabled = true;
            btnEditCrit.Enabled = false;
            btnSaveProj.Enabled = !p.isSaved();
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (index>0)
            {
                notes.ElementAt(index).setText(txtNotes.Text);
                index--;
            }
            updateNote();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (index != -1 && index<notes.Count-1) {
                index++;
            }
            updateNote();
        }

        private void btnEvaluate_Click(object sender, EventArgs e)
        {
            Project project = (Project)cmbProjectEval.SelectedItem;
            Teacher teacher = (Teacher)cmbTeacher.SelectedItem;
            Student student = (Student)cmbStudents.SelectedItem;
            WaarderingForm wdf = new WaarderingForm(db, teacher, student, project);
            if (wdf.ShowDialog() == DialogResult.OK)
            {
                btnEvaluate.Enabled = false;
            }
        }

        private void cmbProjectEval_SelectedValueChanged(object sender, EventArgs e)
        {
            UpdateEvaluateButton();
        }

        private void UpdateEvaluateButton()
        { 
            Project project = (Project)cmbProjectEval.SelectedItem;
            Teacher teacher = (Teacher)cmbTeacher.SelectedItem;
            Student student = (Student)cmbStudents.SelectedItem;
            if (project==null || teacher==null || student==null || project.getGroup()==null)
            {
                btnEvaluate.Enabled = false;
            } else
            {
                btnEvaluate.Enabled = db.CanEvaluate(teacher.getCode(), student.getNumber(), project.getGroup().getId());
            }
        }

        private void txtTime_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            this.timeStart = DateTime.Now;
            started = true;
            updateNote();
            txtNotes.Focus();
        }

        private void cmbProjects_KeyPress(object sender, KeyPressEventArgs e)
        {
            Project project = (Project)cmbProjects.SelectedItem;
            project.rename(cmbProjects.Text, project.getDescription());
        }

        private void txtDescription_KeyPress(object sender, KeyPressEventArgs e)
        {
            Project project = (Project)cmbProjects.SelectedItem;
            project.setDescription(txtDescription.Text);
        }
    }
}
