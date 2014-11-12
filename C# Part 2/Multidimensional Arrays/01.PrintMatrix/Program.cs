using System;

    class Program
    {
        /*
         * Write a program that fills and prints a matrix of size (n, n) as shown below: (examples for n = 4)
        */
        public static int[,] ColumnMatrix(int dimension)
        {
            int counter = 0;
            int[,] matrix = new int[dimension, dimension];
            for (int i = 0; i < dimension; i++)
            {
                for (int j = 0; j < dimension; j++)
                {
                    counter++;
                    matrix[j,i] = counter;
                }
            }
            return matrix;
        }

        public static int[,] DiagonalMatrix(int dimension)
        {

        int[,] matrix = new int[dimension, dimension];
        int counter = 1;       
        int currentX = 0;
        int currentY = dimension - 1;
        int squareSize =  dimension*dimension;
       
        int currentStartingX = currentX;
        int currentStartingY = currentY;
       
        while(counter <= squareSize)
        {
           
            while(currentY < dimension && currentX < dimension){ // go diagonal
                matrix[currentY++,currentX++] = counter++;
            }
           
            if (currentStartingY > 0) { // go up
                currentStartingY--;
                currentY = currentStartingY;
                currentX = 0;
            }
            else { // go right
                currentStartingX++;
                currentX = currentStartingX;
                currentY = 0;
            }
        }
        return matrix;
        }

        public static int[,] ZigZagMatrix(int dimension)
        {
            int counter = 0;
            int[,] matrix = new int[dimension, dimension];
            for (int i = 0; i < dimension; i++)
            {
                for (int j = 0; j < dimension; j++)
                {
                    counter++;
                    if (i%2==1)
                    {
                       matrix[dimension-1-j, i] = counter; 
                    } 
                    else
                    {
                        matrix[j, i] = counter;
                    }
                    
                }
                
            }
            
            return matrix;
        }

        public static int[,] Nspiral(int dimension)
        {
            int[,] matrix = new int[dimension,dimension];
            int adder = 1;
            int topX = 0;
            int topY = 0;
            int botX = dimension - 1;
            int botY = dimension - 1;
            if (dimension % 2 == 1) matrix[dimension / 2, dimension / 2] = dimension * dimension; // If n is an odd number the central element would escape from the loops, so we preenter it.

            for (; adder < dimension * dimension; ) // All elements are n*n
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

            
            
            return matrix;
        }
        public static void PrintMatrix(int dimension, int[,] matrix)
        {
            for (int i = 0; i < dimension; i++)
            {
                for (int j = 0; j < dimension; j++)
                {
                    Console.Write("{0,4}",matrix[i,j]);
                }
                Console.WriteLine();
            }
        }

        static void Main()
        {
            Console.Write("Enter matrix dimension: ");
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];
            Console.Write("Enter a,b,c or d: ");
            char type = char.Parse(Console.ReadLine());

            if (type=='a')
            {
                matrix = ColumnMatrix(n);
            }
            if (type == 'b')
            {
                matrix = ZigZagMatrix(n);
            }
            if (type == 'c')
            {
                matrix = DiagonalMatrix(n);
            }
            if (type == 'd')
            {
                matrix = Nspiral(n);
            }
            PrintMatrix(n, matrix);


        }
    }

