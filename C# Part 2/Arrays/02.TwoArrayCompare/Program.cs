using System;

    class Program
    {
        /*
         * Write a program that reads two arrays from the console and compares them element by element.
        */
        static void Main()
        {
           
            Console.WriteLine("Enter the length of the arrays.");
            int length = int.Parse(Console.ReadLine());
            int[] array1 = new int[length];
            int[] array2 = new int[length];
            Console.WriteLine("Enter the first array");

            for (int i = 0; i < length; i++)
            {
                array1[i] = int.Parse(Console.ReadLine()) ;
            }
            Console.WriteLine("Enter the second array");
            for (int i = 0; i < length; i++)
            {
                array2[i] = int.Parse(Console.ReadLine()) ;
            }
            for (int i = 0; i < length; i++)
            {
                Console.Write(array1[i]);
                if (array1[i]<array2[i])
                {
                    Console.Write("<");
                }
                else if(array1[i]>array2[i])
                {
                    Console.Write(">");
                }
                else if (array1[i] == array2[i])
                {
                    Console.Write("=");
                }
                Console.WriteLine(array2[i]);
            }
        }
    }

