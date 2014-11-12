using System;
using System.Linq;

namespace _01.Students
{
    public class Student: ICloneable, IComparable<Student>
    {
        /* 1.Define a class Student, which contains data about a student – 
        * first, middle and last name, SSN, permanent address, mobile phone 
        * e-mail, course, specialty, university, faculty. Use an enumeration 
        * for the specialties, universities and faculties. Override the standard 
         * methods, inherited by  System.Object: Equals(), ToString(), GetHashCode() 
         * and operators == and !=.
         * */

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public int SNN { get; private set; }
        public string PermanentAddress { get; private set; }
        public string MobilePhone { get; private set; }
        public string Email { get; private set; }
        public string Course { get; private set; }
        public Specialty Specialty { get; private set; }
        public University University { get; private set; }
        public Faculty Faculty { get; private set; }

        public Student()
        {
        }

        public Student(string firstname,string lastname,int snn)
            :this()
        {
            this.FirstName = firstname;
            this.LastName = lastname;
            this.SNN = snn;
        }
        public Student(string firstname,string lastname
            , int snn, string permanentaddress
            , string mobilephone,string email
            ,string course, Specialty specialty
            ,University university, Faculty faculty)
            :this(firstname,lastname,snn)
        {
            
            this.PermanentAddress = permanentaddress;
            this.MobilePhone = mobilephone;
            this.Email = email;
            this.Course = course;
            this.Specialty = specialty;
            this.University = university;
            this.Faculty = faculty;

        }

        

        public override bool Equals(object obj)
        {
            var student = obj as Student;
            if (student==null)
            {
                throw new ArgumentException("Object is not a Student");
                                
            }
            if (this.GetHashCode()==student.GetHashCode())
            {
                return true;
            }
            return false;
        }
        public override int GetHashCode()
        {
            return this.FirstName.GetHashCode() ^ this.SNN.GetHashCode();
        }

        public override string ToString()
        {
            return this.FirstName + " " + this.LastName;
        }
        public static bool operator ==(Student first, Student second)
        {
            return Student.Equals(first, second);
        }

        public static bool operator !=(Student first, Student second)
        {
            return !Student.Equals(first, second);
        }
        /*
         * 2.Add implementations of the ICloneable interface.
         * The Clone() method should deeply copy all object
         * 's fields into a new object of type Student.
         * */

        public object Clone()
        {
            var clone = new Student();
            clone.FirstName = this.FirstName;
            clone.LastName = this.LastName;
            clone.SNN = this.SNN;
            clone.PermanentAddress = this.PermanentAddress;
            clone.MobilePhone = this.MobilePhone;
            clone.Email = this.Email;
            clone.Course = this.Course;
            clone.Specialty = this.Specialty;
            clone.University = this.University;
            clone.Faculty = this.Faculty;
            return clone;
        }

        /* 3.Implement the  IComparable<Student> interface to
         * compare students by names (as first criteria, in
         * lexicographic order) and by social security
         * number (as second criteria, in increasing order).
         * */

        public int CompareTo(Student student)
        {
            if (student==null)
            {
                return 1; //Microsoft convention
            }
            if (this.FirstName != student.FirstName)
            {
                return string.Compare(this.FirstName, student.FirstName);
            }
            else if (this.SNN != student.SNN)
            {
                if (this.SNN < student.SNN)
                {
                    return -1;
                }
                else
                {
                    return 1;
                }
            }
            else return 0;
        }
    }
}
