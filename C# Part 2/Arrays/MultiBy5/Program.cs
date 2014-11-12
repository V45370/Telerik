using System;

    class Program
    {
        /*
         * Write a program that allocates array of 20 integers and initializes each element        
         * by its index multiplied by 5. Print the obtained array on the console.
         */

        static void Main()
        {
            long[] array = new long[20];
            Console.WriteLine("Enter 20 integers.");
            for (int i = 0; i < array.Length; i++)
            {
                array[i]=int.Parse(Console.ReadLine())*5;
            }
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i]+" ");
            }
            Console.WriteLine();
        }
    }

