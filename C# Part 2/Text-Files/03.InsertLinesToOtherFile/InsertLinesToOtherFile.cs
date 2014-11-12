using System;
using System.IO;

class InsertLinesToOtherFile
{
    /*
     * Write a program that reads a text file and inserts line numbers in 
     * front of each of its lines. The result should be written to another
     * text file.
     */

    static void Main()
    {

        int linesCount = 1;
        string lineRead = string.Empty;

        using (StreamReader fileRead = new StreamReader("../../InsertLinesToOtherFile.cs"))
        using (StreamWriter fileWrite = new StreamWriter("../../Result.txt"))
            for (; (lineRead = fileRead.ReadLine()) != null; linesCount++)
            {
                fileWrite.WriteLine("{0}.{1}", linesCount, lineRead);
            }
        Console.WriteLine("File completed.");

             
    }
}

