using System;
using System.Globalization;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        string str = Console.ReadLine();

        DateTime date;
        foreach (Match item in Regex.Matches(str, @"\b\d{2}.\d{2}.\d{4}\b"))
            if (DateTime.TryParseExact(item.Value, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
                Console.WriteLine(date.ToString(CultureInfo.GetCultureInfo("en-CA").DateTimeFormat.ShortDatePattern));
    }
}