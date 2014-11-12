using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Shape
{
    public class Program
    {
        static void Main()
        {
            List<Shape> shapes = new List<Shape>();
            shapes.Add(new Rectangle(10, 10));
            shapes.Add(new Triangle(10, 10));
            shapes.Add(new Circle(10, 10));

            foreach (var shape in shapes)
            {
                Console.WriteLine(shape.CalculateSurface());
            }
            

        }
    }
}
