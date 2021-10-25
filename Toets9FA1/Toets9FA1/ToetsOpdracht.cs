using ROCvanTwente.Sumpel.Semester2.MazeGenerator;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toets9FA1
{
    /// <summary>
    /// Dit is de code die jullie mogen editen.
    /// Wijzigingen in ander code elders in het project zijn meestal niet toegestaan!
    /// </summary>
    public class ToetsOpdracht
    {
        private Maze maze;
        private MazeExplorer explorer;

        public ToetsOpdracht(Maze maze, MazeExplorer explorer)
        {
            this.maze = maze;
            this.explorer = explorer;
        }

        /// <summary>
        /// 10 punten
        /// </summary>
        /// <returns></returns>
        public bool tryTurnLeft()
        {
            // Draai naar links.
            // ALS je nu naar voren kunt.
            // DAN doe je dat.
            //      tevens return true.
            // ANDERS draai terug naar rechts.
            //      tevens return false.
            return false; // Deze regel hoort niet
        }

        /// <summary>
        /// 10 punten
        /// </summary>
        /// <returns></returns>
        public bool tryTurnRight()
        {
            // Draai naar rechts.
            // ALS je nu naar voren kunt.
            // DAN doe je dat.
            //     tevens return true
            // ANDERS draai terug naar rechts.
            //      also return false.
            return false; // Deze regel hoort niet
        }

        /// <summary>
        /// 10 punten
        /// </summary>
        /// <returns></returns>
        public bool tryForward()
        {
            //Moet je draaien?
            //KUN je naar voren?
            //WAT is dan jouw antwoord?
            //AND anders?
            return false; // Deze regel hoort niet
        }

        /// <summary>
        /// 10 punten
        /// </summary>
        /// <returns></returns>
        public bool tryTurnBack()
        {
            // Schrijf deze functie helemaal zelf.
            // Voor inspiratie zie eerdere functies.
            return false;
        }

        /// <summary>
        /// 10 punten
        /// </summary>
        public void takeOneStep()
        {
            // Probeer eerst naar links.
            // ALS Dat niet kan
            // Probeer naar voren.
            // ALS Dat niet kan...
            // Probeer naar rechts.
            // ALS DAT niet kan.
            // Probeer terug.
            // Technisch zou je nu vast kunnen zitten, maar dat gebeurt niet...
        }

        /// <summary>
        /// 15 punten
        /// </summary>
        /// <param name="g">Graphics om op te tekenenen</param>
        /// <param name="mx">marge x</param>
        /// <param name="my">marge y</param>
        /// <param name="size">grootte van het doolhof</param>
        public void tekenExplorer(Graphics g, int mx, int my, int size)
        {
            Pen b = new Pen(Color.Blue);
            // !!! TEKEN OPGAVE (in vijf eenvoudige stappen) !!!

            // Stap 1a teken een rechthoek van size bij size op de plek van de explorer.
            // (explorer.getX() en explorer.getY(), en gebruik de pen "b" variabele hierboven.)
            // Het onderstaande voorbeeld is dus fout...
            g.FillRectangle(b.Brush, this.explorer.getX()+100, this.explorer.getY()+100, 5, 5);

            // Stap 1b de locatie van de explorer houdt geen rekening met hoe groot het 
            // doolhof wordt getekend (size). Hou daar wel rekening mee!

            // Stap 2 deze rechthoek staat een klein stukje teveel naar links.
            // Gebruik de marge variabelen mx en my om 'm op te schuiven!

            // Stap 3 Jouw rechthoek vult nu het vak, maak jouw rechthoek 4 pixels kleiner (dan size bij size)

            // Stap 4 Jouw rechthoek staat nu links boven ten opzichte van het pad.
            // Schuif hem het juiste aantal pixels op.
        }

    }
}
