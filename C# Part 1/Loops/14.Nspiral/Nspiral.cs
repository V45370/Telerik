using System;

class Nspiral
{
    
    static void Main()
    {
        
        Console.Write("N = ");
             int n = int.Parse(Console.ReadLine()); 
       
            int[,] matrix = new int[n, n];
            int adder = 1;
            int topX = 0;
            int topY = 0;
            int botX = n - 1;
            int botY = n - 1;
            if (n % 2 == 1) matrix[n / 2 ,n / 2 ] = n * n; // If n is an odd number the central element would escape from the loops, so we preenter it.

            for (; adder < n * n; ) // All elements are n*n
            {
                          
            
                for (int i = topX; i <= botX; i++) // left to right 
                {
                    matrix[i, topY] = adder;
                    adder++;
                }
                topY++;

                for (int i = topY; i <= botY; i++) //  top to bottom
                {
                    matrix[botX, i] = adder;
                    adder++;
                }
                botX--;

                for (int i = botX; i >= topX; i--) // right to left 
                {
                    matrix[i, botY] = adder;
                    adder++;
                }
                botY--;

                for (int i = botY; i >= topY; i--) // bottom to top 
                {
                    matrix[topX, i] = adder;
                    adder++;
                }
                topX++;
            }

            for (int i = 0; i < n; i++)     //matrix
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write("{0,3}", matrix[i, j]);
                }
                Console.WriteLine();
            }

        
       
    }
}