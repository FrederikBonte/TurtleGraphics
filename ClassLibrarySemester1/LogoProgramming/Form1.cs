using ROCvanTwente.Sumpel.Semester1.TurtleDrawing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogoProgramming
{
    public partial class Form1 : Form
    {
        private Stack<string> undo = new Stack<string>();
        private Stack<string> redo = new Stack<string>();

        private string[] demos =
        {
            "# move forward 90 steps\nFORWARD 90\n# turn 90 degrees to the right\nRIGHT 90\n# Do the same things again...\nFORWARD 90\nRIGHT 90\nFORWARD 90\nRIGHT 90\nFORWARD 90\nRIGHT 90",
            "# Do these actions 4 times\nREPEAT 4 {\n  FORWARD 90\n  RIGHT 90\n}",
            "# Store the value 15\nSET degrees = 15\nREPEAT 10 {\n  FORWARD 10\n  # Use the \"degrees\" to turn\n  RIGHT degrees\n}",
            "# Try to guess what this does\nSET DELAY 0\nSET THICKNESS 0.2\nSET degrees = 0\nSET twist = 1.007\nREPEAT 5000000 {\n  FORWARD 0.5\n  INCR degrees twist\n  LEFT degrees\n}",
            ""
        };
        private bool[] dirty = { false, false, false, false, false };
        public const int CUSTOM = 4;

        private int current = 4;
        private string filename = null;

        private Font bold;
        private Font italic;
        private Font regular;
        private bool pauseundo = false;

        public Form1()
        {
            InitializeComponent();
            regular = txtProgram.Font;
            bold = new Font(txtProgram.Font, FontStyle.Bold);
            italic = new Font(txtProgram.Font, FontStyle.Italic);
        }

        private void txtProgram_TextChanged(object sender, EventArgs e)
        {
        }

        private void updateSyntaxHighlight(RichTextBox txtBox)
        {
            int sStart = txtBox.SelectionStart;
            int sLength = txtBox.SelectionLength;
            clearFormatting(txtBox);
            formatKeywords(txtBox);
            formatSymbols(txtBox);
            formatValues(txtBox);
            txtBox.Select(sStart, sLength);
        }

        private void formatKeywords(RichTextBox txtBox)
        {
            string tokens = "(set delay|set thickness|set angle|reset|set|repeat|forward|back|left|right|rotate|incr|decr)";
            Regex rex = new Regex(tokens);
            MatchCollection mc = rex.Matches(txtBox.Text.ToLower());
            foreach (Match m in mc)
            {
                txtBox.Select(m.Index, m.Length);
                txtBox.SelectionColor = Color.Blue;
                txtBox.SelectionFont = bold;
                txtBox.SelectionStart = txtBox.Text.Length;
                txtBox.SelectionColor = Color.Black;
                txtBox.SelectionFont = regular;
            }
        }

        private void formatValues(RichTextBox txtBox)
        {
            string tokens = "([+-]?[0-9]+(\\.[0-9]*)?)";
            Regex rex = new Regex(tokens);
            MatchCollection mc = rex.Matches(txtBox.Text.ToLower());
            foreach (Match m in mc)
            {
                txtBox.Select(m.Index, m.Length);
                txtBox.SelectionColor = Color.Green;
                txtBox.SelectionStart = txtBox.Text.Length;
                txtBox.SelectionColor = Color.Black;
            }
        }

        private void formatSymbols(RichTextBox txtBox)
        {
            string tokens = "([\\[\\]\\(\\)\\{\\}+-])";
            Regex rex = new Regex(tokens);
            MatchCollection mc = rex.Matches(txtBox.Text.ToLower());
            foreach (Match m in mc)
            {
                txtBox.Select(m.Index, m.Length);
                txtBox.SelectionFont = bold;
                txtBox.SelectionStart = txtBox.Text.Length;
                txtBox.SelectionFont = regular;
            }
        }

        private void clearFormatting(RichTextBox txtBox)
        {
            txtBox.Select(0, txtBox.Text.Length);
            txtBox.SelectionStart = 0;
            txtBox.SelectionColor = Color.Black;
            txtBox.SelectionFont = regular;
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            Turtle turtle = this.painter.getTurtle("programmed");
            turtle.clear();
            StringWriter output = new StringWriter();
            TurtleReader reader = new TurtleReader(turtle, output);
            reader.readFromText(this.txtProgram.Text);
            reader = null;
            string errors = output.ToString();
            if (errors.Length > 0)
            {
                MessageBox.Show(errors, "Are these mistakes?");
            }
            if (chkClear.Checked)
            {
                this.painter.clear();
            }
            turtle.run();
        }

        private void txtProgram_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                if (e.KeyCode == Keys.Z)
                {
                    if (undo.Count > 0)
                    {
                        pauseundo = true;
                        string text = txtProgram.Text;
                        redo.Push(text);
                        txtProgram.Text = undo.Pop();
                        txtProgram.SelectionStart = txtProgram.Text.Length;
//                        Console.WriteLine("Undo stack : " + undo.Count + " (" + redo.Count + ")");
                    }
                    else
                    {
                        Console.Beep();
                    }
                }
                else if (e.KeyCode == Keys.Y)
                {
                    if (redo.Count > 0)
                    {
                        pauseundo = true;
                        string text = txtProgram.Text;
                        undo.Push(text);
                        txtProgram.Text = redo.Pop();
                        txtProgram.SelectionStart = txtProgram.Text.Length;
//                        Console.WriteLine("Redo stack : " + redo.Count + " (" + undo.Count + ")");
                    }
                    else
                    {
                        Console.Beep();
                    }
                }
            }
        }

        private void txtProgram_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (pauseundo)
            {
                pauseundo = false;
            }
            else
            {
                undo.Push(txtProgram.Text);
                updateSyntaxHighlight(txtProgram);
                demos[current] = txtProgram.Text;
                dirty[current] = true;
                redo.Clear();
//                Console.WriteLine("Undo stack : " + undo.Count + " (" + redo.Count + ")");
            }
        }

        private void SelectCode(int index)
        {
            current = index;
            txtProgram.Text = demos[current];
            updateSyntaxHighlight(txtProgram);
        }

        private void squareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelectCode(0);
        }

        private void repeatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelectCode(1);
        }

        private void variableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelectCode(2);
        }

        private void magicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelectCode(3);
        }

        private void customToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelectCode(CUSTOM);
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dirty[CUSTOM])
            {
                if (DialogResult.No == MessageBox.Show("Your custom program has not been saved. Are you sure you want to start a new program?", "Are you sure?", MessageBoxButtons.YesNo))
                {
                    return;
                }
            }
            dirty[CUSTOM] = false;
            demos[CUSTOM] = "";
            txtProgram.Text = "";
            SelectCode(CUSTOM);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (current == CUSTOM && filename!=null)
            {
                Console.WriteLine("About to save to : " + filename);
                File.WriteAllText(filename, demos[current]);
                dirty[current] = false;
            }
            else
            {
                saveAsToolStripMenuItem_Click(null, null);
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog()==DialogResult.OK)
            {
                Console.WriteLine("About to save to : " + saveFileDialog.FileName);
                if (current==CUSTOM)
                {
                    filename = saveFileDialog.FileName;
                }
                File.WriteAllText(saveFileDialog.FileName, demos[current]);
                dirty[current] = false;
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
