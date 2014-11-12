using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

    class Program
    {
        static string CheckSubsets(int[] arrNum)
        {
            int arrLength = 1;
            int indexOfValue = 1;
            // This sub array will holds all numbers of subset.
            List<int> subArray = new List<int>();
            for (int i = 0; i < arrNum.Length; i++)
            {
                // Add the first number of subset.
                subArray.Add(arrNum[i]);
                while (arrLength < arrNum.Length)
                {
                    //Check if its possible to add more numbers in the subset.
                    if (i < arrNum.Length - arrLength)
                    {
                        subArray.Add(arrNum[indexOfValue]);
                        //Check if the sum of all numbers in the subset is equal to 0;
                        if (subArray.Sum() == 0)
                        {
                            //Create the output string.
                            StringBuilder outPutString = new StringBuilder();
                            outPutString.Append("The sum of subset: ");
                            foreach (var item in subArray)
                            {
                                outPutString.AppendFormat(" {0}", item.ToString());
                            }
                            outPutString.Append(" is equal to 0!");
                            return outPutString.ToString();
                        }
                    }
                    arrLength++;
                    indexOfValue++;
                }
                // Return the needed values of this variables and remove all values in the sub array.
                arrLength = 1;
                indexOfValue = i + 2;
                subArray.Clear();
            }
            return "There is no sum of subset equal to 0";
        }

        static void Main()
        {
            Console.Write("Count of numbers: ");
            int countNum = int.Parse(Console.ReadLine());
            int[] arrNum = new int[countNum];
            for (int i = 0; i < arrNum.Length; i++)
            {
                Console.Write("Number {0}: ", (i + 1));
                arrNum[i] = int.Parse(Console.ReadLine());
            }
            Console.WriteLine(CheckSubsets(arrNum));
        }
    }
