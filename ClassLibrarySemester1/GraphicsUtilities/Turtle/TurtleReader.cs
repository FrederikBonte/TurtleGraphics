using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ROCvanTwente.Sumpel.Semester1.TurtleDrawing.Turtle;

namespace ROCvanTwente.Sumpel.Semester1.TurtleDrawing
{
    public class TurtleReader
    {
        public const string KEYWORD_FORWARD = "FORWARD";
        public const string KEYWORD_BACK = "BACK";
        public const string KEYWORD_ROTATE = "ROTATE";
        public const string KEYWORD_LEFT = "LEFT";
        public const string KEYWORD_RIGHT = "RIGHT";
        public const string KEYWORD_ANGLE = "SET ANGLE";
        public const string KEYWORD_DELAY = "SET DELAY";
        public const string KEYWORD_THICKNESS = "SET THICKNESS";
        public const string KEYWORD_PEN_UP = "PEN UP";
        public const string KEYWORD_PEN_DOWN = "PEN DOWN";
        public const string KEYWORD_RESET = "RESET";
        public const string KEYWORD_MOVETO = "MOVETO";
        public const string KEYWORD_REPEAT = "REPEAT";
        public const string KEYWORD_SET = "SET";
        public const string KEYWORD_INCREASE = "INCR";
        public const string KEYWORD_DECREASE = "DECR";
        public const char CLASSIC_OPEN_BRACKET = '[';
        public const char CLASSIC_CLOSE_BRACKET = ']';
        public const char ALTERNATIVE_OPEN_BRACKET = '{';
        public const char ALTERNATIVE_CLOSE_BRACKET = '}';

        private readonly TurtleProgrammer programmer;
        private StreamReader reader = null;
        private char open_br;
        private char close_br;
        private readonly TextWriter output;

        public TurtleReader(Turtle turtle): this(new TurtleProgrammer(turtle), null)
        {
        }

        public TurtleReader(Turtle turtle, TextWriter output):this(new TurtleProgrammer(turtle), output)
        {
        }

        public TurtleReader(TurtleProgrammer turtle) : this(turtle, null)
        { 
        }

        public TurtleReader(TurtleProgrammer programmer, TextWriter output)
        {
            this.programmer = programmer;
            this.setAlternativeBrackets();
            this.output = (output == null) ? Console.Out : output;
        }

        public void setClassicBrackets()
        {
            setBrackets(CLASSIC_OPEN_BRACKET, CLASSIC_CLOSE_BRACKET);
        }

        public void setAlternativeBrackets()
        {
            setBrackets(ALTERNATIVE_OPEN_BRACKET, ALTERNATIVE_CLOSE_BRACKET);
        }

        private void setBrackets(char open, char close)
        {
            this.open_br = open;
            this.close_br = close;
        }

        public void readFromText(string text)
        {
            this.readFromStream(ToStream(text));
        }

        public void readFromFile(string filename)
        {
            this.readFromStream(new BufferedStream(new FileStream(filename, FileMode.Open)));
        }

        private void readFromStream(Stream stream)
        {
            this.reader = new StreamReader(stream);
            try
            {
                string line;
                while ((line=reader.ReadLine())!=null)
                {
                    if (line.Length==0)
                    {
                        continue;
                    }
                    if (isComment(line))
                    {
                        continue;
                    }
                    line = line.Trim().ToUpper();
                    parseLine(line);
                }
            } finally
            {
                this.reader.Close();
            }
        }

        private bool isComment(string line)
        {
            line = line.Trim();
            return
                line.StartsWith("#") || 
                line.StartsWith("--") || 
                line.StartsWith("//");
        }

        private bool isCommentOrEmpty(string line)
        {
            line = line.Trim();
            return line.Length == 0 || isComment(line);
        }

        private void parseLine(string line)
        {
            if (line.StartsWith(KEYWORD_FORWARD))
            {
                parseForward(line.Substring(KEYWORD_FORWARD.Length));
            }
            else if (line.StartsWith(KEYWORD_BACK))
            {
                parseBack(line.Substring(KEYWORD_BACK.Length));
            }
            else if (line.StartsWith(KEYWORD_LEFT))
            {
                parseLeft(line.Substring(KEYWORD_LEFT.Length));
            }
            else if (line.StartsWith(KEYWORD_RIGHT))
            {
                parseRight(line.Substring(KEYWORD_RIGHT.Length));
            }
            else if (line.StartsWith(KEYWORD_ROTATE)) 
            {
                parseRotate(line.Substring(KEYWORD_ROTATE.Length));
            }
            else if (line.StartsWith(KEYWORD_MOVETO))
            {
                parseMoveTo(line.Substring(KEYWORD_MOVETO.Length));
            }
            else if (line.StartsWith(KEYWORD_DELAY))
            {
                parseDelay(line.Substring(KEYWORD_DELAY.Length));
            }
            else if (line.StartsWith(KEYWORD_THICKNESS))
            {
                parseThickness(line.Substring(KEYWORD_THICKNESS.Length));
            }
            else if (line.StartsWith(KEYWORD_ANGLE))
            {
                parseAngle(line.Substring(KEYWORD_ANGLE.Length));
            }
            else if (line.StartsWith(KEYWORD_RESET))
            {
                parseReset(line.Substring(KEYWORD_RESET.Length));
            }
            else if (line.StartsWith(KEYWORD_SET)) // "SET" MUST GO AFTER "SET DELAY"!!!
            {
                parseSet(line.Substring(KEYWORD_SET.Length));
            }
            else if (line.StartsWith(KEYWORD_INCREASE))
            {
                parseIncrease(line.Substring(KEYWORD_INCREASE.Length));
            }
            else if (line.StartsWith(KEYWORD_DECREASE))
            {
                parseDecrease(line.Substring(KEYWORD_DECREASE.Length));
            }
            else if (line.StartsWith(KEYWORD_PEN_UP))
            {
                parsePenUp(line.Substring(KEYWORD_PEN_UP.Length));
            }
            else if (line.StartsWith(KEYWORD_PEN_DOWN))
            {
                parsePenDown(line.Substring(KEYWORD_PEN_DOWN.Length));
            }
            else if (line.StartsWith(KEYWORD_REPEAT))
            {
                parseRepeat(line.Substring(KEYWORD_REPEAT.Length));
            }
            else if (line.StartsWith(""+close_br))
            {
                programmer.endRepeat();
                if (!isCommentOrEmpty(line.Substring(1)))
                {
                    Console.WriteLine("There is some unexpected text after the closing bracket: " + line);
                }
            }
            else
            {
                Console.WriteLine("WARNING: unexpected keyword: "+line);
            }
        }

        private void parseSet(string line)
        {
            if (!line.StartsWith(" "))
            {
                Console.WriteLine("Please type a space between SET and the variable name!");
            }
            line = line.Trim();
            if (Char.IsLetter(line[0]) || line[0] == '_')
            {
                string variable = parseVariable(line, out line, false);
                line = line.Trim();
                if (line[0]=='=')
                {
                    line = line.Substring(1).Trim();
                    TurtleExpression expression = parseExpression(line, out line);
                    programmer.setVariable(variable, expression);
                }
                else
                {
                    programmer.setVariable(variable);
                }
            }
            else
            {
                Console.WriteLine("Please supply a variable to SET!");
            }
        }

        private void parseDelay(string line)
        {
            if (!line.StartsWith(" "))
            {
                Console.WriteLine("Please type a space between DELAY and the time!");
            }
            line = line.Trim();
            int delay = parseInt(line);
            this.programmer.setDelay(delay);
        }

        private void parseAngle(string line)
        {
            if (!line.StartsWith(" "))
            {
                Console.WriteLine("Please type a space between ANGLE and the value!");
            }
            line = line.Trim();
            TurtleExpression expression = parseExpression(line, out line);
            this.programmer.setAngle(expression);
        }

        private void parseThickness(string line)
        {
            if (!line.StartsWith(" "))
            {
                Console.WriteLine("Please type a space between THICKNESS and the value!");
            }
            line = line.Trim();
            float value = parseFloat(line, out line);
            this.programmer.setThickness(value);
        }

        private void parseRepeat(string line)
        {
            if (!line.StartsWith(" "))
            {
                Console.WriteLine("Please type a space between REPEAT and the number!");
            }
            line = line.Trim();
            // Parse a number of repetitions followed by a bracket.
            int number = parseInt(line, false);
            line = line.Substring(("" + number).Length);
            if (!line.StartsWith(" "))
            {
                Console.WriteLine("Please type a space between the number and the bracket!");
            }
            line = line.Trim();
            if (!line.StartsWith(""+open_br))  
            {
                Console.WriteLine("This repeat instruction has no open bracket!");
            }

            this.programmer.beginRepeat(number);
        }

        private void parseForward(string line)
        {
            if (!line.StartsWith(" "))
            {
                Console.WriteLine("Please type a space between FORWARD and the distance!");
            }
            line = line.Trim();
            TurtleExpression distance = parseExpression(line, out line);
            this.programmer.forward(distance);
        }

        private void parseIncrease(string line)
        {
            if (!line.StartsWith(" "))
            {
                Console.WriteLine("Please type a space between INCREASE and the distance!");
            }
            line = line.Trim();
            if (Char.IsLetter(line[0]) || line[0] == '_')
            {
                string variable = parseVariable(line, out line, false);
                if (line[0] == ' ')
                {
                    line = line.Substring(1).Trim();
                    TurtleExpression expression = parseExpression(line, out line);
                    programmer.increase(variable, expression);
                }
                else
                {
                    Console.WriteLine("Please supply a space between the variable and the amount to INCREASE.");
                }
            }
            else
            {
                Console.WriteLine("Please supply a variable to INCREASE!");
            }
        }

        private void parseDecrease(string line)
        {
            if (!line.StartsWith(" "))
            {
                Console.WriteLine("Please type a space between DECREASE and the distance!");
            }
            line = line.Trim();
            if (Char.IsLetter(line[0]) || line[0] == '_')
            {
                string variable = parseVariable(line, out line, false);
                line = line.Substring(variable.Length);
                if (line[0] == ' ')
                {
                    line = line.Substring(1).Trim();
                    TurtleExpression expression = parseExpression(line, out line);
                    programmer.decrease(variable, expression);
                }
                else
                {
                    Console.WriteLine("Please supply a space between the variable and the amount to DECREASE.");
                }
            }
            else
            {
                Console.WriteLine("Please supply a variable to DECREASE!");
            }
        }

        private void parseBack(string line)
        {
            if (!line.StartsWith(" "))
            {
                Console.WriteLine("Please type a space between BACK and the distance!");
            }
            line = line.Trim();
            TurtleExpression distance = parseExpression(line, out line);
            this.programmer.back(distance);
        }

        private void parseRotate(string line)
        {
            if (!line.StartsWith(" "))
            {
                Console.WriteLine("Please type a space between ROTATE and the angle!");
            }
            line = line.Trim();
            TurtleExpression angle = parseExpression(line, out line);
            this.programmer.rotate(angle);
        }

        private void parseMoveTo(string line)
        {
            if (!line.StartsWith(" "))
            {
                Console.WriteLine("Please type a space between MOVETO and the expressions!");
            }
            line = line.Trim();
            TurtleExpression exp1 = parseExpression(line, out line, false);
            line = line.Trim();
            TurtleExpression exp2 = parseExpression(line, out line, true);
            this.programmer.moveTo(exp1, exp2);
        }

        private void parseLeft(string line)
        {
            if (!line.StartsWith(" "))
            {
                Console.WriteLine("Please type a space between LEFT and the angle!");
            }
            line = line.Trim();
            TurtleExpression angle = parseExpression(line, out line);
            this.programmer.left(angle);
        }

        private void parseRight(string line)
        {
            if (!line.StartsWith(" "))
            {
                Console.WriteLine("Please type a space between RIGHT and the angle!");
            }
            line = line.Trim();
            TurtleExpression angle = parseExpression(line, out line);
            this.programmer.rotate(angle);
        }

        private void parsePenUp(string line)
        {
            if (!isCommentOrEmpty(line))
            {
                Console.WriteLine("There is some unexpected text after PEN UP: " + line);
            }
            programmer.penUp();
        }

        private void parsePenDown(string line)
        {
            if (!isCommentOrEmpty(line))
            {
                Console.WriteLine("There is some unexpected text after PEN DOWN: " + line);
            }
            programmer.penDown();
        }

        private void parseReset(string line)
        {
            if (!isCommentOrEmpty(line))
            {
                Console.WriteLine("There is some unexpected text after RESET: " + line);
            }
            programmer.reset();
        }

        private TurtleExpression parseExpression(string line_in, out string line_out, bool end = true)
        {
            if (line_in.Length==0)
            {
                line_out = line_in;
                return null;
            }
            if (Char.IsLetter(line_in[0]) || line_in[0] == '_')
            {
                return programmer.createVariable(parseVariable(line_in, out line_out, end));
            }
            else
            {
                return new TurtleConstant(parseFloat(line_in, out line_out, end));
            }
        }

        private string parseVariable(string line_in, out string line_out, bool end = true)
        {
            int index = 1;
            while (index<line_in.Length && (Char.IsLetter(line_in[index]) || Char.IsDigit(line_in[index])))
            {
                index++;
            }
            line_out = line_in.Substring(index);
            if (end && !isCommentOrEmpty(line_out))
            {
                Console.WriteLine("There is some unexpected text after this variable: " + line_in);
            }
            return line_in.Substring(0, index);
        }

        private float parseFloat(string line_in, out string line_out, bool end = true)
        {
            int index = 0;
            if (index<line_in.Length && (line_in[index]=='-' || line_in[index]=='+'))
            {
                index++;
            }
            while (index< line_in.Length && Char.IsDigit(line_in[index]))
            {
                index++;
            }
            if (index < line_in.Length && line_in[index] == '.')
            {
                index++;
                while (index < line_in.Length && Char.IsDigit(line_in[index]))
                {
                    index++;
                }
            }
            line_out = line_in.Substring(index);
            if (end && !isCommentOrEmpty(line_out)) {
                Console.WriteLine("There is some unexpected text after this number: " + line_in);
            }
            return float.Parse(line_in.Substring(0, index));
        }

        private int parseInt(string line, bool end = true)
        {
            int index = 0;
            if (index < line.Length && (line[index] == '-' || line[index] == '+'))
            {
                index++;
            }
            while (index < line.Length && Char.IsDigit(line[index]))
            {
                index++;
            }
            int result = Int32.Parse(line.Substring(0, index));

            line = line.Substring(index).Trim();

            if (end && !isCommentOrEmpty(line))
            {
                Console.WriteLine("There is some unexpected text after this integer: " + line);
            }

            return result;
        }

        public static Stream ToStream(string str)
        {
            MemoryStream stream = new MemoryStream();
            StreamWriter writer = new StreamWriter(stream);
            writer.Write(str);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }
    }
}
