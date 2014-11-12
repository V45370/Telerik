using System;
using System.Collections.Generic;

    class Program
    {
        /*
         * Write a program that reads an array of integers and removes from it a minimal number of elements in such way
         * that the remaining array is sorted in increasing order. Print the remaining sorted array. 
         * Example:{6, 1, 4, 3, 0, 3, 6, 4, 5}  {1, 3, 3, 4, 5}
         */
        static void PrintResult(int[] result)
        {
            Console.Write("{");
            for (int i = result.Length - 1; i > 0; i--)
            {
                Console.Write("{0}, ", result[i]);
            }
            Console.WriteLine("{0}}}", result[0]);
        }

        static bool AllElementsAreEqual(int[] numbers)
        {
            bool areEqual = true;
            for (int index = 0, length = numbers.Length; index < length; index++)
            {
                if (numbers[0] != numbers[index])
                {
                    areEqual = false;
                    break;
                }
            }
            return areEqual;
        }

        static int[] FindBiggestIncrementSequence(int[] numbers)
        {
            List<int> lengths = new List<int>(new int[numbers.Length]); //the length of subelements
            int[] indexs = new int[numbers.Length]; //parent index
            int[] result; //The array that will contain our result
            lengths[0] = 1; //first number -> length = 1
            indexs[0] = -1; //number less than 0

            if (AllElementsAreEqual(numbers))
            {
                return new int[1];
            }

            for (int numberIndex = 1, length = numbers.Length; numberIndex < length; numberIndex++)
            {
                for (int parentIndex = numberIndex - 1; parentIndex >= 0; parentIndex--)
                {
                    if (numbers[numberIndex] >= numbers[parentIndex])
                    {
                        if (lengths[numberIndex] <= lengths[parentIndex])
                        {
                            lengths[numberIndex] = lengths[parentIndex] + 1;
                            indexs[numberIndex] = parentIndex;
                        }
                    }
                    else
                    {
                        if (lengths[numberIndex] == 0)
                        {
                            lengths[numberIndex] = 1;
                            indexs[numberIndex] = -1;
                        }
                    }
                }
            }

            do
            {
                //if the length is 1 => There were no increasing sequences found in the array.
                if (lengths.Count == 1)
                {
                    return new int[1];
                }
                int resultLength = 0;
                int maxLengthIndex = 0;

                for (int index = 0; index < lengths.Count; index++)
                {
                    if (lengths[index] > resultLength)
                    {
                        resultLength = lengths[index];
                        maxLengthIndex = index;
                    }
                }
                //Probably our result :D
                int currentIndex = maxLengthIndex;
                result = new int[resultLength];
                for (int count = 0; currentIndex != -1; count++)
                {
                    result[count] = numbers[currentIndex];
                    currentIndex = indexs[currentIndex];
                }
                //Check for increment sequence
                if (result[0] == result[resultLength - 1])
                {
                    lengths.RemoveAt(maxLengthIndex);
                    continue;
                }
                break;
            } while (true); //while our result is not increment sequence

            return result;
        }
        static void Main()
        {
            // TESTS:
            //{ 0, 6, 1, 4, 3, 0, 3, 6, 4, 5 } -> 0, 1, 3, 3, 4, 5
            //{ 1, 1, 1 } or { 1, 1, 0, 0, -1, -1 } -> there are zero increment sequences
            //{ 1, 2, 3, 1, 1, 1, 1, 1 } -> 1, 2 ,3
            //{ 0, 0, 0, 0, 0, 0, 3, 6, 4, 5 } -> 0, 0, 0, 0, 0, 0, 3, 4, 5
            Console.Write("Please enter the length of your array: ");
            int size = int.Parse(Console.ReadLine());
            int[] numbers = new int[size];
            for (int index = 0; index < size; index++)
            {
                Console.Write("Index [{0}]: ", index);
                numbers[index] = int.Parse(Console.ReadLine());
            }
            int[] result = FindBiggestIncrementSequence(numbers);
            //Let's print our result
            if (result.Length > 1)
            {
                PrintResult(result);
            }
            else
            {
                Console.WriteLine("There were no increasing sequences found in the given array.");
            }
        }
    }

