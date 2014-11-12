using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.School
{
    public class Teachers : People
    {
        public List<Discipline> Discplines { get; set; }
        public List<string> Comments { get; set; }

        public Teachers(string name)
            : base(name)
        {
            this.Discplines = new List<Discipline>();
        }

        public void AddComment(string comment)
        {
            Comments.Add(comment);
        }
    }
}
