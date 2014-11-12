using System;
using System.Collections.Generic;

    class DecToBin
    {
        /*
         * Write a program to convert decimal numbers to their binary representation.
        */
        static void Main()
        {
            Console.Write("Enter a postive decimal number: "); //Since the next Exercises include negative numbers
            ulong n = ulong.Parse(Console.ReadLine());
           
            List<short> arr = new List<short>();
            
          for(;n!=0;)
            {
                if (n%2==1)
                {
                    arr.Add(1);
                }
                else
                {
                    arr.Add(0);
                }
                n /= 2;
               
            }
          arr.Reverse();
          Console.Write("Binary representation: ");
          
          foreach (int i in arr)
          {
              Console.Write(i);
          }
          Console.WriteLine();
        
          
        }
    }

