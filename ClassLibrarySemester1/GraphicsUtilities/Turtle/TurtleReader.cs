﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROCvanTwente.Sumpel.Semester1.TurtleDrawing
{
    public class TurtleReader
    {
        public const string KEYWORD_FORWARD = "FORWARD";
        public const string KEYWORD_BACK = "BACK";
        public const string KEYWORD_ROTATE = "ROTATE";
        public const string KEYWORD_LEFT = "LEFT";
        public const string KEYWORD_RIGHT = "RIGHT";
        public const string KEYWORD_DELAY = "SET DELAY";
        public const string KEYWORD_PEN_UP = "PEN UP";
        public const string KEYWORD_PEN_DOWN = "PEN DOWN";
        public const string KEYWORD_RESET = "RESET";
        public const string KEYWORD_REPEAT = "REPEAT";
        public const char CLASSIC_OPEN_BRACKET = '[';
        public const char CLASSIC_CLOSE_BRACKET = ']';
        public const char ALTERNATIVE_OPEN_BRACKET = '{';
        public const char ALTERNATIVE_CLOSE_BRACKET = '}';

        private Turtle turtle;
        private StreamReader reader = null;
        private char open_br;
        private char close_br;

        public TurtleReader(Turtle turtle)
        {
            this.turtle = turtle;
            this.setAlternativeBrackets();
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
            else if (line.StartsWith(KEYWORD_DELAY))
            {
                parseDelay(line.Substring(KEYWORD_DELAY.Length));
            }
            else if (line.StartsWith(KEYWORD_PEN_UP))
            {
                parsePenUp(line.Substring(KEYWORD_PEN_UP.Length));
            }
            else if (line.StartsWith(KEYWORD_PEN_DOWN))
            {
                parsePenDown(line.Substring(KEYWORD_PEN_DOWN.Length));
            }
            else if (line.StartsWith(KEYWORD_RESET))
            {
                parseReset(line.Substring(KEYWORD_RESET.Length));
            }
            else if (line.StartsWith(KEYWORD_REPEAT))
            {
                parseRepeat(line.Substring(KEYWORD_REPEAT.Length));
            }
            else if (line.StartsWith(""+close_br))
            {
                turtle.endRepeat();
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

        private void parseDelay(string line)
        {
            if (!line.StartsWith(" "))
            {
                Console.WriteLine("Please type a space between DELAY and the time!");
            }
            line = line.Trim();
            int delay = parseInt(line);
            this.turtle.setDelay(delay);
        }

        private void parseRepeat(string line)
        {
            if (!line.StartsWith(" "))
            {
                Console.WriteLine("Please type a space between REPEAT and the number!");
            }
            line = line.Trim();
            int number = parseInt(line, true);
            this.turtle.beginRepeat(number);
        }

        private void parseForward(string line)
        {
            if (!line.StartsWith(" "))
            {
                Console.WriteLine("Please type a space between FORWARD and the distance!");
            }
            line = line.Trim();
            float distance = parseFloat(line);
            this.turtle.forward(distance);
        }

        private void parseBack(string line)
        {
            if (!line.StartsWith(" "))
            {
                Console.WriteLine("Please type a space between BACK and the distance!");
            }
            line = line.Trim();
            float distance = parseFloat(line);
            this.turtle.back(distance);
        }

        private void parseRotate(string line)
        {
            if (!line.StartsWith(" "))
            {
                Console.WriteLine("Please type a space between ROTATE and the angle!");
            }
            line = line.Trim();
            float angle = parseFloat(line);
            this.turtle.rotate(angle);
        }

        private void parseLeft(string line)
        {
            if (!line.StartsWith(" "))
            {
                Console.WriteLine("Please type a space between LEFT and the angle!");
            }
            line = line.Trim();
            float angle = parseFloat(line);
            this.turtle.rotate(-angle);
        }

        private void parseRight(string line)
        {
            if (!line.StartsWith(" "))
            {
                Console.WriteLine("Please type a space between RIGHT and the angle!");
            }
            line = line.Trim();
            float angle = parseFloat(line);
            this.turtle.rotate(angle);
        }

        private void parsePenUp(string line)
        {
            if (!isCommentOrEmpty(line))
            {
                Console.WriteLine("There is some unexpected text after PEN UP: " + line);
            }
            turtle.penUp();
        }

        private void parsePenDown(string line)
        {
            if (!isCommentOrEmpty(line))
            {
                Console.WriteLine("There is some unexpected text after PEN DOWN: " + line);
            }
            turtle.penDown();
        }

        private void parseReset(string line)
        {
            if (!isCommentOrEmpty(line))
            {
                Console.WriteLine("There is some unexpected text after RESET: " + line);
            }
            turtle.reset();
        }

        private float parseFloat(string line)
        {
            int index = 0;
            if (index<line.Length && (line[index]=='-' || line[index]=='+'))
            {
                index++;
            }
            while (index<line.Length && Char.IsDigit(line[index]))
            {
                index++;
            }
            if (index < line.Length && line[index] == '.')
            {
                index++;
                while (index < line.Length && Char.IsDigit(line[index]))
                {
                    index++;
                }
            }
            if (!isCommentOrEmpty(line.Substring(index))) {
                Console.WriteLine("There is some unexpected text after this number: " + line);
            }
            return float.Parse(line.Substring(0, index));
        }

        private int parseInt(string line, bool bracket = false)
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

            if (bracket)
            {
                if (!line.StartsWith(""+open_br))
                {
                    Console.WriteLine("There should be an open bracket at the end of the REPEAT instruction: " + line);
                }
                if (!isCommentOrEmpty(line.Substring(1)))
                {
                    Console.WriteLine("There is some unexpected text after the REPEAT instruction: " + line);
                }
            }
            else if (!isCommentOrEmpty(line))
            {
                Console.WriteLine("There is some unexpected text after this number: " + line);
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