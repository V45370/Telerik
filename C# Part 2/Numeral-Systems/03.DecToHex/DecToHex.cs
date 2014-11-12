using System;
using System.Collections.Generic;

    class DecToHex
    {
        /*
         * Write a program to convert decimal numbers to their hexadecimal representation.
         */
        
        static void Main()
        {
            Console.Write("Enter a positive decimal number: "); //Since the next Exercises include negative numbers
            ulong ulongDec = ulong.Parse(Console.ReadLine());
            List<char> charHex= new List<char>();

            for (; ulongDec != 0; )
            {
                //0123456789
                if (ulongDec%16<9)
                {
                    charHex.Add((char)(ulongDec % 16 + 48));
                }
                //ABCDEF
                else
                {
                    switch (ulongDec % 16)
                    {
                        case 10: charHex.Add('A'); break;
                        case 11: charHex.Add('B'); break;
                        case 12: charHex.Add('C'); break;
                        case 13: charHex.Add('D'); break;
                        case 14: charHex.Add('E'); break;
                        case 15: charHex.Add('F'); break;
                                              
                    }
                }
                ulongDec /= 16;
            }
            charHex.Reverse();
            Console.Write("Hex representation: ");
            for (int i = 0; i < charHex.Count; i++)
			{
			 Console.Write(charHex[i]);
			}
            Console.WriteLine();
            
        }
    }

