using System;

    class Program
    {
        /*
         * You are given an array of strings. Write a method that sorts the array by the length of
         * its elements (the number of characters composing them).
         */

        static void Main()
        {
            Console.Write("Enter array length : ");
            int n = int.Parse(Console.ReadLine());
            string[] array = new string[n];
           
            
            Console.Write("Enter strings: ");
            for (int i = 0; i < n; i++)
            {
                array[i] = Console.ReadLine();
            }
            for(int j=0; j<n;j++)
            {
                 for (int i=j+1 ; i<n; i++)
                 {
                     if(array[i].Length-array[j].Length<0)
                     {
                         String temp= array[j];
                         array[j]= array[i]; 
                         array[i]=temp;


                     }
                 }

   
            }

            for (int i = 0; i < n; i++)
            {
                Console.Write(array[i]+" ");
            }
            Console.WriteLine();
            
        }
    }

