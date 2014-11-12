using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    class StringSum
    {
        /*
         * You are given a sequence of positive integer values written into a string, separated by spaces. 
         * Write a function that reads these values from given string and calculates their sum. 
         * Example:
		 * string = "43 68 9 23 318" --> result = 461
         */
        public static ulong SumInString(string str)
        {
            ulong sum = 0;
            List<int> ints = str.Split(' ').ToList().ConvertAll<int>(s => Convert.ToInt32(s));
            for (int i = 0; i < ints.Count; i++)
            {
                sum += (ulong)ints[i];
            }
            return sum;
        }
        static void Main()
        {

        Console.Write("Enter numbers separated with spaces: ");
        string str = Console.ReadLine();
        
        Console.WriteLine("The sum is: "+SumInString(str));
        }
    }

