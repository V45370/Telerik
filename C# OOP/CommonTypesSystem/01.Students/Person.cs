using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Students
{
    public class Person
    {
        public string Name{get;private set;}
        public int? Age { get; private set; }

        public Person(string name)
        {
            this.Name = name;
            this.Age = null;
        }
        public Person(string name, int age)
            :this(name)
        {
            
            this.Age = age;

        }

        public override string ToString()
        {
            if (this.Age==null)
            {
                return this.Name + " - Age is not specified";
            }
            else
            {
                return this.Name + " " + this.Age.ToString();
            }
        }

        
    }
}
