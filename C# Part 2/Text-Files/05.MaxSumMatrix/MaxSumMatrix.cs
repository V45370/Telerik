using System;
using System.Collections.Generic;
using System.IO;



using System.Linq;

class MaxSumMatrix
{
    /*
     * Write a program that reads a text file containing a square matrix of numbers and finds in the
     * matrix an area of size 2 x 2 with a maximal sum of its elements. The first line in the input file 
     * contains the size of matrix N. Each of the next N lines contain N numbers separated by space. 
     * The output should be a single number in a separate text file. Example:
        4
        2 3 3 4
        0 2 3 4			17
        3 7 1 2
        4 3 3 2
     */

    static void Main()
    {               
        using (StreamReader reader = new StreamReader(@"../../Input.txt"))
        {
            int N = int.Parse(reader.ReadLine());
            int[,] matrix = new int[N, N];
            string line;
            int matrixLine = 0;

            while ((line = reader.ReadLine()) != null)
            {
                string[] nums = line.Split(' ');

                for (int i = 0; i < nums.Length; i++)
                {
                    matrix[matrixLine, i] = int.Parse(nums[i]);
                }
                matrixLine++;
            }

            int bestSum = int.MinValue;

            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    int sum = matrix[row, col] + matrix[row, col + 1] + matrix[row + 1, col] + matrix[row + 1, col + 1];
                    if (sum > bestSum)
                        bestSum = sum;
                }

            using (StreamWriter writer = new StreamWriter(@"../../Result.txt"))
            {
                writer.WriteLine(bestSum);
            }
        }
    }
}
    
   
