using System;

    class nNumsSum
    {
        static void Main()
        {
            Console.Write("How many numbers?: ");
            int n = int.Parse(Console.ReadLine());
            float sum=0;
            for (int i = 0; i < n; i++)
            {
                Console.Write("n{0}=",i);
                sum += float.Parse(Console.ReadLine());
            }
            Console.WriteLine("The sum is: "+sum);
        }
    }

