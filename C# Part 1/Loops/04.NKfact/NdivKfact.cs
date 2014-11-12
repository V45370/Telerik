using System;

    class Program
    {
        static void Main()
        {
            Console.Write("N=");
            uint n = uint.Parse(Console.ReadLine());
            Console.Write("K=");
            uint k = uint.Parse(Console.ReadLine());
            Console.WriteLine();
            ulong result=1;
            for (uint i = k+1; i <= n; i++)
            {
                result *= i;
            }
            Console.WriteLine("N!/K!="+result);
        }
    }

