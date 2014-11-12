using System;
/*
 * Write a program that finds the most frequent number in an array. 
 */
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Enter the length of the array.");
            int n=int.Parse(Console.ReadLine());
            int count=0,maxcount=0,number=0;
            int[] array=new int[n];
            Console.WriteLine("Enter the array.");
            for (int i = 0; i < n; i++)
			{
			    array[i]=int.Parse(Console.ReadLine()); 
			}
            for (int i = 0; i < n; i++)
            {
                count = 0;
			 
                for (int j = i; j < n; j++)
                {
                    if (array[j]==array[i])
                    {
                        count++;                        
                    }
                }
                if (maxcount<count)
                {
                    maxcount = count;
                    number=array[i];
                }
			 
			
			}
            Console.WriteLine("The most frequent number is {0}({1} times)",number,maxcount);
        }
    }

