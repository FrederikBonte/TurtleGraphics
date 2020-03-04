using Queens;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QueensTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSolve_Click(object sender, EventArgs e)
        {
            solve(chooseColumn());
        }

        private void solve(int startColumn)
        {
            int column = startColumn;
            while (column<board.Squares)
            {
                if (canMove(column))
                {
                    Piece p = placeOrMove(column);
                    if (!board.canBeTaken(p))
                    {
                        column++;
                    }
                } else
                {
                    board.removePiece(column);
                    column--;

                    if (column==-1)
                    {
                        MessageBox.Show("No more solutions...");
                        break;
                    }
                }
            }
        }

        private int chooseColumn()
        {
            int result = 0;
            for (int i=0;i<board.Squares;i++)
            {
                if (board.getPiece(i)!=null)
                {
                    result = i;
                }
            }
            return result;
        }

        public bool canMove(int column)
        {
            Piece p = board.getPiece(column);
            if (p==null)
            {
                return true;
            } else
            {
                return p.getRow() < (board.Squares - 1);
            }
        }

        public Piece placeOrMove(int column)
        {
            Piece result = board.getPiece(column);
            if (result==null)
            {
                result = board.placePiece(0, column);
            } else
            {
                result.setRow(result.getRow() + 1);
            }
            return result;
        }
    }
}
