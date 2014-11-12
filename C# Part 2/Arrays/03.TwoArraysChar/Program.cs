using System;

class Program
{
    /*
     * Write a program that compares two char arrays lexicographically (letter by letter).
    */
    static void Main()
    {
       
        Console.WriteLine("Enter the length of the arrays.");
        int length = int.Parse(Console.ReadLine());
        char[] array1 = new char[length];
        char[] array2 = new char[length];
        Console.WriteLine("Enter the first array");

        for (int i = 0; i < length; i++)
        {
            array1[i] = char.Parse(Console.ReadLine());
            
        }
        Console.WriteLine("Enter the second array");
        for (int i = 0; i < length; i++)
        {
            array2[i] = char.Parse(Console.ReadLine());
        }
        for (int i = 0; i < length; i++)
        {
            Console.Write(array1[i]);
            
            if (array1[i]>='a' && array1[i]<='z' && array2[i]>='a' && array2[i]<='z')
            {
                if (array1[i]<array2[i])
                {
                    Console.Write("<");
                }
                if (array1[i] > array2[i])
                {
                    Console.Write(">");
                }
                if (array1[i] == array2[i])
                {
                    Console.Write("=");
                }
            }
            if (array1[i] >= 'a' && array1[i] <= 'z' && array2[i] >= 'A' && array2[i] <= 'Z')
            {
                if (array1[i]-32 < array2[i])
                {
                    Console.Write("<");
                }
                if (array1[i]-32 > array2[i])
                {
                    Console.Write(">");
                }
                if (array1[i]-32 == array2[i])
                {
                    Console.Write("=");
                }
            }
            if (array1[i] >= 'A' && array1[i] <= 'Z' && array2[i] >= 'A' && array2[i] <= 'Z')
            {
                if (array1[i] < array2[i])
                {
                    Console.Write("<");
                }
                if (array1[i] > array2[i])
                {
                    Console.Write(">");
                }
                if (array1[i] == array2[i])
                {
                    Console.Write("=");
                }
            }
            if (array1[i] >= 'A' && array1[i] <= 'Z' && array2[i] >= 'a' && array2[i] <= 'z')
            {
                if (array1[i] < array2[i]-32)
                {
                    Console.Write("<");
                }
                if (array1[i]> array2[i]-32)
                {
                    Console.Write(">");
                }
                if (array1[i] == array2[i]-32)
                {
                    Console.Write("=");
                }
            }
            Console.WriteLine(array2[i]);
            
        }
    }
}

