using System;


namespace _12.ASCIItable
{
    class Program
    {
        static void Main(string[] args)
        {
           
            for (int i = 0; i <= 127; i++)
            {
                if (i % 10 == 0)              // new line every 10 characters for a better visualization
                {
                    Console.WriteLine(); 
                }

                Console.Write("{0,3}", i);    //alignment for the ASCII numbers
                Console.Write(":"+(char)i+" ");
                
            }
            
        }
    }
}
