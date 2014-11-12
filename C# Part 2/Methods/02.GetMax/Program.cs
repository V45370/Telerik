using System;

    class Program
    {
        /*
         * Write a method GetMax() with two parameters that returns the bigger of two integers.
         * Write a program that reads 3 integers from the console and prints the biggest of them using the method GetMax().
         */
        public static int GetMax(int first, int second)
        {
            return first < second ? second : first;
        }
        static void Main()
        {
            Console.Write("Input a: ");
            int a = int.Parse(Console.ReadLine());
            Console.Write("Input b: ");
            int b = int.Parse(Console.ReadLine());
            Console.Write("Input c: ");
            int c = int.Parse(Console.ReadLine());

            Console.WriteLine("The biggest value is: "+GetMax(a,GetMax(b,c)));
            
        }
    }

