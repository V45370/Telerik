using System;

    class Program
    {
        static void Main()
        {
            int[] array = new int[5];
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write("Value {0}:",i);
                array[i] = int.Parse(Console.ReadLine());

            }
            Array.Sort(array);
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write("{0} ", array[i]);
                 

            }

        }
    }

