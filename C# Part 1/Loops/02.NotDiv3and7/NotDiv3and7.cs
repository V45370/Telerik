using System;

class Program
{
    static void Main()
    {
        Console.Write("N=");
        int n = int.Parse(Console.ReadLine());
        for (int i = 1; i <= n; i++)
        {
            if (i%21!=0) Console.Write(i + " ");
                       
        }
    }
}

