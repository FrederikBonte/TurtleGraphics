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
    public partial class WaarderingForm : Form
    {
        private readonly ProjectsDB db;
        private readonly Teacher teacher;
        private readonly Student student;
        private readonly Project project;
        private readonly Dictionary<int, NumericUpDown> nums = new Dictionary<int, NumericUpDown>();
        private readonly TextBox txtResult;

        public WaarderingForm(ProjectsDB db, Teacher teacher, Student student, Project project)
        {
            Label label;
            InitializeComponent();
            this.db = db;
            this.teacher = teacher;
            this.student = student;
            this.project = project;

            txtTeacher.Text = teacher.getName();
            txtStudent.Text = student.getName();
            txtProject.Text = project.getName();

            if (project.getGroup()==null)
            {
                return;
            }
            pnlWaardering.RowStyles.Clear();
            nums.Clear();
            foreach (ProjectCriterium crit in project.getGroup().getCriteria())
            {
                label = new Label();
                label.Text = crit.getCriterium().getName();
                label.Dock = DockStyle.Fill;
                NumericUpDown num = new NumericUpDown();
                num.Minimum = crit.getCriterium().getCreditMethod().getMin();
                num.Maximum = crit.getCriterium().getCreditMethod().getMax();
                num.Tag = crit.getWeight();
                num.ValueChanged += new EventHandler(updateResult);
                num.Dock = DockStyle.Fill;
                nums.Add(crit.getCriterium().getId(), num);
                pnlWaardering.RowStyles.Add(new RowStyle(SizeType.Absolute, 50));
                pnlWaardering.Controls.Add(label);
                pnlWaardering.Controls.Add(num);
            }
            label = new Label();
            label.Text = "Result : ";
            label.Dock = DockStyle.Fill;
            txtResult = new TextBox();
            txtResult.ReadOnly = true;
            pnlWaardering.RowStyles.Add(new RowStyle(SizeType.Absolute, 50));
            pnlWaardering.Controls.Add(label);
            pnlWaardering.Controls.Add(txtResult);
        }

        private void updateResult(object sender, EventArgs e)
        {
            float total = 0;
            foreach (NumericUpDown num in nums.Values)
            {
                total += (int)num.Value * (float)num.Tag;
            }
            txtResult.Text = ""+total;
        }

        private void Num_ValueChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Console.WriteLine("About to save stuff!");
            // @TODO: This only saves the criteria directly in the main group.
            // WHEN subgroups become possible a more complex method must be built!
            db.SaveEvaluation(teacher.getCode(), student.getNumber(), project.getGroup().getId(), nums);
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Don't save stuff!");
            Close();
        }
    }
}
