using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEvaluationTool
{
    public class Note:IComparable<Note>
    {
        private readonly DateTime date;
        private string text;
        private bool saved = true;

        public Note(DateTime date, string text, bool saved = true)
        {
            this.date = date;
            this.text = text;
            this.saved = saved;
        }

        public void store()
        {
            this.saved = true;
        }

        public bool isSaved()
        {
            return this.saved;
        }

        public int CompareTo(Note other)
        {
            return this.date.CompareTo(other.getDate());
        }

        public DateTime getDate()
        {
            return this.date;
        }

        public string getText()
        {
            return this.text;
        }

        public void setText(string text)
        {
            this.text = text;
        }
    }
}
