using System;



    class Program
    {
        /*
        * Write a program that reads a rectangular matrix of size N x M and finds in it the square 3 x 3 that has maximal sum of its elements.
       */
        public static int SquareSum(int x, int y,int[,] matrix)  //Method that sums all 3x3 elements around matrix[x,y] and returns the sum.
        {
            int sum=matrix[x,y];
            for (int i = x -1; i <= x+1; i++)
            {
                for (int j = y-1; j <= y+1; j++)
                {
                    if(i==x && j==y)continue;
                    else
                    {
                        sum+=matrix[i,j];
                    }
                }
            }

            return sum;
        }

       
        static void Main()
        {
            Console.Write("Enter columns : ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("Enter rows: ");
            int m = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, m];
            Random random=new Random();
            int biggestSum = int.MinValue;
            Console.WriteLine("Random Matrix:");
            for (int i = 0; i < n; i++)             //Random elements in the matrix
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write("{0,4}",matrix[i, j] = random.Next(0, 100)); 
                }
                Console.WriteLine();
            }
            Console.WriteLine("Sums:");

            for (int i = 1; i < n - 1; i++)         //Finding the maximum sum.
            {
                for (int j = 1; j < m-1; j++)
                {
                    if (SquareSum(i, j, matrix)>biggestSum)
                    {
                        biggestSum = SquareSum(i, j, matrix);
                    }
                    Console.Write("{0,5}",SquareSum(i, j, matrix)); 
                }
                Console.WriteLine();
            }

            Console.WriteLine("Maximum sum is: {0}",biggestSum);

        }
    }

