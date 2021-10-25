using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROCvanTwente.Sumpel.Semester1.Passwords
{
	public class Password
	{
		public int min, max;
		public char letter;
		public string password;

		public Password(string line)
		{
			// First split along the ':';
			string[] parts = line.Split(':');
			// On the right element 1 is now the password. (Remove spaces!)
			password = parts[1].Trim();
			// On the end of the left element is the target character...
			letter = parts[0][parts[0].Length - 1];
			// Split the left part along the '-' after removing the last two characters.
			parts = parts[0].Substring(0, parts[0].Length - 2).Split('-');
			// new left part is the minimum.
			min = Int16.Parse(parts[0]);
			// new right part is the maximum.
			max = Int16.Parse(parts[1]);
		}
	}
}
