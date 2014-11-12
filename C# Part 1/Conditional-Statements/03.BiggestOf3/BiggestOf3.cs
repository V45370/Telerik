using System;

    class Program
    {
        static void Main()
        {
            Console.Write("First number: ");
            int firstNum = int.Parse(Console.ReadLine());
            Console.Write("Second number: ");
            int secondNum = int.Parse(Console.ReadLine());
            Console.Write("Third number: ");
            int thirdNum = int.Parse(Console.ReadLine());
            if (firstNum > secondNum && firstNum > thirdNum)
            {
                Console.WriteLine("First number: {0} is the biggest", firstNum);
            }
            else if (secondNum > firstNum && secondNum > thirdNum)
            {
                Console.WriteLine("Second number: {0} is the biggest", secondNum);
            }
            else if (thirdNum > firstNum && thirdNum > secondNum)
            {
                Console.WriteLine("Third number: {0} is the biggest", thirdNum);
            }
            else
            {
                Console.WriteLine("Two or more numbers are equal");
            }
        }
    }

