using System;

    class Program
    {
        /*
         * Write a program that finds the index of given element in a sorted array 
         * of integers by using the binary search algorithm (find it in Wikipedia).
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
            int searchedNumber = int.Parse(Console.ReadLine());
            int startSearch = 0;
            int endSearch = array.Length - 1;
            int middle;
            while (startSearch <= endSearch)
            {
                middle = (startSearch + endSearch) / 2;

                if (array[middle] == searchedNumber)
                {
                    Console.WriteLine("Index is: {0}.", middle);
                    break;
                }

                if (array[middle] < searchedNumber)
                {
                    startSearch = middle + 1;
                }

                if (array[middle] > searchedNumber)
                {
                    endSearch = middle - 1;
                }
            }
        }
    }

