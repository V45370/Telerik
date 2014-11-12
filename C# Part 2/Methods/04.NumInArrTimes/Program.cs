using System;

    class Program
    {
        /*
         * Write a method that counts how many times given number appears in given array. 
         * Write a test program to check if the method is working correctly.
         */

        public static int IntCounterInArray(int[] array, int number)
        {
            int counter=0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i]==number)
	            {
                    counter++;		 
	            }
            }
            return counter;
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
            Console.Write("Enter searched number 0 to 10: ");
            int searched = int.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine("{0} is {1} times. ",searched,IntCounterInArray(array,searched));
        }
    }

