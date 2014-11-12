using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    class Int16ToBinary
    {
        /*
         * Write a program that shows the binary representation of given 16-bit signed integer number (the C# type short).
        */
        static void Main()
        {
            Console.Write("Enter a 16bit integer: ");
            short i = short.Parse(Console.ReadLine());
            Console.WriteLine("Binary representation: ");
            Console.WriteLine(Convert.ToString(i,2));
        }
    }

