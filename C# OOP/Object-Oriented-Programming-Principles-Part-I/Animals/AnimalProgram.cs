using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals
{
    public class AnimalProgram
    {
        static void Main()
        {
            Tomcat tomcat = new Tomcat("Tom",8);
            Dog dog = new Dog("Doge", 6,false);
            Frog frog = new Frog("Kvakadjek",3,false);
            Cat cat = new Cat("Kotka", 3,true);
            Kitten kitten = new Kitten("Kittycat", 2);
            List <Animals> animals = new List<Animals>();
            animals.Add(tomcat);
            animals.Add(dog);
            animals.Add(frog);
            animals.Add(cat); 
            animals.Add(kitten);

            foreach (var animal in animals)
            {
                Console.WriteLine(animal.GetType().Name+" goes ");
                animal.Sound();
            }
            double averageAge = AverageAge(animals);
            Console.WriteLine("The average age of all animals is:"+averageAge);
        }
        public static double AverageAge(IList<Animals> collection)
        {
            double averageAge = collection.Average(animal => animal.Age);
                      
            return averageAge;
        }
    }
}
