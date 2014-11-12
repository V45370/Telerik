using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.School
{
    public class Students :People,IComments
    {
        public int ClassNumber { get; set; }
        public List<string> Comments { get; set; }

        public Students(string name, int classNumber)
            : base(name)
        {
            this.ClassNumber = classNumber;
        }
        public void AddComment(string comment)
        {
            Comments.Add(comment);
        }
    }
}
