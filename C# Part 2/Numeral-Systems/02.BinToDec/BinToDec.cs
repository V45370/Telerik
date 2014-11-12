using System;
using System.Collections.Generic;
using System.Linq;

class BinToDec
{
    /*
     * Write a program to convert binary numbers to their decimal representation.
     */

    static void Main()
    {
        start:
        Console.Write("Enter bits:");
        string strBits = Console.ReadLine();
        ulong numberDec = 0;
        List<int> arrBits = strBits.ToList().ConvertAll<int>(s => Convert.ToInt32(s)-48);
        arrBits.Reverse();
        for (int i = 0; i < arrBits.Count; i++)
			{
                if (arrBits[i]!=0 && arrBits[i]!=1)
                {
                    Console.WriteLine("Not all are bits try again");
                    goto start;
                }
			}
        for (int i = 0; i < arrBits.Count; i++)
        {
            numberDec += (ulong)(arrBits[i] * Math.Pow(2,i));
        }
        Console.WriteLine("Decimal Number: "+numberDec);

    }
}