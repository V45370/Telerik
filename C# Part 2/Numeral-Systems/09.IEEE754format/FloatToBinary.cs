using System;

class FloatToBinary
{
    /*
     * * Write a program that shows the internal binary representation of given 32-bit signed floating-point number in IEEE 754 format (the C# type float).
     * Example: -27,25  sign = 1, exponent = 10000011, mantissa = 10110100000000000000000.
     */
    static void Main()
    {
        
        decimal fraction = 0, dec = 0;
        string sign = "0", binPart = "", binFraction = "", binExp = "", mantisa = "";
        int part = 0, count = 0, exp = 0;

       
        Console.Write("Enter a float: ");
        float number = float.Parse(Console.ReadLine());
        
        if (number < 0)
        {
            sign = "1";
        }
        dec = Convert.ToDecimal(number);
        dec = Math.Abs(dec);
        part = (int)dec;
        fraction = dec - (int)dec;
        binPart = Convert.ToString(part, 2);
        while (fraction > 0 && count < 23 - binPart.Length)
        {
            fraction *= 2;
            binFraction += (int)fraction;
            fraction = fraction - (int)fraction;
            count++;
        }
        if (part > 0)
        {
            exp = binPart.Length - 1;
            exp += 127;
            binExp = Convert.ToString(exp, 2).PadLeft(8, '0');
            mantisa += binPart.Substring(1) + binFraction;
            mantisa = mantisa.PadRight(23, '0');
        }
        else if (part == 0 && fraction > 0)
        {
            count = 1;
            foreach (var item in binFraction)
            {
                if (item == '1')
                {
                    break;
                }
                count++;
            }
            exp = 127 - count;
            binExp = Convert.ToString(exp, 2).PadLeft(8, '0');
            for (int i = count; i < binFraction.Length; i++)
            {
                mantisa += binFraction[i];
            }
            mantisa = mantisa.PadRight(23, '0');
        }
        else
        {
            binExp = new String('0', 8);
            mantisa = new String('0', 23);
        }
        Console.WriteLine("Sign = {0}, Exp = {1}, Mantisa = {2}", sign, binExp, mantisa);
    }
}