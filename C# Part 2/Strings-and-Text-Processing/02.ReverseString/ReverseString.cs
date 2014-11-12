using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

   class ReverseString
    {     

        static void Main()
        {
            string input = Console.ReadLine();
            char[] reversedInput = input.ToCharArray();
            Array.Reverse(reversedInput);
            string output = new String(reversedInput);
            Console.WriteLine(output);       
            
            
        }
   }
