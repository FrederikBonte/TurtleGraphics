using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyChess
{
    class ChessBoard
    {
        // Prive lijst met "stukken".
        private int[] pieces;

        public void setSquares(int length)
        {
            // Maak een nieuwe lijst aan met de gegeven lengte
            pieces = new int[length];

            // Loop langs alle elementen van de lijst.
            for (int i = 0; i < pieces.Length; i++)
            {
                // In deze kolom staat GEEN stuk.
                pieces[i] = -1;
            }
        }

        public bool hasPiece(int column = 0)
        {
            return pieces[column] > -1;
        }

        public void placePiece(int column, int row=0)
        {
            pieces[column] = row;
        }

        public void removePiece(int column)
        {
            placePiece(column, -1);
        }

        public bool canMove(int column)
        {
            return pieces[column] < (pieces.Length - 1);
        }

        public void movePiece(int column)
        {
            pieces[column]++;

        }

        public int difference(int a, int b)
        {
            return (a>b)?a-b:b-a;
        }

        public bool canBeTaken(int column)
        {
            if (!hasPiece(column))
            {
                return false;
            }
            else
            {
                for (int i = 0; i < pieces.Length; i++)
                {
                    if (!hasPiece(i))
                    {

                    }
                    else if (i == column)
                    {

                    }
                    else if (pieces[i]==pieces[column])
                    {
                        return true;
                    }
                    else
                    {
                        int columnDiff = difference(i, column);
                        int posI = pieces[i];
                        int posColumn = pieces[column];
                        int posDiff = difference(posI, posColumn);
                        if (columnDiff == posDiff)
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
        }

        public bool solve(int startColumn)
        {
            int column = startColumn;

            do
            {
                if (hasPiece(column))
                {
                    if (canMove(column))
                    {
                        movePiece(column);
                    }
                    else
                    {
                        removePiece(column);
                        column--;
                        if (column == -1)
                        {
                            return false;
                        }
                        continue;
                    }
                }
                else
                {
                    placePiece(column);
                }
                if (!canBeTaken(column))
                {
                    column++;
                }
            } while (column < pieces.Length);

            return true;
        }

        public void print()
        {
            for (int i = 0; i < pieces.Length; i++)
            {
                Console.WriteLine("pieces[" + i + "] = " + pieces[i]);
            }
        }
    }
}
