using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GravitySimulator
{
    public partial class GravitySimulator : UserControl
    {
        private readonly Lander lander = new Lander();

        public GravitySimulator()
        {
            InitializeComponent();
            this.landerGraphics1.setLander(lander);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            lander.update();
            this.txtAltitude.Text = (lander.Altitude == -1) ? "unknown" : ""+(int)Math.Round(lander.Altitude);
            this.txtSpeed.Text = ""+(int)Math.Round(lander.Speed);
            this.proFuel.Value = (int)Math.Round(lander.Fuel);
            this.lblCrashed.Visible = lander.IsCrashed;
            this.lblLanded.Visible = lander.IsLanded;
            this.trkThrust.Value = lander.Thrust;
            this.btnReset.Enabled = lander.IsCrashed;
        }

        public Lander Lander
        {
            get { return this.lander; }
        }

        private void btnMax_Click(object sender, EventArgs e)
        {
            lander.Thrust = 10000;
        }

        private void btnInc_Click(object sender, EventArgs e)
        {
            lander.Thrust++;
        }

        private void btnDec_Click(object sender, EventArgs e)
        {
            lander.Thrust--;
        }

        private void btnOff_Click(object sender, EventArgs e)
        {
            lander.Thrust = 0;
        }

        private void trkThrust_ValueChanged(object sender, EventArgs e)
        {
            lander.Thrust = trkThrust.Value;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            lander.reset();
        }
    }
}
