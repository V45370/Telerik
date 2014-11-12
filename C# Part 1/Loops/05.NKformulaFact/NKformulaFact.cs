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
        ulong result = 1;
        for (uint i = 1; i <= k; i++)
        {
            result *= i;
            if (i>k-n && i<=n)result *= i;
           
        }
        Console.WriteLine("N!*K!/(K-N)!=" + result);        
    }
}

