using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareAcademy
{
    public class Course : ICourse
    {
        private string name;
        public string Name
        { 
            get { return this.name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Name cant be null.");
                    
                }
                this.name = value;
            }
        }
        //teacher assigned to teach it        
        public ITeacher Teacher { get; set; }
        //IList course program(sequence of topics)
        private IList<string> topics;

        
        public Course(string name,ITeacher teacher)
            
        {
            this.Name = name;
            this.topics = new List<string>();
            this.Teacher = teacher;
        }
           

        public void AddTopic(string topic)
        {
            if (topic==null)
            {
                throw new ArgumentNullException("Topic can't be null.");
            }
            this.topics.Add(topic);
        }
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append("Course: Name=" + this.Name);
            if (this.Teacher != null)
            {
                result.Append("; Teacher=" + this.Teacher.Name);
            }
            if (this.topics.Count > 0)
            {
                result.Append("; Topics=[");
                result.Append(string.Join(", ", this.topics));
                result.Append("]");
            }
            return result.ToString();
            
            
           
        }

        
    }
}
