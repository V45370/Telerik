using System;
    class Program
    {
        static void Main()
        {
            int divby2 = 0, divby5 = 0, countzero = 0 ;
            Console.Write("N=");
            int n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i++)           // The longer solution
            {
                if (i % 2 == 0) divby2++;
                if (i % 5 == 0) divby5++;
                if (divby2 > 0 && divby5 > 0)
                {
                    countzero++;
                    divby2--;
                    divby5--;
                }
               
            }
            
            Console.WriteLine("zero count="+countzero);

            //THE SIMPLIEST SOLUTION IS Console.WriteLine(N/2);!!!!!!
        }
    }

