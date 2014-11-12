using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Human
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();
            List<Worker> workers = new List<Worker>();
            students.Add(new Student("Pesho", "Peshov",6));
            students.Add(new Student("Joro", "Peshov", 6));
            students.Add(new Student("Mitko", "Georgiev", 2));
            students.Add(new Student("Gosho", "Goshov", 3));
            students.Add(new Student("Danail", "Dimitrov", 4));
            students.Add(new Student("Rusi", "Rusev", 5));
            students.Add(new Student("Gloriq", "Dimitrova", 6));
            students.Add(new Student("Dobrin", "Iordanov", 6));
            students.Add(new Student("Stefan", "Kolev", 5));
            students.Add(new Student("Kostadin", "Kucarov", 2));

            var gradeSorted = students.OrderBy(student => student.Grade);

            Console.WriteLine("Grade sorted:");
            foreach (var student in gradeSorted)
            {
                Console.WriteLine(student.FirstName+" "+student.Grade);
            }
            
            workers.Add(new Worker("Pesho", "Peshov", 100, 4));
            workers.Add(new Worker("Joro", "Peshov", 150, 8));
            workers.Add(new Worker("Mitko", "Georgiev", 200, 5));
            workers.Add(new Worker("Gosho", "Goshov", 200, 8));
            workers.Add(new Worker("Danail", "Dimitrov", 200, 12));
            workers.Add(new Worker("Rusi", "Rusev", 200, 4));
            workers.Add(new Worker("Gloriq", "Dimitrova", 150, 8));
            workers.Add(new Worker("Dobrin", "Iordanov", 500, 6));
            workers.Add(new Worker("Stefan", "Kolev", 100, 6));
            workers.Add(new Worker("Kostadin", "Kucarov", 150, 8));

            Console.WriteLine();
            Console.WriteLine("Money per hour sorted(descending):");
            var salarySorted = workers.OrderByDescending(worker => worker.MoneyPerHour());
            foreach (var worker in salarySorted)
            {                
                Console.WriteLine(worker.FirstName+" "+worker.MoneyPerHour());
            }

            
            var humans = new List<Human>();
            humans.AddRange(students);
            humans.AddRange(workers);

            
            Console.WriteLine();
            Console.WriteLine("Humans sorted by firstname:");
            var sortHumans = humans.OrderBy(human => human.FirstName);
            foreach (var human in sortHumans)
            {
                Console.WriteLine(human.FirstName);
            }

            
        }
    }
}
