using System;

    class Program
    {
        static int GCD(int a, int b)//recursive function
        {
            if (b == 0)
            {
                return a;
            }
            else
            {
                return GCD(b, a % b);
            }
        }
        static void Main()
        {
            Console.Write("a=");
            int a=int.Parse(Console.ReadLine());
            Console.Write("b=");
            int b=int.Parse(Console.ReadLine());
            Console.Write("GCD=");
            Console.WriteLine(GCD(a,b));


        }
    }

