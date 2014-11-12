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
            if (firstNum >= secondNum && firstNum >= thirdNum)
            {
                if (secondNum >= thirdNum)
                {
                    Console.WriteLine("The order is {0}, {1}, {2}", firstNum, secondNum, thirdNum);
                }
                else
                {
                    Console.WriteLine("The order is {0}, {1}, {2}", firstNum, thirdNum, secondNum);
                }
            }
            if (secondNum >= firstNum && secondNum >= thirdNum)
            {
                if (firstNum >= thirdNum)
                {
                    Console.WriteLine("The order is {0}, {1}, {2}", secondNum, firstNum, thirdNum);
                }
                else
                {
                    Console.WriteLine("The order is {0}, {1}, {2}", secondNum, thirdNum, firstNum);
                }
            }
            if (thirdNum >= secondNum && thirdNum >= firstNum)
            {
                if (firstNum >= secondNum)
                {
                    Console.WriteLine("The order is {0}, {1}, {2}", thirdNum, firstNum, secondNum);
                }
                else
                {
                    Console.WriteLine("The order is {0}, {1}, {2}", thirdNum, secondNum, firstNum);
                }
            }

        }
    }

