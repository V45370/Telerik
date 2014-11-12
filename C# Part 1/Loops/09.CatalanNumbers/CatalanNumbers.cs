using System;


    class Program
    {
        private static ulong Factorial(ulong n) //recursive function
        {
            if (n == 0)
                return 1;

            return n * Factorial(n - 1);
        }
 
        static void Main()
        {
            Console.Write("N=");
            ulong n = ulong.Parse(Console.ReadLine());
            ulong catalan = Factorial(2 * n) /( Factorial(n + 1) * Factorial(n));

            Console.WriteLine("Catalan number=" + catalan);
        }
    }

