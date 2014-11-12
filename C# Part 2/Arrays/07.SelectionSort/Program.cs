using System;

    class Program
    {
        /*
         * Sorting an array means to arrange its elements in increasing order. 
         * Write a program to sort an array. Use the "selection sort" algorithm:
         * Find the smallest element, move it at the first position, find the smallest from the rest, move it at the second position, etc.
         */

        static void Main()
    {
        Console.WriteLine("Enter array length.");
        int n = int.Parse(Console.ReadLine());
        int[] array = new int[n];
        Console.WriteLine("Enter array.");
        for (int i = 0; i < n; i++)
        {
            array[i] = int.Parse(Console.ReadLine());
        }
 
        int min;
 
        for (int i = 0; i < array.Length - 1; i++)
        {
            min = i;
            for (int j = i + 1; j < array.Length; j++)
            {
                if (array[j] < array[min])
                {
                    min= j;
                }
            }
 
            if (min != i)
            {
                int temporaryVariable = array[min];
                array[min] = array[i];
                array[i] = temporaryVariable;
            }
        }
 
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write(array[i] + " ");
        }
        Console.WriteLine();
    }

    }

