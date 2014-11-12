using System;


class NullValues
{
    static void Main()
    {
        int? a = null;
        double? b = null;

        Console.WriteLine("a: {0} b: {1}", a, b);

        a += 1;
        b += 1.234567; 

        Console.WriteLine("a + null = {0} , b + 1.234567 = {1}", a, b);
    }
}
