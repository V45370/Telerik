using System;
using System.IO;


class ConcatFiles
{
    static void Main()
    {
        StreamReader file1Read = new StreamReader(@"..\..\File1.txt");
        StreamReader file2Read = new StreamReader(@"..\..\File2.txt");
        StreamWriter resultWrite = new StreamWriter(@"..\..\Result.txt");
            
        string lineFile1 = file1Read.ReadToEnd();
        string lineFile2 = file2Read.ReadToEnd();
        resultWrite.Write(lineFile1 + lineFile2);
        file1Read.Close();
        file2Read.Close();
        resultWrite.Close();
        StreamReader resultRead = new StreamReader(@"..\..\Result.txt");
        string lineResult = resultRead.ReadToEnd();
        Console.WriteLine(lineResult);            


    }
}

