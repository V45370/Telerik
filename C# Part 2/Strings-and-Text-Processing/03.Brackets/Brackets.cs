using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    class Brackets
    {
               static void Main()
        {
            int bracketCount = 0;
            bool correct=true;
            string input = Console.ReadLine();
            StringBuilder sbInput = new StringBuilder(input);
            for (int i = 0; i < sbInput.Length; i++)
            {
                if (sbInput[i] == '(')
                {
                    bracketCount++;
                }
                else if (sbInput[i] == ')') 
                {
                    bracketCount--;
                }
                if (bracketCount<0)
                {
                    correct = false;
                }

            }
            if (bracketCount==0 && correct==true)
            {
                Console.WriteLine("Brackets are placed correctly");
            }
            else
            {
                Console.WriteLine("Brackets are not placed correctly");
            }

        }
    }

