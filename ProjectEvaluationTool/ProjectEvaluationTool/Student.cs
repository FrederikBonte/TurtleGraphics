using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEvaluationTool
{
    public class Student
    {
        private int number;
        private string name;

        public Student(int number, string name)
        {
            this.number = number;
            this.name = name;
        }

        public int getNumber()
        {
            return this.number;
        }

        public string getName()
        {
            return this.name;
        }

        public override string ToString()
        {
            return this.name;
        }
    }
}
