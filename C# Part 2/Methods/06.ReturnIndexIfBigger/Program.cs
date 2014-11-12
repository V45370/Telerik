using System;

class Program
{
    /*
     * Write a method that returns the index of the first element in array that 
     * is bigger than its neighbors, or -1, if there’s no such element.
     */
    public static int isBiggerThanNeighbours(int[] array, int position)
    {
        if (position <= 0 || position >= array.Length - 1)
        {
            return -1;
        }
        else
        {
            if (array[position] > array[position - 1] && array[position] > array[position + 1])
            {
                return position;
            }
            else
            {
                return isBiggerThanNeighbours(array,position+1);
            }
        }
    }
    static void Main()
    {
        Console.Write("Enter array length: ");
        int n = int.Parse(Console.ReadLine());
        int[] array = new int[n];
        Console.WriteLine();
        Random random = new Random();
        for (int i = 0; i < n; i++)     //Random array with 0 to 10
        {
            array[i] = random.Next(0, 10);
            Console.Write(array[i] + " ");
        }
        Console.WriteLine();
        Console.WriteLine();

        
        Console.WriteLine();
        if (isBiggerThanNeighbours(array, 1)==-1)
        {
            Console.WriteLine("-1");
        }
        else
        {
            Console.WriteLine(isBiggerThanNeighbours(array, 1));
        }
    }
}

