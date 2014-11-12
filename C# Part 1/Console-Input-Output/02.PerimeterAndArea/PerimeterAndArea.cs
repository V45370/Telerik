using System;

    class PerimeterAndArea
    {
        static void Main(string[] args)
        {
            Console.Write("Input radius:");
            float r=float.Parse(Console.ReadLine());
            double perimeter, area;
           
            perimeter = Math.PI * 2.00 * r;
            
            area = Math.PI * r * r;
            
            Console.WriteLine("The area is:"+area);
            Console.WriteLine("The perimeter is:"+perimeter);
           

        }
    }

