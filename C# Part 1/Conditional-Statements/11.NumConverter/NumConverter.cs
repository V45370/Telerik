using System;

class Program
{
    static void Main(string[] args)
    {
        int num = int.Parse(Console.ReadLine());
        int hundred = 0, ten = 0, one = 0;
        one = num % 10;
        ten = num % 100 / 10;
        hundred = num / 100;
        if (hundred > 0)
        {
            switch (hundred)
            {
                case 1: Console.Write("One "); break;
                case 2: Console.Write("Two "); break;
                case 3: Console.Write("Three "); break;
                case 4: Console.Write("Four "); break;
                case 5: Console.Write("Five "); break;
                case 6: Console.Write("Six "); break;
                case 7: Console.Write("Seven "); break;
                case 8: Console.Write("Eight "); break;
                case 9: Console.Write("Nine "); break;

            }
            Console.Write("hundred ");
        }
        if (ten > 1)
        {
            switch (ten)
            {
                case 2: Console.Write("twenty "); break;
                case 3: Console.Write("thirty "); break;
                case 4: Console.Write("forty "); break;
                case 5: Console.Write("fifty "); break;
                case 6: Console.Write("sixty "); break;
                case 7: Console.Write("seventy "); break;
                case 8: Console.Write("eighty "); break;
                case 9: Console.Write("ninety "); break;
            }
            switch (one)
            {

                case 1: Console.Write("one "); break;
                case 2: Console.Write("two "); break;
                case 3: Console.Write("three "); break;
                case 4: Console.Write("four "); break;
                case 5: Console.Write("five "); break;
                case 6: Console.Write("six "); break;
                case 7: Console.Write("seven "); break;
                case 8: Console.Write("eight "); break;
                case 9: Console.Write("nine "); break;
            }

        }
        else if (ten == 1)
        {
            if (hundred > 0) Console.Write("and ");
            switch (one)
            {
                case 0: Console.Write("ten "); break;
                case 1: Console.Write("eleven "); break;
                case 2: Console.Write("twelve "); break;
                case 3: Console.Write("thirteen "); break;
                case 4: Console.Write("forteen "); break;
                case 5: Console.Write("fifteen "); break;
                case 6: Console.Write("sixteen "); break;
                case 7: Console.Write("seventeen "); break;
                case 8: Console.Write("eighteen "); break;
                case 9: Console.Write("nineteen "); break;
            }

        }
        else if (num != 0)
        {
            if (hundred != 0 && ten < 2 && one != 0) Console.Write("and ");

            switch (one)
            {

                case 1: Console.Write("one"); break;
                case 2: Console.Write("two"); break;
                case 3: Console.Write("three"); break;
                case 4: Console.Write("four"); break;
                case 5: Console.Write("five"); break;
                case 6: Console.Write("six"); break;
                case 7: Console.Write("seven"); break;
                case 8: Console.Write("eight"); break;
                case 9: Console.Write("nine"); break;
            }
        }
        if (num == 0)
        {
            Console.Write("zero ");
        }
        Console.WriteLine();

    }
}

