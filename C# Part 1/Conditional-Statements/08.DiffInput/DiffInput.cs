using System;

    class Program
    {
        static void Main()
        {
            Console.Write("Input value: ");
            string input = Console.ReadLine();
            int intA = 0;
            double doubleB = 0;
            int.TryParse(input, out intA);
            double.TryParse(input, out doubleB);
         
            if (intA>0)
            {
                Console.WriteLine("Input is int: {0}", intA+1);
            }
            else if (doubleB > 0)
            {
                Console.WriteLine("Input is double: {0}", doubleB+1);
            }
            else
            {
                input += '*';
                Console.WriteLine("Input is string: {0}", input);

            }


        }
        
    }

