using System;
using System.IO;
using System.Text.RegularExpressions;


    class StartFinish
    {
        /*
         * Write a program that replaces all occurrences of the substring "start" with the substring "finish"
         * in a text file. Ensure it will work with large files (e.g. 100 MB).
         */

        static void Main()
        {
            using (StreamReader input = new StreamReader("../../input.txt"))
            using (StreamWriter output = new StreamWriter("../../output.txt"))
                for (string line; (line = input.ReadLine()) != null; )
                    output.WriteLine(line.Replace("start", "finish"));
            
                    //output.WriteLine(Regex.Replace(line, @"\bstart\b", "finish"));
        }
    }

