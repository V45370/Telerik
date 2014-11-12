using System;

    class Program
    {
        /*
         * Write a method that returns the last digit of given integer as an English word. 
         * Examples: 512 ->"two", 1024 -> "four", 12309 -> "nine".
         */
        public static string LastDigitToString(int a)
    {
        int digit = a % 10;
        string digitStr=" ";

        
            
         switch (digit)
        {
            case 0: digitStr= "zero"; break;
            case 1: digitStr = "one"; break;
            case 2: digitStr = "two"; break;
            case 3: digitStr = "three"; break;
            case 4: digitStr = "four"; break;
            case 5: digitStr = "five"; break;
            case 6: digitStr = "six"; break;
            case 7: digitStr = "seven"; break;
            case 8: digitStr = "eight"; break;
            case 9: digitStr = "nine"; break;

           
        }
         return digitStr;
        


    }
        static void Main()
        {
            Console.Write("Enter an integer: ");
            int number = int.Parse(Console.ReadLine());
            Console.WriteLine("Last digit ot the number is: "+LastDigitToString(number));
        }

    }

