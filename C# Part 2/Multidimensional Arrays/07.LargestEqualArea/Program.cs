using System;

class Program
{
    /* 
     * Write a program that finds the largest area of equal neighbor elements in 
     *a rectangular matrix and prints its size.      
     */
    static int[,] matrix = {{1,3,2,2,2,3},{3,3,3,2,4,1},{4,3,1,2,3,3},{4,3,1,3,3,1},{4,3,3,3,1,1},};
    static bool[,] usedcells = new bool[matrix.GetLength(0), matrix.GetLength(1)];


    static int DFS(int i, int j, int cell)
    {

        if (i < 0 || j < 0 || i >= matrix.GetLength(0) || j >= matrix.GetLength(1)) return 0;  // if we are at the edges
        
        if (usedcells[i, j] == true) return 0; //is it a used cell
             
        if (matrix[i, j] != cell) return 0;  // search equal cells
               
        usedcells[i, j] = true;// used cell
        
        return DFS(i, j + 1, cell) + DFS(i, j - 1, cell) + DFS(i + 1, j, cell) + DFS(i - 1, j, cell) + 1; // check neighbours of the cell, + 1 for this cell which already marked
    }

    static void Main()
    {
       
        int result = -1;

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                result = Math.Max(result, DFS(i, j, matrix[i, j]));
            }
        }

        Console.WriteLine("Largest area: "+result);
    }
}