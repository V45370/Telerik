using System;



class Employees
{
    struct Employee                             //In case we have to add a lot of employees.
    {                                           //Structures avoid declaring lots of variables, and storing values is more organized.
        public string firstName;    
        public string lastName;
        public byte age;
        public bool male;
        public int id;
        public int uniqNum;
    }

    static void Main()
    {
           
    Employee anonymous;                         //Declaring an employee named anonymous

    anonymous.firstName = "Anonymous";          //Accessing Variables for anonymous by using "."
    anonymous.lastName = "Anonymous";
    anonymous.age = 23;
    anonymous.male = true;
    anonymous.id = 12345;
    anonymous.uniqNum=27560001;

    Console.WriteLine("Firstname: {0}",anonymous.firstName);
    Console.WriteLine("Lastname: {0}",anonymous.lastName);
    Console.WriteLine("Age: {0}",anonymous.age);
    Console.WriteLine("Male?: {0}",anonymous.male);
    Console.WriteLine("ID: {0}",anonymous.id);
    Console.WriteLine("unique number: {0}",anonymous.uniqNum);


    }
}

