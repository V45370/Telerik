using System;

class HexToBin
{
    private static string ConvertToBin(string str)
    {
        string result = String.Empty;
        result += str[0] - '0' < 10 ? ConvertToBin(str[0] - '0') : ConvertToBin(str[0] - 55);

        for (int i = 1; i < str.Length; i++)
        {
            result += str[i] - '0' < 10 ? ConvertToBin(str[i] - '0').PadLeft(4, '0') : ConvertToBin(str[i] - 55).PadLeft(4, '0');
        }
        return result;
    }
    private static string ConvertToBin(int n)
    {
        string bin = String.Empty;
        while (n != 0)
        {
            bin = Convert.ToString(n % 2) + bin;
            n /= 2;
        }
        return bin;
    }
    static void Main()
    {
        Console.Write("Enter a Binary: ");
        string str = Console.ReadLine();

        Console.Write("Hexidecimal Representation: ");
        Console.WriteLine(ConvertToBin(str));
    }
    
}
