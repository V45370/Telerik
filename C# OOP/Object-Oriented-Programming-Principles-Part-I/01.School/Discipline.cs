using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.School
{
    public class Discipline : IComments
    {
        public string Name {get;set;}
        public int Lectures { get; set; }
        public int Exercises { get; set; }
        public List<string> Comments { get; set; }
        public Discipline(string name, int lectures, int exercises)
        {
            this.Name = name;
            this.Lectures = lectures;
            this.Exercises = exercises;

        }

        public void AddComment(string comment)
        {
            Comments.Add(comment);
        }
    }
}
