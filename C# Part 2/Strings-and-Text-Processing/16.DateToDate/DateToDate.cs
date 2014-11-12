using System;
using System.Globalization;

class Program
{
    static void Main()
    {
        string start = "01.01.1990";
        string end = "31.12.1999";

        DateTime startDate = DateTime.ParseExact(start, "d.MM.yyyy", CultureInfo.InvariantCulture);
        DateTime endDate = DateTime.ParseExact(end, "d.MM.yyyy", CultureInfo.InvariantCulture);

        Console.WriteLine((endDate - startDate).TotalDays);
    }
}