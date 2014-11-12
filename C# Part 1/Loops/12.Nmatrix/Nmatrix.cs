using System;

    class Program
    {
        static void Main()
        {
            Console.Write("N=");
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                for (int j = i+1; j <= n+i; j++)
                {
                    Console.Write("{0,3}",j);
                }
                Console.WriteLine();
            }
        }
    }

