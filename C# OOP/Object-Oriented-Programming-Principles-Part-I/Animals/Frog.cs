using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals
{
    public class Frog : Animals, ISound
    {
        public Frog(string name, int age, bool IsMale)
            : base(name, age, IsMale)
        {
        }
        public override void Sound()
        {
            Console.WriteLine("Kvak");
        }
    }
}
