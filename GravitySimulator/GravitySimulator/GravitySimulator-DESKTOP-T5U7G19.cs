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
        private readonly Lander lander = new Lander(12345);

        public GravitySimulator()
        {
            InitializeComponent();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            lander.update();
            this.txtAltitude.Text = (lander.Altitude == -1) ? "unknown" : lander.Altitude.ToString($"F{2}");
            this.txtSpeed.Text = lander.Speed.ToString($"F{2}");
            this.proFuel.Value = (int)Math.Round(lander.Fuel);
            this.lblCrashed.Visible = lander.IsCrashed;
            this.lblLanded.Visible = lander.IsLanded;
            this.trkThrust.Value = lander.Thrust;
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
    }
}
