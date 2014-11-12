using System;

    class Program
    {
        /*
         * Write a program that finds the sequence of maximal sum in given array. Example:
	     * {2, 3, -6, -1, 2, -1, 6, 4, -8, 8}  {2, -1, 6, 4}
         * Can you do it with only one loop (with single scan through the elements of the array)?
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
            int max = array[0];
            int maxEnd = array[0];
            int longSequence = 1;
            int currentSequence = 1;
            int start = 0;
            int startTemp = 0;

            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] + maxEnd > array[i])
                {
                    maxEnd = array[i] + maxEnd;
                    currentSequence++;
                }

                else
                {
                    maxEnd = array[i];
                    startTemp = i;
                    currentSequence = 1;
                }

                if (maxEnd > max)
                {
                    max = maxEnd;
                    longSequence = currentSequence;
                    start = startTemp;
                }
            }

            Console.WriteLine(max);

            for (int i = start; i < start + longSequence; i++)
            {
                Console.Write(array[i] + " ");
            }
        }
    }
