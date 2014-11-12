using System;

namespace RefactoredLoop
{
    class Program
    {
        static void Main(string[] args)
        {
            bool valueIsFound = false;
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine(array[i]);
                if (i % 10 == 0)
                {
                    Console.WriteLine(array[i]);
                    if (array[i] == expectedValue)
                    {
                        valueIsFound = true;
                        break;
                    }
                }
            }
            if (valueIsFound)
            {
                Console.WriteLine("Value Found");
            }

        }
    }
}
