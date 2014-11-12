﻿using System;
using System.Collections.Generic;

    class Program
    {
        /* Write a program that reads three integer numbers N, K and S and an array of N elements from the console.
         * Find in the array a subset of K elements that have sum S or indicate about its absence.
         */

        static void Main()
        {

            Console.Write("Enter N: ");
            int N = int.Parse(Console.ReadLine());
            int[] array = new int[N];
            Console.WriteLine("Enter the array:");
            for (int i = 0; i < N; i++)
            {
                
                array[i] = int.Parse(Console.ReadLine());
            }
            Console.Write("Enter S: ");
            int S = int.Parse(Console.ReadLine());
            Console.Write("Enter K: ");
            int K = int.Parse(Console.ReadLine());

            int checkedNumbers = 0;
            List<int> subsetNumbers = new List<int>();
            int maxi = (int)Math.Pow(2, array.Length) - 1;
            bool hasSubsetSum = false;

            for (int i = 1; i <= maxi; i++)
            {
                long currentSum = 0;
                for (int j = 1; j <= array.Length; j++)
                {
                    if (((i >> (j - 1)) & 1) == 1)
                    {
                        currentSum += array[j - 1];
                        checkedNumbers++;
                        subsetNumbers.Add(array[j - 1]);
                    }
                }
                if (checkedNumbers == K && currentSum == S)
                {
                    hasSubsetSum = true;
                    break;
                }
                else
                {
                    checkedNumbers = 0;
                    subsetNumbers.Clear();
                }
            }

            if (hasSubsetSum)
            {
                for (int i = 0; i < subsetNumbers.Count; i++)
                {
                    Console.Write(subsetNumbers[i] + " ");
                }
            }
            else
            {
                Console.Write("No such subset.");
            }
            Console.WriteLine();
        }
    }

