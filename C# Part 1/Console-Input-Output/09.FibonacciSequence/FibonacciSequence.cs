using System;

    class FibonacciSequence
    {
        static void Main()
        {
            decimal num1 = 0, num2 = 1, result;
            for (int i = 0; i < 100;i++ )
            {
                result = num1 + num2;
                Console.WriteLine("Number{0}= {1}",i,result);
                num1 = num2;
                num2 = result;
                
                
                
            }
        }
    }

 