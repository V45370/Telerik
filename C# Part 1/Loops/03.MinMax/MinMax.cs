using System;

class Program
{
    static void Main()
    {
        Console.Write("N=");
        int n = int.Parse(Console.ReadLine());
        int input, min = int.MaxValue, max = int.MinValue;
        for (int i = 1; i <= n; i++)
        {
            Console.Write("N{0}=",i);
            input = int.Parse(Console.ReadLine());
            if (input > max) max = input;
            if (input < min) min = input;
            
        }
        Console.WriteLine("Min="+min);
        Console.WriteLine("Max=" + max);
    }
}

