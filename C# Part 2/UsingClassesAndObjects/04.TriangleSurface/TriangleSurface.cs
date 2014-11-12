using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    class TriangleSurface
    {
        /*
         * Write methods that calculate the surface of a triangle by given:
         * Side and an altitude to it; Three sides; Two sides and an angle between them. Use System.Math
         */
        public static double SideAndAltitude(float side,float altitude)
        {
            double surface=side*altitude/2;
            return surface;
        }
        public static double ThreeSides(float side1, float side2, float side3)
        {
            double p=(side1+side2+side3)/2;
            double surface = Math.Sqrt(p*(p-side1)*(p-side2)*(p-side3));
            return surface;
        }
        public static double TwoSidesAndAngle(float side1, float side2, float angle)
        {
            float side3=(float)(Math.Sqrt(Math.Pow(side1,2)+Math.Pow(side2,2)-2*side1*side2*Math.Cos(angle)));
            return ThreeSides(side1, side2, side3);
        }

        static void Main(string[] args)
        {
            Console.Write(@"Enter a choice:
1)Enter a side and an altitude to it
2)Enter three sides
3)Enter two sides and an angle between them
Your choice:");
            for (;;)
            {
               
                char buffer = char.Parse(Console.ReadLine());
                if (buffer=='1')
                {
                    Console.Write("Side: ");
                    float side=float.Parse(Console.ReadLine());
                    Console.Write("Altitude: ");
                    float altitude=float.Parse(Console.ReadLine());
                    Console.WriteLine("Triangle surface: "+SideAndAltitude(side, altitude));
                    break;
                }
                if (buffer == '2')
                {
                    Console.Write("Side1: ");
                    float side1 = float.Parse(Console.ReadLine());
                    Console.Write("Side2: ");
                    float side2 = float.Parse(Console.ReadLine());
                    Console.Write("Side3: ");
                    float side3 = float.Parse(Console.ReadLine());                    
                    Console.WriteLine("Triangle surface: " + ThreeSides(side1,side2,side3));
                    break;
                }
                 if (buffer == '3')
                {
                    Console.Write("Side1: ");
                    float side1 = float.Parse(Console.ReadLine());
                    Console.Write("Side2: ");
                    float side2 = float.Parse(Console.ReadLine());
                    Console.Write("Angle: ");
                    float angle = float.Parse(Console.ReadLine());                    
                    Console.WriteLine("Triangle surface: " + TwoSidesAndAngle(side1,side2,angle));
                    break;
                }
            
            }
        }
    }

