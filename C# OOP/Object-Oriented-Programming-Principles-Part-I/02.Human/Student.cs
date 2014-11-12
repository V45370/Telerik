using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Human
{
    public class Student : Human
    {
        public int Grade { get; private set; }
        public Student(string name, string lastname, int grade)
            :base(name,lastname)
        {
            this.Grade = grade;
        }
    }
}
