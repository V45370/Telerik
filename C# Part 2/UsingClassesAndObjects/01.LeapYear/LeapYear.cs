using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    class LeapYear
    {
       /*
        * Write a program that reads a year from the console and checks whether it is a leap. Use DateTime
        */
       
        static void Main()
        {
            Console.Write("Enter a year: ");
            int year = int.Parse(Console.ReadLine());
            if (DateTime.IsLeapYear(year))
            {
                Console.WriteLine(year+" is a leap year.");
            }
            else
            {
                Console.WriteLine(year+" is not a leap year.");
            }
                       
        }
    }

