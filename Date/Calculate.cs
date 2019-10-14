using System;
using System.Collections.Generic;
using System.Linq;

namespace Date
{
    public enum WorkOrCalendarDay
    {
        WorkingDay = 0,
        CalendarDay
    }

    public static class Calculate
    {
        public static DateTime CalculateDate(DateTime date, int days, WorkOrCalendarDay workOrCalendarDay)
        {
            if (workOrCalendarDay == WorkOrCalendarDay.CalendarDay)
            {
                return date.AddDays(days).Date;
            }
            else
            {
                var bankHolidays = GetHolidays(new List<int>() { 2019, 2020 });

                date = date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday || bankHolidays.Contains(date) ? calc(date, days - 1, bankHolidays) : calc(date, days, bankHolidays);
                
                switch (date.DayOfWeek)
                {
                    case DayOfWeek.Saturday:
                        date = date.AddDays(2);
                        break;

                    case DayOfWeek.Sunday:
                        date = date.AddDays(1);
                        break;

                    default:
                        break;
                }

                return date;
            }
        }        

        private static List<DateTime> GetHolidays(IEnumerable<int> years)
        {
            var listOfHolidays = new List<DateTime>();

            foreach (var year in years.Distinct())
            {
                listOfHolidays.AddRange(new[] {
                new DateTime(year, 1, 1),
                new DateTime(year, 1, 6),
                new DateTime(year, 4, 19),
                new DateTime(year, 4, 22),
                new DateTime(year, 5, 1),
                new DateTime(year, 5, 8),
                new DateTime(year, 7, 5),
                new DateTime(year, 7, 5),
                new DateTime(year, 8, 29),
                new DateTime(year, 9, 1),
                new DateTime(year, 9, 15),
                new DateTime(year, 11, 1),
                new DateTime(year, 11, 17),
                new DateTime(year, 12, 24),
                new DateTime(year, 12, 25),
                new DateTime(year, 12, 26)
            });

                var easterDate = GetEasterSunday(year);
                listOfHolidays.Add(easterDate.AddDays(-2));
                listOfHolidays.Add(easterDate.AddDays(1));
            }

            return listOfHolidays;
        }

        private static DateTime GetEasterSunday(int year)
        {
            int g = year % 19;
            int c = year / 100;
            int h = (c - (int)(c / 4) - (int)((8 * c + 13) / 25) + 19 * g + 15) % 30;
            int i = h - (int)(h / 28) * (1 - (int)(h / 28) * (int)(29 / (h + 1)) * (int)((21 - g) / 11));

            int day = i - (year + year / 4 + i + 2 - c + c / 4) % 7 + 28;
            int month = 3;
            if (day > 31)
            {
                month++;
                day -= 31;
            }

            return new DateTime(year, month, day);
        }

        // If first day is weekend or holiday decrease days by one
        private static DateTime calc(DateTime date, int days, List<DateTime> bankHolidays)
        {
            for (int i = 0; i < days; i++)
            {
                if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday || bankHolidays.Contains(date))
                {
                    days++;
                }

                date = date.AddDays(1);
            }

            while (bankHolidays.Contains(date))
            {
                date = date.AddDays(1);
            }

            return date;
        }
    }
}
