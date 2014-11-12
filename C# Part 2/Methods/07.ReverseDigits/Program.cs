using System;
using System.Globalization;

class Program
{
    /*
     * Write a method that reverses the digits of given decimal number.
     * Example: 256 --> 652
     */

    public static decimal Reverse(decimal number)
    {

        char[] cArray = number.ToString().ToCharArray();
       
        string reverse = String.Empty;
        for (int i = cArray.Length - 1; i > -1; i--)
        {
            reverse += cArray[i];
        }
        return decimal.Parse(reverse);
    }
    static void Main()
    {
        Console.Write("Enter a decimal number="); 
        decimal num = decimal.Parse(Console.ReadLine());
        Console.WriteLine(Reverse(num));
       
    }
}
    

