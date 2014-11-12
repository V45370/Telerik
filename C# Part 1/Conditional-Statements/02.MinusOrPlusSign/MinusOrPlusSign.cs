using System;

    class Program
    {
        static void Main()
        {
            Console.Write("First number: ");
        double firstNum = double.Parse(Console.ReadLine());
        Console.Write("Second number: ");
        double secondNum = double.Parse(Console.ReadLine());
        Console.Write("Third number: ");
        double thirdNum = double.Parse(Console.ReadLine());
        if(firstNum>=0 && secondNum >=0 && thirdNum>=0)
        {
            Console.WriteLine("The sign of the product is '+'");
        }
        else if (firstNum < 0 && secondNum < 0 && thirdNum < 0)
        {
            Console.WriteLine("The sign of the product is '-'");
        }
        else if (firstNum >= 0)
        {
            if ((secondNum >= 0 && thirdNum < 0) || (secondNum < 0 && thirdNum >= 0))
            {
                Console.WriteLine("The sign of the product is '-'");
            }
            else if (secondNum < 0 && thirdNum < 0)
            {
                Console.WriteLine("The sign of the product is '+'");
            }
        }
        else if (secondNum >= 0)
        {
            if ((firstNum >= 0 && thirdNum < 0) || (firstNum < 0 && thirdNum >= 0))
            {
                Console.WriteLine("The sign of the product is '-'");
            }
            else if (firstNum < 0 && thirdNum < 0)
            {
                Console.WriteLine("The sign of the product is '+'");
            }
        }
        else if (thirdNum >= 0)
        {
            if ((firstNum >= 0 && secondNum < 0) || (firstNum < 0 && secondNum >= 0))
            {
                Console.WriteLine("The sign of the product is '-'");
            }
            else if (firstNum < 0 && secondNum < 0)
            {
                Console.WriteLine("The sign of the product is '+'");
            }
        }
    }
        }
    

