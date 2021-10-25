using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEvaluationTool
{
    public class Klas
    {
        private readonly List<Student> students = new List<Student>();
        private readonly string code;

        public Klas(string code, params Student[] students)
        {
            this.code = code;
            foreach (Student student in students)
            {
                this.students.Add(student);
            }
        }

        public string getCode()
        {
            return this.code;
        }

        public int getCount()
        {
            return this.students.Count;
        }

        public Student getStudent(int index)
        {
            return this.students[index];
        }
    }
}
