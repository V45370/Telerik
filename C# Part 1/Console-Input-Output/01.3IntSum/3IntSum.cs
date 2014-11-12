using System;



    class Program
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
            long sum;
            sum = (long)a + (long)b + (long)c;
            Console.WriteLine("The sum is:"+sum);
        }

    }

