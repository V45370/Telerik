using System;

class Program
{
       /*
        * Write a program that finds the maximal sequence of equal elements in an array.
		* Example: {2, 1, 1, 2, 3, 3, 2, 2, 2, 1}  {2, 2, 2}.
        */
    static void Main()
    {
        Console.WriteLine("Enter array length.");
        int n = int.Parse(Console.ReadLine());
        int[] intArray = new int[n];
        int givenNumber = 0;
        int length = 1;
        int bestLength = 1;
        Console.WriteLine("Enter the array.");
        intArray[0] = int.Parse(Console.ReadLine());
        givenNumber = intArray[0];
        
        for (int i = 1; i < n; i++)
        {
            intArray[i] = int.Parse(Console.ReadLine());
            if (intArray[i-1] == intArray[i])
            {
                length++;
                if (length > bestLength)
                {
                    bestLength = length;
                    givenNumber = intArray[i];
                }
            }
            else
            {
                length = 1;
            }
        }
   
        for (int i = 0; i < bestLength; i++)
        {
            Console.Write(givenNumber+" ");
        }
    
    }
}
    

