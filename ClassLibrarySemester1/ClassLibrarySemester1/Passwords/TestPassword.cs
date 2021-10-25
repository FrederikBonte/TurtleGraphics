using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROCvanTwente.Sumpel.Semester1.Passwords
{
    class TestPassword
    {
        public static void Main(String[] args)
        {
            PasswordsReader reader = new PasswordsReader("c:/temp/input_2020_day2.txt");
            int count = 0;

            for (; reader.hasNext() ; reader.readNext())
            {
                Password passwd = reader.getPassword();

                Console.WriteLine(passwd.password);
                if (checkPassword(passwd))
                {
                    count = count + 1;
                }
            }

            // Show the number of correct password...
            Console.WriteLine(count);
            Console.ReadLine();
        }

        public static bool checkPassword(Password password)
        {
            // Count the number of letters in the password.
            int number = countLetters(password.letter, password.password);

            // CHECK IF THE PASSWORD IS LEGAL???
            // (Number >= password.min) && number<= password.max)
            // Return the correct result.
            return false;
        }

        public static int countLetters(char letter, string password)
        {
            return -1;
        }
    }
}
