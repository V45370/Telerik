using System;
using System.Collections.Generic;
using System.Linq;


namespace _09.to16.Students
{
    public class Tests
    {
        static Group mathGroup = new Group { DepartmentName = "Mathematics", GroupNumber = 2 };
        static Group bioGroup = new Group { DepartmentName = "Biology", GroupNumber = 3 };
        static List<Student> students = new List<Student>
            {
                new Student { FirstName = "Joro", LastName = "Goshov", FN = 123409, Email = "JoroGoshov@abv.bg", GroupNumber = 1, 
                    Marks = new List<int>{3,3,4,6,6,4,5}, Tel = "0989898989", Group = mathGroup},
                new Student { FirstName = "Ivan", LastName = "Ivanov", FN = 123408, Email = "vanko1234@gmail.com", GroupNumber = 2, 
                    Marks = new List<int>{5,3,4,5,6,2,5,6}, Tel = "027897891", Group = bioGroup },
                new Student { FirstName = "Alex", LastName = "Petrov", FN = 123407, Email = "Aleks.Petrov@mail.bg", GroupNumber = 3, 
                    Marks = new List<int>{6,6,6,6,6,6,2}, Tel = "0989789789", Group = bioGroup},
                new Student { FirstName = "Zlatan", LastName = "Ibrahimovic", FN = 123406, Email = "CykamFutbolMalkuAs@fas.bg", GroupNumber = 2, 
                    Marks = new List<int>{3,4,3,5,6,6,5,}, Tel = "02456456", Group = mathGroup},
                new Student { FirstName = "Gosho", LastName = "OtPochivka", FN = 123406, Email = "GoshoOtPochivka@abv.bg", GroupNumber = 1, 
                    Marks = new List<int>{2,2,2,2,2,2}, Tel = "096123123", Group = bioGroup},
                                    
            };

        static void Main()
        {
            //9.
            //Create a class student with properties FirstName, LastName, FN, Tel, Email, Marks (a List<int>), GroupNumber. 
            //Create a List<Student> with sample students. Select only the students that are from group number 2. Use LINQ query. Order the students by FirstName.
            Console.WriteLine("Students from group 2: ");
            students.FromGroup2();
            //10.
            //Implement the previous using the same query expressed with extension methods.
            Console.WriteLine("Students from group 2 using extension methods: ");
            students.UseExtensionMethods();
            //11.
            //Extract all students that have email in abv.bg. Use string methods and LINQ.
            Console.WriteLine("Students with abv.bg: ");
            students.OnlyAbvEmails();
            //12.
            //Extract all students with phones in Sofia. Use LINQ.
            Console.WriteLine("Students with telephone numbers in Sofia: ");
            students.OnlySofiaPhoneNumbers();
            //13.
            //Select all students that have at least one mark Excellent (6) into a new anonymous class that has properties – FullName and Marks. Use LINQ.
            Console.WriteLine("Students with atleast one Excellent mark: ");
            students.ExcellentMark();

            //14.
            //Write down a similar program that extracts the students with exactly  two marks "2". Use extension methods.
            Console.WriteLine("Students with exactly two marks '2'");
            students.BadStudents();
            //15.
            //Extract all Marks of the students that enrolled in 2006. (The students from 2006 have 06 as their 5-th and 6-th digit in the FN).
            Console.WriteLine("All the marks of the students from year 2006: ");
            students.AllStudentMarksOf06Students();

            //16.
            //Create a class Group with properties GroupNumber and DepartmentName. Introduce a property Group in the Student class. 
            //Extract all students from "Mathematics" department. Use the Join operator. */
            Console.WriteLine("All of the students from Mathematics department: ");
            students.ExtractAllStudentsFromMathDep();
        }

        
    }
}