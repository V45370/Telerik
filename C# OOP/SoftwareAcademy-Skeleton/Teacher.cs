using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareAcademy
{
    public class Teacher : ITeacher
    {
        private string name;
        private IList<ICourse> courses;

        public string Name
        {
           get  {return this.name;}
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name can't be null.");
                }
                this.name=value;
            }
        }
        public Teacher(string name)
        {
            this.Name = name;
            this.courses = new List<ICourse>();
        }
        
        //IList of courses he teaches
        //public IList<ICourse> Courses { get; set; }
        public void AddCourse(ICourse course)
        {
            if (course==null)
            {
                throw new ArgumentNullException("Course cant be null.");
            }
            this.courses.Add(course);
        }
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append("Teacher: Name=" + this.Name);
            if (this.courses.Count > 0)
            {
                result.Append("; Courses=[");
                result.Append(string.Join(", ", this.courses.Select(c => c.Name)));
                result.Append("]");
            }
            return result.ToString();
        }
    }
}
