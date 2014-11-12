using System;

    class Program
    {
        static void Main()
        {
            Console.Write("First value: ");
            int firstValue = int.Parse(Console.ReadLine());
            Console.Write("First value: ");
            int secondValue = int.Parse(Console.ReadLine());
            if (firstValue > secondValue)
            {
                int val = firstValue;
                firstValue = secondValue;
                secondValue = val;
            }
            Console.WriteLine("First value is {0} and the second is {1}", firstValue, secondValue);
        }
    }

