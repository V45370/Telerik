using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals
{
    public class Tomcat : Cat, ISound
    {
        public Tomcat(string name, int age)
            : base(name, age, isMale)
        {
        }
        private const bool isMale = true;
        
    }

        
}
