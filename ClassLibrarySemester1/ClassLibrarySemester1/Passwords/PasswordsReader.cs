using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROCvanTwente.Sumpel.Semester1.Passwords
{
    public class PasswordsReader
    {
        private readonly StreamReader reader;
        private Password password = null;

        public PasswordsReader(string filename)
        {
            this.reader = new StreamReader(new FileStream(filename, FileMode.Open));
            this.readNext();
        }

        public Password getPassword()
        {
            return this.password;
        }

        public void readNext()
        {
            this.password = null;
            string line = reader.ReadLine();
            if (line == null)
            {
                this.reader.Close();
            } else
            {
                this.password = new Password(line.Trim());
            }
        }

        public bool hasNext()
        {
            return this.password != null;
        }
    }
}
