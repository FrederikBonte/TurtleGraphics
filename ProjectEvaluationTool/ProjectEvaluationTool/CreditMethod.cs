using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEvaluationTool
{
    public class CreditMethod
    {
        private int id;
        private string name, description;
        private byte min, max;

        public CreditMethod(int id, string name, string description, byte min = 0, byte max = 100)
        {
            this.id = id;
            this.name = name;
            this.description = description;
            this.min = min;
            this.max = max;
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

        public byte getMin()
        {
            return this.min;
        }

        public byte getMax()
        {
            return this.max;
        }

        public void setRange(byte min, byte max)
        {
            this.min = min;
            this.max = max;
        }
    }
}
