using System;
using System.IO;
using System.Text.RegularExpressions;
class HtmlTitle
{
    static void Main()
    {
        StreamReader reader = new StreamReader(@"..\..\test.html");
        using (reader)
        {
            string line = string.Empty;
            MatchCollection matchProtocolAndSiteName = Regex.Matches(line, @"(?<=^|>)[^><]+?(?=<|$)");
            while ((line = reader.ReadLine()) != null)
            {
                matchProtocolAndSiteName = Regex.Matches(line, @"(?<=^|>)[^><]+?(?=<|$)");

                foreach (var word in matchProtocolAndSiteName)
                    Console.WriteLine(word);
            }
        }
    }
}