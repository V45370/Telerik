using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    class StoDNumSys
    {
        /*
         * Write a program to convert from any numeral system of given base s to any other numeral system of base d (2 ≤ s, d ≤  16).
         */
        static void Main(string[] args)
        {
            Console.Write("Enter the input numeral system(2 to 36): ");
            byte numSys1 = byte.Parse(Console.ReadLine());
            Console.Write("Enter the output numeral system(2 to 36): ");
            byte numSys2 = byte.Parse(Console.ReadLine());
            Console.Write("Enter a "+numSys1+" system code :");
            List<int> intCode1 = Console.ReadLine().ToList().ConvertAll<int>(s => Convert.ToInt16(s));
            List<int> intCode2 = new List<int>();
                       
            for (int i = 0; i < intCode1.Count; i++)     //Transform the input array with ASCII code into decimal numbers
            {
               // Console.Write(intCode1[i]);
                if (intCode1[i]>='a' && intCode1[i]<='z')
                {
                    intCode1[i] -= 39; //It must be 87 instead of 39. When I print the ASCII code with Console.Write() for 'a' it is 97, but from the array i have 49(which is the ASCII code for '1') 
                }
                if (intCode1[i] >= 'A' && intCode1[i] <= 'Z')
                {
                    intCode1[i] -= 55;
                }
                else
                {
                    intCode1[i] -= 48;
                }
              // Console.Write(intCode1[i]);
            }    
            int numberInDec = 0;
            for (int i = intCode1.Count-1; i >= 0; i--) //transform the input numeral system into decimal
            {
                numberInDec += (int)(intCode1[i] * Math.Pow(numSys1,intCode1.Count-1-i));
            }
                        
            int countBits=0;
            int  numberInDecCopy = numberInDec;

            for (; numberInDecCopy != 0; )
            {

                numberInDecCopy /= numSys2;//We count how long the output numeral system shall be.
                countBits++;
                
            }

            for (int i = 0; i < countBits; i++)//decimal to output numeral system
            {                
                intCode2.Add((int)(numberInDec / Math.Pow(numSys2, countBits-1-i)));               
                numberInDec -= (int)(Math.Pow(numSys2,countBits-1- i)*intCode2[i]);                
            }

            Console.Write("Result into "+numSys2+" system code :");
            for (int i = 0; i < intCode2.Count; i++)
            {
                if (intCode2[i] >= 10 && intCode2[i] <= 35)
                {
                    Console.Write((char)(intCode2[i]+55));
                }
                else
                {
                    Console.Write(intCode2[i]);
                }
                
            }
            Console.WriteLine();
        }
    }

