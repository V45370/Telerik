using System;
  class Program
    {
      /*
       * Write a program that creates an array containing all letters from the alphabet (A-Z). 
       * Read a word from the console and print the index of each of its letters in the array.
       */
        static void Main()
        {
            char[] alphabet = new char[26];
            char[] alphabetcase = new char[26];
            string input;
            Console.WriteLine("Input a word");
            input = Console.ReadLine();
            char[] inputtochar = new char[input.Length];
            
            for (int i = 0; i < 26; i++)
            {
                alphabet[i] = (char)(i + 65);
                alphabetcase[i] = (char)(i + 97);     

            }

            inputtochar = input.ToCharArray();
            Console.WriteLine("Array indexes:");
            for (int i = 0; i < input.Length; i++)
            {
                for (int j = 0; j < 26; j++)
                {
                    if (inputtochar[i]==alphabet[j])
                    {
                        Console.Write(j+" ");
                    }
                    if (inputtochar[i] == alphabetcase[j])
                    {
                        Console.Write(j + " ");
                    }
                    
                }
                    
              
            }
            Console.WriteLine();


        }
    }

