using System;

class ConcatenateStrings
{
    static void Main()
    {
        string str1 = "Hello";
        string str2 = "World";
        string result;
        object concatenate = str1 + " " + str2;
        result = (string)concatenate;
        Console.WriteLine(result);

    }
}

