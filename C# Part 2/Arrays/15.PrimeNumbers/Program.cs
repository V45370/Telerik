using System;

    class Program
    {
        /*
         * Write a program that finds all prime numbers in the range [1...10 000 000].
         * Use the sieve of Eratosthenes algorithm (find it in Wikipedia).
         */
        static void Main()
        {
            int[] primearray = new int[100];  //You can change the array limit to a bigger integer to see more prime numbers but the program will be slower.
            primearray[0] = 2;
            int primecount = 1,num,i;
            bool prime = true;
            for (num = 3; num < 10000000; num++) // Counting numbers from 0 to 10 000 000
            {
                prime = true;
                for (i = 0; i<primecount; i++)  //We look if the current number is devidable by any other prime number
                {
                    if (num%primearray[i]==0)  //If the current number is devided by any prime number => its not a prime number
                    {
                        prime = false;
                        break;
                    }
                   
                }
                
                if (prime==true)               // If the current number is prime, we add it to the array with the other prime numbers
                {
                    Console.Write(num+" ");
                    primearray[i] = num;
                    primecount++;
                }
                
            }
                    
                
           
            

        }
    }

