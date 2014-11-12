using System;

    class Program
    {
        static void Main()
        {
            Console.Write("a: ");
            float a = float.Parse(Console.ReadLine());
            Console.Write("b: ");
            float b = float.Parse(Console.ReadLine());
            Console.Write("c: ");
            float c = float.Parse(Console.ReadLine());
            
            double d = (b * b) - 4 * (a * c);
            if (d > 0)
            {
                double x1 = (-b + Math.Sqrt(d)) / (2 * a);
                double x2 = (-b - Math.Sqrt(d)) / (2 * a);
                Console.WriteLine("The roots are {0} and {1}", x1, x2);
            }
            else if (d == 0)
            {
               
                double x12 = (-b) / (2 * b);
                Console.WriteLine("The root is {0}", x12);
            }
            else
            {
                Console.WriteLine("Discriminant is {0} < 0",d);
            }
        }
    }

