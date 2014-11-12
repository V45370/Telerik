using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6.Devide3and7
{
    class Tests
    {
        static void Main()
        {
            int[] integers = { 3,7,14,15,16,17,21,42,43 };
            var dividable =
            from number in integers
            where number % 3 == 0 && number % 7 == 0
            select number;
            foreach (int number in dividable)
            {
                
                Console.WriteLine(number);
            }
        }
    }
}
