using System;

class QuadricEquation
{
    static void Main()
    {
        int a, b, c;
        Console.Write("a=");
        a = int.Parse(Console.ReadLine());
        Console.Write("b=");
        b = int.Parse(Console.ReadLine());
        Console.Write("c=");
        c = int.Parse(Console.ReadLine());
        Console.WriteLine("x1="+(float)((-b + Math.Sqrt(b * b - 4 * a * c)) / 2 * a));
        Console.WriteLine("x2=" +(float)((-b - Math.Sqrt(b * b - 4 * a * c)) / 2 * a));
    }
}

