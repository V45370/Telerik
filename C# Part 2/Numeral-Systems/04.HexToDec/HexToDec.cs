using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    class HexToDec
    {
        /*
         * Write a program to convert hexadecimal numbers to their decimal representation.
         */

        static void Main()
        {
            Console.Write("Enter a hex: ");
            string inputHex=Console.ReadLine();
            List<char> charHex = inputHex.ToList().ConvertAll<char>(s => Convert.ToChar(s));
            ulong resultDec = 0;
            charHex.Reverse();
            for (int i = 0; i < charHex.Count; i++ )
            {
                //0123456789
                if (charHex[i] >= '0' && charHex[i] <='9')
                {
                    resultDec += (ulong)((charHex[i]-48) * Math.Pow(16, i));
                }
                //ABCDEF
                else 
                {
                    switch (charHex[i])
                    {
                        case 'A': resultDec += (ulong)(10 * Math.Pow(16, i)); break;
                        case 'B': resultDec += (ulong)(11 * Math.Pow(16, i)); break;
                        case 'C': resultDec += (ulong)(12 * Math.Pow(16, i)); break;
                        case 'D': resultDec += (ulong)(13 * Math.Pow(16, i)); break;
                        case 'E': resultDec += (ulong)(14 * Math.Pow(16, i)); break;
                        case 'F': resultDec += (ulong)(15 * Math.Pow(16, i)); break;
                        case 'a': resultDec += (ulong)(10 * Math.Pow(16, i)); break;
                        case 'b': resultDec += (ulong)(11 * Math.Pow(16, i)); break;
                        case 'c': resultDec += (ulong)(12 * Math.Pow(16, i)); break;
                        case 'd': resultDec += (ulong)(13 * Math.Pow(16, i)); break;
                        case 'e': resultDec += (ulong)(14 * Math.Pow(16, i)); break;
                        case 'f': resultDec += (ulong)(15 * Math.Pow(16, i)); break;
                        

                    }
                }
              
            }
            
            Console.WriteLine("Dec representation: "+resultDec);
            
           

        }
    }

