using System;

    class Program
    {
        /*
         * We are given a matrix of strings of size N x M. 
         * Sequences in the matrix we define as sets of several neighbor elements located on the same line, column or diagonal. 
         * Write a program that finds the longest sequence of equal strings in the matrix. 
         *
         * ha fifi ho hi                    s  qq  s
         * fo  ha  hi xx --> ha,ha,ha       pp pp  s  --> s,s,s
         * xxx ho  ha xx                    pp qq  s
         */
        static void Main()
        {
            int length=0, maxLength=0;
            string bingo=" ";
            
            Console.Write("Enter rows : ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("Enter columns: ");
            int m = int.Parse(Console.ReadLine());
            string[,] matrix = new string[n, m];
            for (int i = 0; i < n; i++)           //Enter matrix
            {
                for (int j = 0; j < m; j++)
                {
                    matrix[i, j] = Console.ReadLine();
                }
                
            }

            for (int i = 0; i < n; i++)       // Show matrix
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write(matrix[i,j]+" ");
                }
                Console.WriteLine();
            }


            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    length = 1;
                    for (int k = j; k < m-1; k++) //go right
                    {
                        
                            if (matrix[i, k] == matrix[i, k+1])
                            {
                                length++;
                                if (length > maxLength)
                                {
                                    maxLength = length;
                                    bingo = matrix[i, j];
                                   
                                }

                            }
                       
                        
                    }


                    length = 1;
                    for (int k = i; k < n-1; k++) //go down
                    {
                        
                            if (matrix[k, j] == matrix[k+1, j])
                            {
                                length++;
                                if (length > maxLength)
                                {
                                    maxLength = length;
                                    bingo = matrix[i, j];
                                }

                            }
                          

                    }

                    length=1;
                    for (int k = 0; k < (n-i<=m-j ? n-i-1 : m-j-1); k++) //go diagonal. The diagonal of a matrix is equal to which row or column length is less.
                    {
                        
                            if (matrix[i + k, j + k] == matrix[i + k + 1, j + k + 1])
                            {
                                length++;
                                if (length > maxLength)
                                {
                                    maxLength = length;
                                    bingo = matrix[i, j];
                                }

                            }
                         

                    }
                }
            }
            for (int i = 0; i < maxLength; i++)
            {
                Console.Write(bingo+",");
            }
        }
    }

