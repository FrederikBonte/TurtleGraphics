using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UIDLists
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // Wis de huidige lijst met items.
            cmbStyle.Items.Clear();
            // Add a known set of items.
            cmbStyle.Items.Add(FontStyle.Regular);
            cmbStyle.Items.Add(FontStyle.Bold);
            cmbStyle.Items.Add(FontStyle.Italic);
            cmbStyle.Items.Add(FontStyle.Underline);
            cmbStyle.Items.Add(FontStyle.Strikeout);
            // Choose the first one.
            cmbStyle.SelectedIndex = 0;
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            if (txtExample.Text.StartsWith("Dit is een voorbeeld"))
            {
                txtExample.Text = "Dit is een voorbeeld tekst in '" + lstFont.SelectedItem + "'";
            }
            txtExample.Font = 
                new Font(
                    "" + lstFont.SelectedItem, 
                    (float)numSize.Value, 
                    (FontStyle)cmbStyle.SelectedItem
                );
        }
    }
}
