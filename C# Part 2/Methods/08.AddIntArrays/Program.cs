using System;

    class Program
    {
        /*
         * Write a method that adds two positive integer numbers represented 
         * as arrays of digits (each array element arr[i] contains a digit;
         * the last digit is kept in arr[0]). Each of the numbers that will 
         * be added could have up to 10 000 digits.
         */
            public static int[] SumArr(int[] arr1, int[] arr2)
            {
                int biggerLength = arr1.Length > arr2.Length ? biggerLength = arr1.Length : biggerLength = arr2.Length;
                int[] result = new int[biggerLength];
               
                int[] reverseArr1= new int[arr1.Length];
                int[] reverseArr2 = new int[arr2.Length];
                for (int i = arr1.Length - 1; i > -1; i--)
                {
                    reverseArr1[arr1.Length-i] = arr1[i];
                }
               
                for (int i = arr2.Length - 1; i > -1; i--)
                {
                     reverseArr1[arr2.Length-i] = arr2[i];
                }
                
                for (int i = 0; i < biggerLength; i++)
                {
                    if (biggerLength == arr1.Length || biggerLength == arr1.Length) break;
                   
                    if (arr1[i]+arr2[i]<10)
                    {
                        result[i] = arr1[i] + arr2[i];
                    }
                    else
                    {
                        result[i] += (arr1[i] + arr2[i]) % 10;
                        result[i+1]++;
                    }
                }

                return result;
            }

        static void Main()
        {
            Console.Write("Enter numbers length: ");
            int n = int.Parse(Console.ReadLine());
            int[] array1 = new int[n];
            int[] array2 = new int[n];
            Console.WriteLine();
            Random random = new Random();
            for (int i = 0; i < n; i++)     //Random array1 with 0 to 9
            {
                array1[i] = random.Next(0, 9);
               
                Console.Write(array1[i]);
              
            }
            Console.WriteLine();
            Console.WriteLine("+");
            for (int i = 0; i < n; i++)     //Random array2 with 0 to 9
            {
              
                array2[i] = random.Next(0, 9);
               
                Console.Write(array2[i]);
            }
            Console.WriteLine();
            Console.WriteLine("Result");
            int[] result = SumArr(array1, array2);
            for (int i = 0; i < result.Length; i++)
            {
                Console.Write(result[i]);
            }
            Console.WriteLine();

        }
    }

