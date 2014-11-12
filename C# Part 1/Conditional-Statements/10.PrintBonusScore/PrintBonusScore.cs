using System;

    class Program
    {
        static void Main()
        {
            int digit;
            Console.Write("Provide a digit: ");
            bool isDigit = int.TryParse(Console.ReadLine(), out digit);
            if (isDigit && digit < 10)
            {
                switch (digit)
                {
                    case 1:
                    case 2:
                    case 3:
                        Console.WriteLine("The new value is {0}", digit * 10);
                        break;
                    case 4:
                    case 5:
                    case 6:
                        Console.WriteLine("The new value is {0}", digit * 100);
                        break;
                    case 7:
                    case 8:
                    case 9:
                        Console.WriteLine("The new value is {0}", digit * 1000);
                        break;
                    default:
                        Console.WriteLine("This digit is zero, try another digit!");
                        break;
                }
            }
            else Console.WriteLine("This input is not correct digit. Try to input digit in range [1-9]");
        }
    }

