﻿using System;
using System.Globalization;

class Program
{
    static void Main()
    {
        string str = "21.01.2014 23:13:00";

        DateTime date = DateTime.ParseExact(str, "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture);

        date = date.AddHours(6.5);

        Console.WriteLine("{0} {1}", date.ToString("dddd", new CultureInfo("bg-BG")), date);
    }
}