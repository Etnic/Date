using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Date
{
    public enum WorkOrCalendarDay
    {
        workingDay = 0,
        calendarDay
    }

    public static class Calculate
    {
        public static DateTime CalculateDate(DateTime date, int days, WorkOrCalendarDay workOrCalendarDay)
        {
            if (workOrCalendarDay == WorkOrCalendarDay.calendarDay)
            {
                return date.AddDays(days).Date;
            }
            else
            {   
                var bankHolidays = GetHolidayDaysBetweenDate(date, days, Calculate.GetHolidays(new List<int>() { 2019, 2020 }));
                
                for (int i = 1; i <= days; i++)
                {
                    if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday || bankHolidays.Contains(date))
                    {
                        days++;
                    }

                      date =  date.AddDays(1);
                }              

                var finalDate = date;

                switch (date.DayOfWeek)
                {
                    case DayOfWeek.Saturday:
                        finalDate = date.AddDays(2);
                        break;

                    case DayOfWeek.Sunday:
                        finalDate = date.AddDays(1);
                        break;
                    default:
                        break;
                }

                return finalDate;
            }
        }
        
        public static List<DateTime> GetHolidayDaysBetweenDate(
        this DateTime startDate,
        int days,
        IEnumerable<DateTime> holidays)
        {
            var endDate = startDate.AddDays(days);
            var list = new List<DateTime>();

            for (var current = startDate; current < endDate; current = current.AddDays(1))
            {
                
                if (holidays.Contains(current.Date))
                {
                    list.Add(current.Date);
                }
            }

            return list;
        }
        
        public static IEnumerable<DateTime> GetHolidays(IEnumerable<int> years, string countryCode = null, string cityName = null)
        {
            var lst = new List<DateTime>();

            foreach (var year in years.Distinct())
            {
                lst.AddRange(new[] {
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
                lst.Add(easterDate);
                lst.Add(easterDate.AddDays(1)); 
            }
            return lst;
        }

        public static DateTime GetEasterSunday(int year)
        {
            int day = 0;
            int month = 0;

            int g = year % 19;
            int c = year / 100;
            int h = (c - (int)(c / 4) - (int)((8 * c + 13) / 25) + 19 * g + 15) % 30;
            int i = h - (int)(h / 28) * (1 - (int)(h / 28) * (int)(29 / (h + 1)) * (int)((21 - g) / 11));

            day = i - ((year + (int)(year / 4) + i + 2 - c + (int)(c / 4)) % 7) + 28;
            month = 3;

            if (day > 31)
            {
                month++;
                day -= 31;
            }

            return new DateTime(year, month, day);
        }
    }
}
