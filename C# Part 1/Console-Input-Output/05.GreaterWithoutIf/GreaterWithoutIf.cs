using System;


class GreaterWithoutIf
{
    static void Main()
    {
        int a, b;
        Console.Write("input a number: ");
        a = int.Parse(Console.ReadLine());
        Console.Write("input a number: ");
        b = int.Parse(Console.ReadLine());
        Console.WriteLine("The greater number is: "+(a>=b ? a : b));
    }
}

