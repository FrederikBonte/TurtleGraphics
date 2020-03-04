using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileReader
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Create a variable to store the stream (of characters from the file).
            Stream fileStream = null;
            // Reading files may cause an exception. Prepare for that.
            try
            {
                // Open the selected file.
                fileStream = openFileDialog.OpenFile();
                // User a StreamReader to be able to read lines...
                StreamReader reader = new StreamReader(fileStream);

                // Create a variable to store each line.
                string line;
                // Repeat the following...
                do
                {
                    line = reader.ReadLine();

                    if (line != null)
                    {
                        // ... Do Stuff with the line...
                    }
                } while (line != null);
                // ... until the end of the file is reached.
            }
            catch (Exception)
            {
                // Let the user know things failed.
                MessageBox.Show("Failed to read the content of '" + openFileDialog.FileName);
            }
            finally // Do this ALWAYS, after the try block is done.
            { // When an error occurred, but also when everything worked perfectly.
                // Close the file. 
                fileStream.Close();
            }
        }
    }
}
