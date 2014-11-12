using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals
{
    public abstract class Animals :ISound
    {
        public double Age { get; private set; }
        public string Name { get; private set; }
        public bool IsMale { get; private set; }

        
        public Animals(string name, double age, bool IsMale)
        {
            this.Name = name; 
            this.Age = age;
            this.IsMale = IsMale;
        }


        public abstract void Sound();
       
        
    }
}
