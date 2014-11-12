using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.School
{
    public class ClassOfStudents : IComments
    {
        public List<Teachers> Teachers { get; set; }
        public List<Students> Students { get; set; }
        public List<string> Comments { get; set; }
        public int ID { get; set; }

        public ClassOfStudents(int id)
        {
            this.ID = id;
            this.Students=new List<Students>();
            this.Teachers = new List<Teachers>();
        }
        

        public void AddComment(string comment)
        {
            Comments.Add(comment);
        }
        
    }
}
