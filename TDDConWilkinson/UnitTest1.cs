using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
namespace TDDConWilkinson
{
    [TestClass]
    public class YYYYTest1
    {
        [TestMethod]
        public void ADayOfWeekCanBeIsHoliday()
        {
            var holidayCalendar = new HolidayCalendar();
            holidayCalendar.makeDayOfWeekAsHoliday(DayOfWeek.Saturday);
            var saturday = new DateTime(2014, 3, 1);
            Assert.IsTrue(holidayCalendar.isHoliday(saturday));
        }

        [TestMethod]
        public void ADayOfWeekCanNotBeIsHoliday()
        {
            var holidayCalendar = new HolidayCalendar();
            var monday = new DateTime(2014, 3, 3);
            Assert.IsFalse(holidayCalendar.isHoliday(monday));
        }

        [TestMethod]
        public void MoreThanOneDayOfWeekCanBeHoliday()
        {
            var holidayCalendar = new HolidayCalendar();
            holidayCalendar.makeDayOfWeekAsHoliday(DayOfWeek.Sunday);
            holidayCalendar.makeDayOfWeekAsHoliday(DayOfWeek.Saturday);
            var sunday = new DateTime(2014, 3, 2);
            var saturday = new DateTime(2014, 3, 1);
            Assert.IsTrue(holidayCalendar.isHoliday(sunday));
            Assert.IsTrue(holidayCalendar.isHoliday(saturday));
        }

        [TestMethod]
        public void test1()
        {
            var holidayCalendar = new HolidayCalendar();
            holidayCalendar.makeDayOfMonthAsHoliday(1, 1);
            var janauryFirst = new DateTime(2014, 1, 1);
            Assert.IsTrue(holidayCalendar.isHoliday(janauryFirst));
        }

        [TestMethod]
        public void test2()
        {
            var holidayCalendar = new HolidayCalendar();
            holidayCalendar.makeDayOfMonthAsHoliday(1, 1);
            var chrismas = new DateTime(2014, 12, 25);
            Assert.IsFalse(holidayCalendar.isHoliday(chrismas));
        }

        [TestMethod]
        public void test3()
        {
            var holidayCalendar = new HolidayCalendar();
            holidayCalendar.makeDayOfMonthAsHoliday(1, 1);
            holidayCalendar.makeDayOfMonthAsHoliday(12, 25);
            var janauryFirst = new DateTime(2014, 1, 1);
            var chrismas = new DateTime(2014, 12, 25);
            Assert.IsTrue(holidayCalendar.isHoliday(janauryFirst));
            Assert.IsTrue(holidayCalendar.isHoliday(chrismas));
        }

        [TestMethod]
        public void test4()
        {
            var holidayCalendar = new HolidayCalendar();
            var date = new DateTime(2014, 1, 12);
            holidayCalendar.makeDateHoliday(date);
            Assert.IsTrue(holidayCalendar.isHoliday(date));
        }

       /* [TestMethod]
        public void test5()
        {
            var holidayCalendar = new HolidayCalendar();
            holidayCalendar.makeDayOfWeekAsHoliday(new DateTime(1990, 1, 1), new DateTime(1999, 12, 31), DayOfWeek.Monday);
            Assert.IsTrue(holidayCalendar.isHoliday(new DateTime(1998, 3, 2)));
        }*/
    }

    public class HolidayCalendar
    {
        private IList<DayOfWeek> listaDaysOfWeekHoliday = new List<DayOfWeek>();
        private IList<Tuple<int, int>> listaDaysOfMonthHoliday = new List<Tuple<int, int>>();
        IList<DateTime> listaDatesHoliday = new List<DateTime>();

        public bool isHoliday(DateTime calendar)
        {
            return  isDayOfWeekHoliday(calendar) ||
                    isDayOfMonthHoliday(calendar) ||
                    isDateHoliday(calendar);
        }

        private bool isDateHoliday(DateTime calendar)
        {
            return listaDatesHoliday.Contains(calendar);
        }

        private bool isDayOfMonthHoliday(DateTime calendar)
        {
            return listaDaysOfMonthHoliday.Contains(new Tuple<int, int>(calendar.Month, calendar.Day));
        }

        private bool isDayOfWeekHoliday(DateTime calendar)
        {
            return listaDaysOfWeekHoliday.Contains(calendar.DayOfWeek);
        }

        public void makeDayOfWeekAsHoliday(DayOfWeek dayOfWeek)
        {
            this.listaDaysOfWeekHoliday.Add( dayOfWeek );
        }

        public void makeDateHoliday(DateTime date)
        {
            listaDatesHoliday.Add(date);
        }

        public void makeDayOfMonthAsHoliday(int numberMonth, int numberDay)
        {
            listaDaysOfMonthHoliday.Add(new Tuple<int, int>(numberMonth, numberDay));
        }

        internal void makeDayOfWeekAsHoliday(DateTime dateFrom, DateTime dateTo, DayOfWeek dayOfWeek)
        {
            throw new NotImplementedException();
        }
    }
}
