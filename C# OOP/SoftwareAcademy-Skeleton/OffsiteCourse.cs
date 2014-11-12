using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareAcademy
{
    public class OffsiteCourse : Course, IOffsiteCourse
    {
        private string town;
        public string Town 
        {
            get { return this.town; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Town cant be null.");
                }
                this.town = value;
            }
        }
        public OffsiteCourse(string name,ITeacher teacher, string town)
            : base(name,teacher)
        {
            this.Town = town;
        }
        

        public override string ToString()
        {
            string result = "Offsite" + base.ToString() + "; Town=" + this.Town;
            return result;
        }
    }
}
