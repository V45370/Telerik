using System;

/*
 * Write a program that reads two integer numbers N and K and an array of N elements from the console. 
 * Find in the array those K elements that have maximal sum.
 */

    class Program
    {
        static void Main()
        {
            Console.WriteLine("Enter N the length of the array.");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter K.");
            int k = int.Parse(Console.ReadLine());
            int[] array = new int[n];
            int maxsum=int.MinValue, sum=0;
            
            Console.WriteLine("Enter the array.");

            for (int i = 0; i < n; i++)
            {
                array[i] = int.Parse(Console.ReadLine());
            }
            for (int i = 0;  i <n-k;  i++)
            {
                sum = 0;
                for (int j = i; j < i+k; j++)
                {
                    sum += array[j];
                }
                if (sum>maxsum)
                {
                    maxsum = sum;
                }
                
            }
            Console.WriteLine("The maximum sum of K elements is:"+maxsum);
        }
    }

