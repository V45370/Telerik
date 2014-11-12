using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.School
{
    public abstract class People
    {
        public string Name { get; set; }
        public People(string name)
        {
            this.Name = name;
        }
    }
}
