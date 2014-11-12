using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Methods_Delegates_Lambda_LINQ
{
    using Methods_Delegates_Lambda_LINQ;
    public class Tests
    {
        static void Main(string[] args)
        {
            //1.
            //Implement an extension method Substring(int index, int length) for the class 
            //StringBuilder that returns new StringBuilder and has the same functionality as Substring in the class String.

            string input = "12345";
            StringBuilder sbInput = new StringBuilder(input);
            StringBuilder sbSubString = new StringBuilder();
            sbSubString = sbInput.Substring(0, 3);
            Console.WriteLine("1)");
            Console.WriteLine("Substring: "+sbSubString.ToString());

            //2.
            //Implement a set of extension methods for IEnumerable<T> that implement the 
            //following group functions: sum, product, min, max, average.

            List<int> intList = new List<int>();
            for (int i = 1; i <= 10; i++)
            {
                intList.Add(i);
            }
            Console.WriteLine("2)");

            Console.WriteLine("Min: "+intList.Min<int>());
            Console.WriteLine("Max: "+intList.Max<int>());

            //3.
            //Write a method that from a given array of students finds all students 
            //whose first name is before its last name alphabetically. Use LINQ query operators.

            Students[] students = {
                                    new Students { FirstName = "Joro", LastName = "Goshov",Age=15},
                                    new Students { FirstName = "Ivan", LastName = "Jorov",Age=18},
                                    new Students { FirstName = "Alex", LastName = "Peshov",Age=23},
                                    new Students { FirstName = "Gosho", LastName = "OtPochivka",Age=50},
                                    new Students { FirstName = "Zlatan", LastName = "Ibrahimovic",Age=40}
                                 };
            
            Console.WriteLine("3)Firstname<Lastname:");
            students.FindFirsnameBeforeLastname();
           
            

            //4.
            //Write a LINQ query that finds the first name and last name of all students with age between 18 and 24.
            
            Console.WriteLine("4)Age between 18 and 24:");
            students.AgeBetween18and24();

            //5.
            //Using the extension methods OrderBy() and ThenBy() with lambda expressions 
            //sort the students by first name and last name in descending order. Rewrite the same with LINQ.
            Console.WriteLine("5) Order By:");

            students.WithOrderBy();
            students.OrderLINQ();

        }
    }
}
