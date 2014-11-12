using System;

    class Program
    {
        static void Main()
        {
            Console.Write("n=");
            int n=int.Parse(Console.ReadLine());
            float sum=2;
            for (int i = 1; i <= n; i++)
            {
                if (i%2==0)
                {
                    sum+=(float)(1.00/i);
                    
                    
                }
                else
                {
                    sum -= (float)(1.00 / i);
                }
                
            }
            Console.WriteLine("{0:F3}",sum);
        }
    }

