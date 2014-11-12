using System;

    class Program
    {
        /*
         * Write a method that asks the user for his name and prints “Hello, <name>” (for example, “Hello, Peter!”).
         * Write a program to test this method.
         */
        public static string HelloName()
        {            
            Console.Write("Please enter your name:");
            string name = Console.ReadLine();
            return"Hello, "+name;
            
        }
        static void Main()
        {
            Console.WriteLine(HelloName());
        }
    }

