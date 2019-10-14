using System;
using System.Collections.Generic;

namespace Date
{
    class Program
    {
        static void Main(string[] args)

        {           
            var date = Calculate.CalculateDate(new DateTime(2019,12,14), 200, WorkOrCalendarDay.workingDay);

            Console.WriteLine(date);
            Console.WriteLine(date.DayOfWeek);
            Console.ReadKey();
        }
    }
}
