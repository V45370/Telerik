using System;
using System.IO;
using System.Text.RegularExpressions;


class StartFinishWords
{
    /*
     * Modify the solution of the previous problem to replace only whole words (not substrings).
     */

    static void Main()
    {
        using (StreamReader input = new StreamReader("../../input.txt"))
        using (StreamWriter output = new StreamWriter("../../output.txt"))
            for (string line; (line = input.ReadLine()) != null; )
                output.WriteLine(Regex.Replace(line, @"\bstart\b", "finish"));
    }
}

