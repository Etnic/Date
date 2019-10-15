using System;
using System.Collections.Generic;

namespace Date
{
    class Program
    {
        static void Main(string[] args)
        {
            var day = new DateTime(2019, 12, 28);
            var date = Calculate.CalculateDate(new DateTime(2019,12,14), 15, WorkOrCalendarDay.WorkingDay);
            var isWorkingDay = Calculate.IsWorkingDay(day);

            Console.WriteLine(date);
            Console.WriteLine(date.DayOfWeek);
            Console.WriteLine("\n");
            Console.WriteLine(day + " is working day " + isWorkingDay);
            Console.ReadKey();
        }
    }
}
