using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROCvanTwente.Sumpel.Semester1.Sudoku
{
    public class Sudoku
    {
        private const byte GIVEN = 16;
        private const byte NUMBER = 15;
        // Initiate the numbers with the universal sudoku seed.
        // 1 - 9 at the top.
        private byte[] numbers =
        {
            1,   2,   3,  4,  5,  6,  7,  8,  9,
            4,   5,   6,  7,  8,  9,  1,  2,  3,
            7,   8,   9,  1,  2,  3,  4,  5,  6,
            2,   3,   1,  5,  6,  4,  8,  9,  7,
            5,   6,   4,  8,  9,  7,  2,  3,  1,
            8,   9,   7,  2,  3,  1,  5,  6,  4,
            3,   1,   2,  6,  4,  5,  9,  7,  8,
            6,   4,   5,  9,  7,  8,  3,  1,  2,
            9,   7,   8,  3,  1,  2,  6,  4,  5
        };

        public Sudoku(byte[] numbers)
        {
            if (numbers.Count()!=81)
            {
                throw new Exception("Please supply exactly 81 numbers.");
            }
            this.numbers = numbers;
            checkSudoku();
        }

        public Sudoku(string[] lines)
        {
            if (lines.Count()!=9)
            {
                throw new Exception("Please supply exactly 9 lines.");
            }
            this.numbers = process(lines);
            checkSudoku();
        }

        private void checkSudoku()
        {
            for (int y = 0; y < 9; y++)
            {
                for (int x = 0; x < 9; x++)
                {
                    if (numbers[y*9+x]!=0)
                    {
                        if (!checkNumber(x, y, numbers[y * 9 + x] & NUMBER))
                        {
                            throw new Exception("The provided numbers are not a legal sudoku.");
                        }
                    }
                }
            }
        }

        private bool checkNumber(int x, int y, int number)
        {
            //for (int i=0;i<9;i++)
            //{
            //    if (!checkLine(y, i, x, number))
            //    {
            //        return false;
            //    }
            //    if (!checkColumn(x, i, y, number))
            //    {
            //        return false;
            //    }
            //}
            //if (!checkBox(x / 3, y / y, x, y, number))
            //{
                return false;
//            }
        }

        private bool checkLine(int y, int i, int x, int number)
        {
            if (i==x)
            {
                return true;
            }
            return ((this.numbers[y * 9 + i] & NUMBER) != (this.numbers[y * 9 + x] & NUMBER));
        }

        private byte[] process(string[] lines)
        {
            byte[] result = new byte[81];
            for (int i=0;i<9;i++)
            {
                string line = lines[i].Trim();
                if (line.Length!=9)
                {
                    throw new Exception("Lines must have exactly 9 numbers : "+line);
                }
                for (int j=0;j<9;j++)
                {
                    byte number = (byte)(line[i] - '0');
                    if (number<1 || number>9)
                    {
                        throw new Exception("Line contains something that is not a number : " + line[i]);
                    }
                    if (number != 0)
                    {
                        number |= GIVEN;
                    }
                    result[i * 9 + j] = number;
                }
            }
            return result;
        }


    }
}
