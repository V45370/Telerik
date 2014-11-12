using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Students
{
    public class Program
    {
        static void Main()
        {
            /* 1.Define a class Student, which contains data about a student – 
            * first, middle and last name, SSN, permanent address, mobile phone 
            * e-mail, course, specialty, university, faculty. Use an enumeration 
            * for the specialties, universities and faculties. Override the standard 
            * methods, inherited by  System.Object: Equals(), ToString(), GetHashCode() 
            * and operators == and !=.
            * */
            Student firstStudent = new Student("Pesho", "Peshov", 123);
            Student secondStudent = new Student("Gosho", "Goshov", 456);

            bool equalStudents = firstStudent.Equals(secondStudent);
            Console.WriteLine(equalStudents);
            Console.WriteLine(firstStudent == secondStudent);
            Console.WriteLine(firstStudent != secondStudent);

            string firstStudentToString = firstStudent.ToString();

            Console.WriteLine(firstStudentToString);

            Console.WriteLine(firstStudentToString.GetHashCode());

            /*
             * 2.Add implementations of the ICloneable interface.
             * The Clone() method should deeply copy all object
             * 's fields into a new object of type Student.
             * 
             */
            var clone = firstStudent.Clone();
            Console.WriteLine(clone.ToString());

            /* 3.Implement the  IComparable<Student> interface to
            * compare students by names (as first criteria, in
            * lexicographic order) and by social security
            * number (as second criteria, in increasing order).
            * */
            var studentsCompareTo = firstStudent.CompareTo(secondStudent);
            Console.WriteLine(studentsCompareTo);
            
            /*
             * 4.Create a class Person with two fields – name and age.
             * Age can be left unspecified (may contain null value. 
             * Override ToString() to display the information of a
             * person and if age is not specified – to say so. Write 
             * a program to test this functionality.
             * */
                       
            
            var person1 = new Person("Gosho");
            var person2 = new Person("Pesho", 20);
            Console.WriteLine(person1.ToString());
            Console.WriteLine(person2.ToString());

            /*
             * 5.Define a class BitArray64 to hold 64 bit 
             * values inside an ulong value. Implement 
             * IEnumerable<int> and Equals(…), GetHashCode()
             * , [], == and !=.
             */

            BitArray64 bits = new BitArray64();

            //set all bits at even index
            for (int i = 0; i < 64; i++)
            {
                if (i % 2 == 0)
                {
                    bits[i] = 1;
                }
            }

            //clear all bits with index less than 10
            for (int i = 0; i < 10; i++)
            {
                bits[i] = 0;
            }

            IEnumerator<int> e = bits.GetEnumerator();
            e.MoveNext();
            Console.WriteLine();

            Console.WriteLine(bits);

            //foreach example
            foreach (var item in bits)
            {
                Console.WriteLine(item);
            }


            /*6.
             * Define the data structure binary search tree
             * with operations for "adding new element", 
             * "searching element" and "deleting elements".
             * It is not necessary to keep the tree balanced.
             * Implement the standard methods from System.Object 
             * – ToString(), Equals(…), GetHashCode() and the operators 
             * for comparison  == and !=. Add and implement the ICloneable 
             * interface for deep copy of the tree. Remark: Use two types – 
             * structure BinarySearchTree (for the tree) and class TreeNode 
             * (for the tree elements). Implement IEnumerable<T> to traverse the tree.
             */

            BST<int, string> firstTree = new BST<int, string>();
            firstTree.Add(4, "4");
            firstTree.Add(12, "12");
            firstTree.Add(1, "1");
            firstTree.Add(8, "8");
            firstTree.Add(5, "5");

            foreach (var node in firstTree)
            {
                Console.WriteLine(node.Key + " " + node.Value);
            }
            Console.WriteLine();

            firstTree.Remove(8);
            BST<int, string> secondTree = (BST<int, string>)firstTree.Clone();

            Console.WriteLine(firstTree);
            Console.WriteLine(secondTree);

            BST<int, string> thirdTree = new BST<int, string>();
            thirdTree.Add(5, "10");
            Console.WriteLine(thirdTree);

            Console.WriteLine(firstTree.Equals(secondTree));
            Console.WriteLine(object.ReferenceEquals(firstTree, secondTree));
            Console.WriteLine(firstTree.Equals(thirdTree));
            Console.WriteLine(object.ReferenceEquals(firstTree, thirdTree));

            thirdTree.Add(8, "16");
            thirdTree.Add(1, "2");
            thirdTree.Add(12, "24");
            thirdTree.Add(4, "8");
            Console.WriteLine(thirdTree);

            Console.WriteLine(firstTree.Equals(thirdTree));
            Console.WriteLine(object.ReferenceEquals(firstTree, thirdTree));


            BST<int, string> fourthTree = new BST<int, string>();
            fourthTree.Add(1, "1");
            fourthTree.Add(1, "one");
            Console.WriteLine(fourthTree);





        }
    }
}
