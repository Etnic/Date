using System;
using Xunit;

namespace Date.Tests
{
    public class CalculateTests
    {
        [Fact]
        public void CalculateTests_CalendarDays_GetCorrectDate()
        {
            var expectedDate = new DateTime(2019, 11, 4);
            var inputDate = new DateTime(2019, 10, 14);
            var days = 21;

            var result = Calculate.CalculateDate(inputDate, days, WorkOrCalendarDay.CalendarDay);

            Assert.Equal(expectedDate, result);
        }

        [Fact]
        public void CalculateTests_CalendarDays_GetCorrectDate2()
        {
            var expectedDate = new DateTime(2025, 11, 4);
            var inputDate = new DateTime(2019, 10, 14);
            var days = 2213;

            var result = Calculate.CalculateDate(inputDate, days, WorkOrCalendarDay.CalendarDay);

            Assert.Equal(expectedDate, result);
        }

        [Fact]
        public void CalculateTests_WorkingDays_GetCorrectDate()
        {
            var expectedDate = new DateTime(2019, 12, 31);
            var inputDate = new DateTime(2019, 12, 13);
            var days = 9;

            var result = Calculate.CalculateDate(inputDate, days, WorkOrCalendarDay.WorkingDay);

            Assert.Equal(expectedDate, result);
        }

        [Fact]
        public void CalculateTests_WorkingDays_GetCorrectDate2()
        {
            var expectedDate = new DateTime(2019, 11, 5);
            var inputDate = new DateTime(2019, 10, 14);
            var days = 15;

            var result = Calculate.CalculateDate(inputDate, days, WorkOrCalendarDay.WorkingDay);

            Assert.Equal(expectedDate, result);
        }

        [Fact]
        public void CalculateTests_WorkingDays_GetCorrectDate3()
        {
            var expectedDate = new DateTime(2019, 12, 27);
            var inputDate = new DateTime(2019, 12, 18);
            var days = 4;

            var result = Calculate.CalculateDate(inputDate, days, WorkOrCalendarDay.WorkingDay);

            Assert.Equal(expectedDate, result);
        }

        [Fact]
        public void CalculateTests_WorkingDays_GetCorrectDate4()
        {
            var expectedDate = new DateTime(2020, 12, 28);
            var inputDate = new DateTime(2020, 12, 18);
            var days = 4;

            var result = Calculate.CalculateDate(inputDate, days, WorkOrCalendarDay.WorkingDay);

            Assert.Equal(expectedDate, result);
        }

        [Fact]
        public void CalculateTests_WorkingDays_GetCorrectDate5()
        {
            var expectedDate = new DateTime(2019, 12, 16);
            var inputDate = new DateTime(2019, 12, 15);
            var days = 1;

            var result = Calculate.CalculateDate(inputDate, days, WorkOrCalendarDay.WorkingDay);

            Assert.Equal(expectedDate, result);
        }

        [Fact]
        public void CalculateTests_WorkingDays_GetCorrectDate6()
        {
            var expectedDate = new DateTime(2020, 1, 10);
            var inputDate = new DateTime(2019, 12, 14);
            var days = 15;

            var result = Calculate.CalculateDate(inputDate, days, WorkOrCalendarDay.WorkingDay);

            Assert.Equal(expectedDate, result);
        }

        [Fact]
        public void CalculateTests_WorkingDays_GetCorrectDate7()
        {
            var expectedDate = new DateTime(2019, 12, 27);
            var inputDate = new DateTime(2019, 12, 24);
            var days = 1;

            var result = Calculate.CalculateDate(inputDate, days, WorkOrCalendarDay.WorkingDay);

            Assert.Equal(expectedDate, result);
        }

        [Fact]
        public void CalculateTests_WorkingDays_GetCorrectDate8()
        {
            var expectedDate = new DateTime(2019, 12, 30);
            var inputDate = new DateTime(2019, 12, 24);
            var days = 2;

            var result = Calculate.CalculateDate(inputDate, days, WorkOrCalendarDay.WorkingDay);

            Assert.Equal(expectedDate, result);
        }

        [Fact]
        public void CalculateTests_WorkingDays_GetCorrectDate9()
        {
            var expectedDate = new DateTime(2020, 4, 20);
            var inputDate = new DateTime(2020, 4, 4);
            var days = 9;

            var result = Calculate.CalculateDate(inputDate, days, WorkOrCalendarDay.WorkingDay);

            Assert.Equal(expectedDate, result);
        }

        [Fact]
        public void CalculateTests_WorkingDays_GetCorrectDate10()
        {
            var expectedDate = new DateTime(2022, 8, 30);
            var inputDate = new DateTime(2022, 8, 26);
            var days = 1;

            var result = Calculate.CalculateDate(inputDate, days, WorkOrCalendarDay.WorkingDay);

            Assert.Equal(expectedDate, result);
        }
    }
}
