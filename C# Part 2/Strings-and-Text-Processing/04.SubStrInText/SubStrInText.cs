using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        Console.Write("Text :");
        string str = Console.ReadLine();
        Console.Write("Substring: ");
        string substr = Console.ReadLine();

        Console.WriteLine(Regex.Matches(str, substr, RegexOptions.IgnoreCase).Count);
    }
}