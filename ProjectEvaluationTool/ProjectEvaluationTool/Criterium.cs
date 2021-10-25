using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEvaluationTool
{
    public class Criterium
    {
        private int id;
        private string name, description;
        private CreditMethod method;

        public Criterium(int id, string name, string description, CreditMethod method)
        {
            this.id = id;
            this.name = name;
            this.description = description;
            this.method = method;
        }
        public int getId()
        {
            return this.id;
        }

        public string getName()
        {
            return this.name;
        }

        public string getDescription()
        {
            return this.description;
        }

        public void rename(string name, string description)
        {
            this.name = name;
            this.description = description;
        }

        public void setDescription(string description)
        {
            this.description = description;
        }

        public CreditMethod getCreditMethod()
        {
            return this.method;
        }

        public void setCreditMethod(CreditMethod method)
        {
            this.method = method;
        }

        public override string ToString()
        {
            return this.getName();
        }
    }
}
