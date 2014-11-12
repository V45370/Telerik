using System;
using System.IO;
using System.Collections.Generic;

class DelOddLines
{
    /*
     * Write a program that deletes from given text file all odd lines. The result should be in the same file.
     */
       

    static void Main()
    {
        List<string> lines = new List<string>();

        int lineCount = 1;
        string line1 = string.Empty;
        using (StreamReader input = new StreamReader("../../input.txt"))
            for (; (line1 = input.ReadLine()) != null; lineCount++)
                if (lineCount % 2 == 0) lines.Add(line1);
        using (StreamWriter output = new StreamWriter("../../input.txt"))
            foreach (string line2 in lines)
                output.WriteLine(line2);
       
    }
}