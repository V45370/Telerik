using System;

/*
 * Write a program that finds in given array of integers a sequence of given sum S (if present). 
 */

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter N the length of the array.");
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter Sum.");
        int s = int.Parse(Console.ReadLine());
        int[] array = new int[n];
        int sum = 0,startposition=0;
        bool flag = false;

        Console.WriteLine("Enter the array.");

        for (int i = 0; i < n; i++)
        {
            array[i] = int.Parse(Console.ReadLine());
        }
        for (int i = 0; i < n; i++)
        {
            if (sum<s)
            {
                sum += array[i];
            }
            if (sum == s)
            {
                flag = true;
                break;

            }
            if (sum>s && s>array[i])
            {
                sum = 0;
                startposition = i;
                i-=1;
                
            }
            
                
            
        }
        if (flag==true)
        {
            Console.Write("The sequence is:");
            for (int i = startposition; sum != 0; i++)
            {
                Console.Write(array[i] + " ");
                sum -= array[i];
            } 
        }
        else
        {
            Console.WriteLine("No present sequence");
        }
        
        
    }
}

