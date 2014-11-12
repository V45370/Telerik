using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



class HexToBin
{
    static void Main()
    {
        Console.Write("Enter a Hexidecimal: ");
        string inputHex = Console.ReadLine();
        List<char> charHex = inputHex.ToList().ConvertAll<char>(s => Convert.ToChar(s));
        List<int> intBin = new List<int>(charHex.Count*4);
        byte currentHexNum = 0;
        bool notZero = false;

        for (int i = 0; i < charHex.Count; i++) //Every current char represents a byte(4 bits). We do this loop for every symbol.
        {
            //0123456789
                if (charHex[i] >= '0' && charHex[i] <='9')
                {
                    currentHexNum= (byte)((charHex[i]-48)); 
                }
                //ABCDEF
                else 
                {
                    switch (charHex[i])
                    {
                        case 'A': currentHexNum = 10; break;
                        case 'B': currentHexNum = 11; break;
                        case 'C': currentHexNum = 12; break;
                        case 'D': currentHexNum = 13; break;
                        case 'E': currentHexNum = 14; break;
                        case 'F': currentHexNum = 15; break;
                        case 'a': currentHexNum = 10; break;
                        case 'b': currentHexNum = 11; break;
                        case 'c': currentHexNum = 12; break;
                        case 'd': currentHexNum = 13; break;
                        case 'e': currentHexNum = 14; break;
                        case 'f': currentHexNum = 15; break;

                    }
                }

                for (int j = 0; j < 4; j++)// We add each bit from the current char in a int array
                {
                    if (currentHexNum % 2 == 1) 
                    {
                        intBin.Add(1);
                    }
                    else
                    {
                        intBin.Add(0);
                    }
                    currentHexNum /= 2;
                }
           
            
            
        }

        intBin.Reverse(); // Reverse all bits.      
        
        
       for (int i = 0; i < intBin.Count; i++) //We need to reverse every sequence of 4 bits. Example: 1100 1010 0100 --> 0011 0101 0010
        {
            if (i + 4 > intBin.Count)
            {
                intBin.Reverse(i, intBin.Count%4);
                break;
            }
            if ((i+4)%4==0)
            {
                intBin.Reverse(i, 4);
            }
           
        }

       intBin.Reverse();// Reverse all bits.   
  
       Console.Write("Binary Representation: ");

       for (int i = 0; i < intBin.Count; i++) 
       {
           if (intBin[i]==1)
           {
               notZero = true; //If we have 00011011--> 11011(We dont print the starting zeros)
           }
           if (notZero==true)
           {
               Console.Write(intBin[i]);   
           }
          
       }
       Console.WriteLine();
      
       

        
        
    }
}

