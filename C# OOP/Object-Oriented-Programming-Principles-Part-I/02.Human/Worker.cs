using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Human
{
    public class Worker : Human
    {
        public const int weekDays=5;
        public int WeekSalary { get; private set; }
        public int WorkHoursPerDay { get; private set; }

        public Worker(string firstName, string lastName, int weekSalary, int workHoursPerDay)
            : base(firstName, lastName)
        {
            this.WeekSalary = weekSalary;
            this.WorkHoursPerDay = workHoursPerDay;
        }
        public  double MoneyPerHour()
        {
            return this.WeekSalary / (weekDays * this.WorkHoursPerDay);
        }

    }
}
