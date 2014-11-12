using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.to16.Students
{
    public static class ExtensionMethods
    {
        public static void ExtractAllStudentsFromMathDep(this List<Student> students)
        {
            //16.
            //Create a class Group with properties GroupNumber and DepartmentName. Introduce a property Group in the Student class. 
            //Extract all students from "Mathematics" department. Use the Join operator. */

            var resultStudents = students.Where(student => student.Group.DepartmentName == "Mathematics");
            
            Console.WriteLine(string.Join("; ", resultStudents));
        }

        public static void AllStudentMarksOf06Students(this List<Student> students)
        {
            //15.
            //Extract all Marks of the students that enrolled in 2006. (The students from 2006 have 06 as their 5-th and 6-th digit in the FN).

            var resultStudents = students.Where(student => (student.FN.ToString().EndsWith("06")));
           
            foreach (var student in resultStudents)
            {
                Console.WriteLine(string.Join(", ", student.Marks));
            }
        }

        public static void BadStudents(this List<Student> students)
        {
            //14.
            //Write down a similar program that extracts the students with exactly  two marks "2". Use extension methods.

            var studentsWithTwoFs = students.Where(student => ((student.Marks.Count(mark => mark == 2)) == 2)).Select(student =>
                (new { FullName = student.FirstName + " " + student.LastName, Marks = string.Join(", ", student.Marks) }));

           
            foreach (var student in studentsWithTwoFs)
            {
                Console.WriteLine("Name: {0}, Marks: {1}", student.FullName, student.Marks);
            }
        }

        public static void ExcellentMark(this List<Student> students)
        {
            //13.
            //Select all students that have at least one mark Excellent (6) into a new anonymous class that has properties – FullName and Marks. Use LINQ.

            var stundentsWithOneExcellentGrade =
                from student in students
                where student.Marks.Contains(6)
                select new { FullName = string.Join(" ", student.FirstName, student.LastName), Marks = string.Join(", ", student.Marks) };

           
            foreach (var student in stundentsWithOneExcellentGrade)
            {
                Console.WriteLine("Name: {0}, Marks: {1}", student.FullName, student.Marks);
            }
        }

        public static void OnlySofiaPhoneNumbers(this List<Student> students)
        {
            //12.
            //Extract all students with phones in Sofia. Use LINQ.

            var sofiaNumbers =
                from student in students
                where student.Tel.StartsWith("02")
                select student;

            
            foreach (Student student in sofiaNumbers)
            {
                Console.WriteLine(student);
            }
        }

        public static void OnlyAbvEmails(this List<Student> students)
        {
            //11.
            //Extract all students that have email in abv.bg. Use string methods and LINQ.

            var abvEmails =
                from student in students
                where student.Email.Contains("@abv.bg")
                select student;
                        
            foreach (Student student in abvEmails)
            {
                Console.WriteLine(student);
            }
        }
        //10.
        //Implement the previous using the same query expressed with extension methods.

        public static void UseExtensionMethods(this List<Student> students)
        {
            
            var extensionMethodsQuery = students.Where(student => student.GroupNumber == 2).OrderBy(student => student.FirstName);
            foreach (var student in extensionMethodsQuery)
            {
                Console.WriteLine(student);
            }
        }

        //9.
        //Create a class student with properties FirstName, LastName, FN, Tel, Email, Marks (a List<int>), GroupNumber. 
        //Create a List<Student> with sample students. Select only the students that are from group number 2. Use LINQ query. Order the students by FirstName.

        public static void FromGroup2(this List<Student> students)
        {
            var studentsQuery =
                from student in students
                where student.GroupNumber == 2
                orderby student.FirstName
                select student;

            
            foreach (var student in studentsQuery)
            {
                Console.WriteLine(student);
            }
        }
    }
}
