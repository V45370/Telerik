using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Shape
{
    public class Circle :Shape
    {
        public Circle(double height, double width)
            : base(height, width)
        {
        }
        
    
        public override double CalculateSurface()
        {
            return (Height / 2) * (Height / 2) * Math.PI;
        }

    }
}
