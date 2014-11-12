using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        string str = Console.ReadLine();
        Console.WriteLine(Regex.Replace(str, @"(\w)\1+", "$1"));
    }
}