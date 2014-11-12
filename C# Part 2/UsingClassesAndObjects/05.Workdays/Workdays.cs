using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    class Workdays
    {
        /*
         * Write a method that calculates the number of workdays between today and given date, 
         * passed as parameter. Consider that workdays are all days from Monday to Friday except
         * a fixed list of public holidays specified preliminary as array.
         */

        public static DateTime date;

        public static int workdays = 0;

        public static bool IsAHoliday(DateTime day)
        {
            
            DateTime[] holidays = new DateTime[15]
            {
                Convert.ToDateTime("1.1"),
                Convert.ToDateTime("3,3"),
                Convert.ToDateTime("18,4"),
                Convert.ToDateTime("19,4"),
                Convert.ToDateTime("20,4"),
                Convert.ToDateTime("1,5"),
                Convert.ToDateTime("6,5"),
                Convert.ToDateTime("24,5"),
                Convert.ToDateTime("6,9"),
                Convert.ToDateTime("22,9"),
                Convert.ToDateTime("1,11"),
                Convert.ToDateTime("24,12"),
                Convert.ToDateTime("25,12"),
                Convert.ToDateTime("26,12"),
                Convert.ToDateTime("31,12")
               
            };
            for (int i = 0; i < holidays.Length; i++)
            {
                if (day==holidays[i])
                {
                    return true;
                }
            }
            return false;
        }


        public static bool IsWeekend(DateTime day)
        {
            if (day.DayOfWeek == DayOfWeek.Saturday || day.DayOfWeek == DayOfWeek.Sunday)
            {
                return true;
            }
            return false;
        }

        public static DateTime DayAfterDay(DateTime day)
        {
            if (day==date)
            {
                return day;
            }
            if (IsWeekend(day)==false && IsAHoliday(day)==false )
            {
                workdays++;
                return DayAfterDay(day.AddDays(1));
            }
            return DayAfterDay(day.AddDays(1));
        }

        static void Main()
        {
            Console.WriteLine("Today is: "+DateTime.Now.Date.ToString("d"));
            Console.Write("Enter a future date: ");
           
            date = Convert.ToDateTime(Console.ReadLine());
            DayAfterDay(DateTime.Now.Date);
            Console.WriteLine("From "+DateTime.Now.Date.ToString("d")+"\nto "+date.ToString("d")+"\nTotal Workdays: "+workdays);
            
            
        }
    }

