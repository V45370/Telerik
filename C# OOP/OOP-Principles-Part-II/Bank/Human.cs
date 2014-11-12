namespace Bank
{
    public class Human : Customers
    {
        private int age;
        private string name;
        private string sex;
        public Human(int age, string name, string sex)
        {
            this.age = age;
            this.name = name;
            this.sex = sex;
        }
    }
}