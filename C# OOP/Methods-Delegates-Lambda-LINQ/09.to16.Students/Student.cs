using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.to16.Students
{
    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int FN { get; set; }
        public string Tel { get; set; }
        public string Email { get; set; }
        public List<int> Marks { get; set; }
        public int GroupNumber { get; set; }
        public Group Group { get; set; }

        public override string ToString()
        {
            return string.Format("Name: {0} {1}, FN: {2}, Tel: {3}, Email: {4}, GroupNumber: {5} Department: {6} Marks: {7}",
                FirstName, LastName, FN, Tel, Email, GroupNumber, Group.DepartmentName, string.Join(",", Marks));
        }


    }
}
