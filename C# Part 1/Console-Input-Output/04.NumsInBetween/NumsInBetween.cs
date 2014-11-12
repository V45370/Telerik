using System;

class NumsInBetween
{
    static void Main()
    {
        int a, b, p=0;
        a = int.Parse(Console.ReadLine());
        b = int.Parse(Console.ReadLine());
        for (int i = a; i <= b; i++)
        {
            if (i%5==0)
            {
                p++;
            }
                
        }
        Console.WriteLine(p);
    }
}

