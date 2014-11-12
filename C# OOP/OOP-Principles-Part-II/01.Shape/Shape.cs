using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Shape
{
    public abstract class Shape
    {
        public double Width { get;private  set; }
        public double Height { get; private set; }
        public abstract double CalculateSurface();
        public Shape(double width, double height)
        {
            this.Width = width;
            this.Height = height;
 
        }
        
    }
}
