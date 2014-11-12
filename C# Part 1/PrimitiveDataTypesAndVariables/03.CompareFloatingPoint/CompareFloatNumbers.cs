using System;

class CompareFloatNumbers
{
    static void Main()
    {
        float a;
        float b;
        a=float.Parse(Console.ReadLine()); //Enter the numbers with a comma
        b=float.Parse(Console.ReadLine()); //Example: "5,3"
        if (a==b)
        {
            Console.WriteLine("True");
        }
        else
        {
            Console.WriteLine("False");
        }
            
                       
    }
}
