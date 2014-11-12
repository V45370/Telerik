namespace Methods_Delegates_Lambda_LINQ
{
    
    using System.Collections.Generic;
    using System.Text;
    using System;
    using System.Linq;
    static class ExtensionMethods
    {
        //1.
        //Implement an extension method Substring(int index, int length) for the class
        //StringBuilder that returns new StringBuilder and has the same functionality as Substring in the class String.
        public static StringBuilder Substring(
            this StringBuilder str,int index,int length)
        {           
            var result = new StringBuilder();
            for (int i = index; i < length; i++)
            {
                result.Append(str[i]);
            }
            return result;
        }
        //2.
        //Implement a set of extension methods for IEnumerable<T> that implement the 
        //following group functions: sum, product, min, max, average.

        public static T Min<T>(this IEnumerable<T> collection)
            where T : IComparable<T>
        {
            T min = collection.First();
            
            foreach (var item in collection) 
            {
                
                    if (min.CompareTo(item) > 0)
                    {
                        min = item;
                    }
                
            }
            return min;
        }
        public static T Max<T>(this IEnumerable<T> collection)
            where T : IComparable<T>
        {
            T max = collection.First();

            foreach (var item in collection)
            {

                if (max.CompareTo(item) < 0)
                {
                    max = item;
                }

            }
            return max;
        }
        //public static T Sum<T>(this IEnumerable<T> collection)
        //    where T : IComparable<T>
        //{

        //}
        //public static T Product<T>(this IEnumerable<T> collection)
        //    where T : IComparable<T>
        //{

        //}
        //public static T Average<T>(this IEnumerable<T> collection)
        //    where T : IComparable<T>
        //{

        //}

        //3.
        //Write a method that from a given array of students finds all 
        //students whose first name is before its last name alphabetically. Use LINQ query operators.

        public static void FindFirsnameBeforeLastname(this Students[] students)
        {

            var resultStudents = from student in students
                                 where student.FirstName.CompareTo(student.LastName) < 0
                                 select new { firstName = student.FirstName, lastName = student.LastName };
            foreach (var student in resultStudents)
            {

                Console.WriteLine("{0} {1}", student.firstName, student.lastName);
            }
        }
        //4.
        //Write a LINQ query that finds the first name and last name of all students with age between 18 and 24.
        public static void AgeBetween18and24(this Students[] students)
        {

            var resultAge = from student in students
                            where student.Age > 18 && student.Age < 24
                            select new { student.FirstName, student.LastName, student.Age };
            

            foreach (var student in resultAge)
            {
                Console.WriteLine("{0} {1} {2}", student.FirstName, student.LastName, student.Age);
            }
        }

        //5.
        //Using the extension methods OrderBy() and ThenBy() with lambda expressions 
        //sort the students by first name and last name in descending order. Rewrite the same with LINQ.
        public static void WithOrderBy(this Students[] students)
        {
            var result = students.OrderBy(element => element.FirstName).ThenBy(element => element.LastName);
            Console.WriteLine("Ordered using OrderBy and ThenBy: ");
            
            foreach (var student in result)
            {
               Console.WriteLine("{0} {1}",student.FirstName, student.LastName);
            }
            Console.WriteLine();
            
        }

        public static void OrderLINQ(this Students[] students)
        {
            var orderedstudents =
                from student in students
                orderby student.FirstName, student.LastName
                select student;
            Console.WriteLine("Ordered using LINQ:");
           
            foreach (var student in orderedstudents)
            {
                Console.WriteLine("{0} {1}", student.FirstName, student.LastName);
            }
            Console.WriteLine();
            
        }
    }
}
