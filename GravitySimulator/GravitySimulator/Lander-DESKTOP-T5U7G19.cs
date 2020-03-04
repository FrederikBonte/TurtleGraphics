using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GravitySimulator
{
    class Lander
    {
        public double MAX_LANDING_SPEED = -5;

        private double
            altitude,   // How high up are we?
            speed,      // How fast are we going - is down, + is up... 
            fuel;       // How much fuel is left? 1 fuel == 1 additional mass.
        private readonly double
            mass,       // How heavy is the craft?
            thruster;   // How hard can the engines push?
        private int thrust = 0;
        private long ticks = DateTime.Now.Ticks;
        private bool crashed = false, landed = false;

        public Lander(int seed = -1)
        {
            Random RNG = (seed == -1) ? new Random() : new Random(seed);
            altitude = (1 + RNG.NextDouble() * 9) * 1000;
            mass = (1 + RNG.NextDouble() * 6) * 5;
            speed = 0;
            fuel = 20;
            thruster = (11 + RNG.NextDouble() * 9) * 0.02;
        }

        public void update()
        {
            if (landed||crashed)
            {
                return;
            }

            // How much time passed since last update (in Seconds!)
            long now = DateTime.Now.Ticks;
            double delta = (now - ticks) / 10000000.0;
            ticks = now;

            double Fdown = delta;
            double Fup = (fuel == 0) ? 0 : thrust * thruster / (mass + fuel);
            fuel = Math.Max(0, fuel - (delta * thrust * 0.03));

            speed += (Fup - Fdown);
            altitude += speed * delta;

            if (altitude < 0)
            {
                crashed = (speed < MAX_LANDING_SPEED);
                landed = !crashed;
                altitude = 0;
                speed = 0;
                thrust = 0;
            }
        }

        public bool IsLanded
        {
            get { return this.landed; }
        }

        public bool IsCrashed
        {
            get { return this.crashed; }
        }

        public double Altitude
        {
            get { return (altitude < 5000) ? altitude : -1; }
        }

        public double Speed
        {
            get { return this.speed; }
        }

        public double Fuel
        {
            get { return this.fuel * 1000; }
        }

        public int Thrust
        {
            get { return this.thrust; }
            set { this.thrust = clamp(0, value, 10);  }
        }

        private int clamp(int min, int value, int max)
        {
            if (value<min)
            {
                return min;
            } else if (value>max)
            {
                return max;
            } else
            {
                return value;
            }
        }
    }
}
