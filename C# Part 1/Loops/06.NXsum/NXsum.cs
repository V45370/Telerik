using System;

    class Program
    {
        static void Main()
        {
            Console.Write("N=");
            uint n = uint.Parse(Console.ReadLine());
            Console.Write("X=");
            uint x = uint.Parse(Console.ReadLine());
            ulong ifact=1;
            double sum=1;
            for (uint i = 1; i <= n; i++)
            {
                ifact*=i;               
                sum += ifact / Math.Pow(x, i);
               
            }
            Console.WriteLine("S="+sum);
        }
    }

