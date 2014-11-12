using System;

    class Program
    {
        /*
         * Write a method that checks if the element at given position in given array of integers is bigger than
         * its two neighbors (when such exist).
         */
        public static bool isBiggerThanNeighbours(int[] array, int position)
        {
            if (position<=0 || position>=array.Length-1)
            {
                return false;
            }
            else
            {
                if (array[position]>array[position-1] && array[position]>array[position+1])
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        static void Main()
        {
             Console.Write("Enter array length: ");
            int n = int.Parse(Console.ReadLine());
            int[] array= new int[n];
            Console.WriteLine();
            Random random = new Random();
            for (int i = 0; i < n; i++)     //Random array with 0 to 10
            {
                array[i] = random.Next(0,10);
                Console.Write(array[i]+" ");
            }
            Console.WriteLine();
            Console.WriteLine();

            Console.Write("Enter position to check: ");
            int position = int.Parse(Console.ReadLine());
            Console.WriteLine();
            if (isBiggerThanNeighbours(array,position))
            {
                Console.WriteLine("True");
            }
            else
            {
                Console.WriteLine("False");
            }
        }
    }

