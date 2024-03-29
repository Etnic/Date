﻿using System;
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
        private readonly static Dictionary<int, List<DateTime>> cache = new Dictionary<int, List<DateTime>>();

        public static DateTime CalculateDate(DateTime date, int days, WorkOrCalendarDay workOrCalendarDay)
        {
            if (workOrCalendarDay == WorkOrCalendarDay.CalendarDay)
            {
                return date.AddDays(days).Date;
            }
            else
            {
                if (!cache.ContainsKey(date.Year))
                {
                    GetHolidays(date, days);
                }

                var bankHolidays = cache.SelectMany(d => d.Value).ToList();

                date = IsWeekendOrBankholiday(date, bankHolidays) ? Calc(date, days - 1, bankHolidays) : Calc(date, days, bankHolidays);

                return date;
            }
        }

        public static bool IsWorkingDay(DateTime date)
        {
            if (!cache.ContainsKey(date.Year))
            {
                GetHolidays(date, 0);
            }

            var bankHolidays = cache.SelectMany(d => d.Value).ToList();

            return !IsWeekendOrBankholiday(date, bankHolidays);
        }

        private static bool IsWeekendOrBankholiday(DateTime date, List<DateTime> bankHolidays)
        {
            return date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday || bankHolidays.Contains(date);
        }

        private static void GetHolidays(DateTime year, int days)
        {
            var years = new List<int>();
            var bankHolidays = new List<DateTime>();
            var finalYear = year.AddDays(days * 2).Year;

            for (int i = year.Year; i <= finalYear; i++)
            {
                years.Add(i);
            }

            var listOfHolidays = new List<DateTime>();

            foreach (var item in years.Distinct())
            {
                listOfHolidays.AddRange(new[] {
                new DateTime(item, 1, 1),
                new DateTime(item, 1, 6),
                new DateTime(item, 4, 19),
                new DateTime(item, 4, 22),
                new DateTime(item, 5, 1),
                new DateTime(item, 5, 8),
                new DateTime(item, 7, 5),
                new DateTime(item, 7, 5),
                new DateTime(item, 8, 29),
                new DateTime(item, 9, 1),
                new DateTime(item, 9, 15),
                new DateTime(item, 11, 1),
                new DateTime(item, 11, 17),
                new DateTime(item, 12, 24),
                new DateTime(item, 12, 25),
                new DateTime(item, 12, 26)
            });

                var easterDate = GetEasterSunday(item);
                listOfHolidays.Add(easterDate.AddDays(-2));
                listOfHolidays.Add(easterDate.AddDays(1));
                cache.Add(item, listOfHolidays);
            }
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
        private static DateTime Calc(DateTime date, int days, List<DateTime> bankHolidays)
        {
            for (int i = 0; i < days; i++)
            {
                if (IsWeekendOrBankholiday(date, bankHolidays))
                {
                    days++;
                }

                date = date.AddDays(1);
            }

            date = CheckLastDay(date, bankHolidays);
            date = CheckLastDay(date, bankHolidays);
            date = CheckLastDay(date, bankHolidays);

            return date;
        }

        private static DateTime CheckLastDay(DateTime date, List<DateTime> bankHolidays)
        {
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

            while (bankHolidays.Contains(date))
            {
                date = date.AddDays(1);
            }

            return date;
        }
    }
}
