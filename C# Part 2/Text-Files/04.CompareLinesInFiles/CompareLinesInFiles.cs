using System;
using System.IO;


class CompareLinesInFiles
{
    /*
     * Write a program that compares two text files line by line and prints the number 
     * of lines that are the same and the number of lines that are different. Assume the files have equal number of lines.
    */
    static void Main()
    {
        int linesDiffer = 0;
        int linesSame = 0;
        
        string lineRead1 = string.Empty;
        string lineRead2 = string.Empty;
        
        using (StreamReader fileRead1 = new StreamReader("../../File1.txt"))
        using (StreamReader fileRead2 = new StreamReader("../../File2.txt"))
            for (; (lineRead1 = fileRead1.ReadLine()) != null; )
            {
                        
                lineRead2 = fileRead2.ReadLine();
                
                if (lineRead1==lineRead2)
                {
                    linesSame++;
                }
                else
                {
                    linesDiffer++;
                }
               
               
            }
        Console.WriteLine("Same lines count: "+linesSame);
        Console.WriteLine("Different lines count: "+linesDiffer);

    }
}
