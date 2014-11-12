using System;

    class Program
    {
        /*
         * Write a method that return the maximal element in a portion of array of integers starting at given index. 
         * Using it write another method that sorts an array in ascending / descending order.
         */
        public static int[] MaxElement(int position, int[] array)
        {
            if (position == array.Length - 1)
            {
                return array;
            }

            if (position == 0 && array[position] > array[position + 1]) // Change ">" for ascending and "<" descending order.
            {
                int swap = 0;
                swap = array[position];
                array[position] = array[position + 1];
                array[position + 1] = swap;
            }

            else if (array[position] > array[position + 1]) // Change ">" for ascending and "<" descending order.
            {
                int swap = 0;
                swap = array[position];
                array[position] = array[position + 1];
                array[position + 1] = swap;
                return MaxElement(position-1, array);
            }
            

                return MaxElement(position+1, array);
            
                  
            
            

           
            
            
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
            Console.Write("Enter start position: ");
            int position=int.Parse(Console.ReadLine());

            array = MaxElement(position, array);
            
            for (int i = 0; i < n; i++)     
            {                
                Console.Write(array[i] + " "); 
            }
            // Console.Write(array[n - 1]); 
            // Console.Write(array[0]); 
        }
    }

