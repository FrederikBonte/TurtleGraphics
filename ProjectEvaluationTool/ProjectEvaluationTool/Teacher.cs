using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEvaluationTool
{
    public class Teacher
    {
        private readonly string code, firstName, lastName, name;

        public Teacher(string code, string firstName, string lastName, string name)
        {
            this.code = code;
            this.firstName = firstName;
            this.lastName = lastName;
            this.name = name;
        }

        public string getCode()
        {
            return this.code;
        }

        public string getFirstName()
        {
            return this.firstName;
        }

        public string getLastName()
        {
            return this.lastName;
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
