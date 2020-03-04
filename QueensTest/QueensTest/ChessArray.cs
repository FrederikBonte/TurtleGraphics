using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueensTest
{
    class ChessArray
    {
        private int[] pieces;

        public int Squares
        {
            get { return this.pieces.Length; }
            set { this.pieces = new int[value]; clearBoard(); }
        }

        public ChessArray(int size = 8)
        {
            this.Squares = size;
        }

        public void clearBoard()
        {
            for (int i=0;i<pieces.Length;i++)
            {
                pieces[i] = -1;
            }
        }

        public bool hasPiece(int column)
        {
            return this.pieces[column] != -1;
        }

        public bool canMove(int column)
        {
            return this.pieces[column] < this.pieces.Length - 1;
        }

        public void placeOrMove(int column)
        {
            this.pieces[column]++;
        }

        public void placePiece(int column, int row = 0)
        {
            this.pieces[column] = row;
        }

        public void removePiece(int column)
        {
            this.pieces[column] = -1;
        }

        public int difference(int a, int b)
        {
            if (a>b)
            {
                return a - b;
            } else
            {
                return b - a;
            }
        }

        public int chooseColumn()
        {
            int result = 0;
            for (int i = 0; i < this.pieces.Length; i++)
            {
                if (hasPiece(i))
                {
                    result = i;
                }
            }
            return result;
        }

        public bool canBeTaken(int column)
        {
            if (!hasPiece(column)) {
                return false;
            }
            for (int i = 0; i < pieces.Length; i++)
            {
                if (i == column)
                {
                    continue;
                } else if (!hasPiece(i))
                {
                    continue;
                }
                if (this.pieces[i] == this.pieces[column])
                {
                    return true;
                }
                if (difference(i,column) == difference(this.pieces[i], this.pieces[column]))
                {
                    return true;
                }
            }
            return false;
        }


        public void solve()
        {
            solve(chooseColumn());
        }

        public void solve(int startColumn)
        {
            int column = startColumn;
            while (column < pieces.Length)
            {
                if (canMove(column))
                {
                    placeOrMove(column);
                    if (!canBeTaken(column))
                    {
                        column++;
                    }
                }
                else
                {
                    removePiece(column);
                    column--;

                    if (column == -1)
                    {
                        Console.WriteLine("No more solutions...");
                        break;
                    }
                }
            }
        }

        public void show()
        {
            for (int i=0;i<this.pieces.Length;i++)
            {
                Console.WriteLine("Piece at column " + i + " is at row " + this.pieces[i] + ".");
            }
        }
    }
}
