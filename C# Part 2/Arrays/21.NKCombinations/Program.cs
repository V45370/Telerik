using System;
using System.Collections.Generic;

    class Program
    {
        /*
         * Write a program that reads two numbers N and K and generates all the combinations of K distinct elements from the set [1..N]. 
         * Example:	N = 5, K = 2  {1, 2}, {1, 3}, {1, 4}, {1, 5}, {2, 3}, {2, 4}, {2, 5}, {3, 4}, {3, 5}, {4, 5}
         */

        static int N = int.Parse(Console.ReadLine());
        static int K = int.Parse(Console.ReadLine());

        //generates variations
        static void Combinations(int[] array, int index, int currentNumber)
        {
            if (index == array.Length)
            {
                PrintArray(array);
            }
            else
            {
                for (int i = currentNumber; i <= N; i++)
                {
                    array[index] = i;
                    Combinations(array, index + 1, i + 1);
                }
            }
        }

        //prints array
        static void PrintArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine();
        }

        static void Main()
        {
            
            Console.Write("Enter N: ");
            int N = int.Parse(Console.ReadLine());
            Console.Write("Enter K: ");
            int K = int.Parse(Console.ReadLine());
            int maxi = (int)Math.Pow(2, N) - 1;
            int checkedNumbers = 0;
            List<int> combinations = new List<int>();
 
            for (int i = 1; i <= maxi; i++)
            {
                for (int j = 1; j <= N; j++)
                {
                    if (((i >> (j - 1)) & 1) == 1)
                    {
                        checkedNumbers++;
                        combinations.Add(j);
                    }
                }
                if (checkedNumbers == K)
                {
                    for (int j = 0; j < combinations.Count; j++)
                    {
                        Console.Write(combinations[j] + " ");
                    }
                    Console.WriteLine();
                }
                checkedNumbers = 0;
                combinations.Clear();
            }
             

            int[] array = new int[K];
            Combinations(array, 0, 1);
        }
    }

