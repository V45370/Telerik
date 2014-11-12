using System;
using System.IO;


class PrintOddLines
{
    static void Main()
    {
        StreamReader file = new StreamReader(@"..\..\text.txt");
        using (file)
        {               
                
            int linesCount = 0;
            string lineText = file.ReadLine();
            for (; lineText != null; )
            {
                linesCount++;
                if (linesCount%2==1)
                {
                        
                    Console.WriteLine("{0}: {1}", linesCount, lineText);
                         
                }

                lineText = file.ReadLine();
            }
        }

    }
}

