using System;
using System.Collections.Generic;
using AC.AvalonControlsLibrary.Controls;
using AC.AvalonControlsLibrary.Exception;


namespace AC.AvalonControlsLibrary.Core
{
    /// <summary>
    /// Helper class for dates
    /// </summary>
    public class DateHelper
    {
        //the list of months in a year
        public static readonly string[] Months = new string[]
        {
            "January",
            "February",
            "March",
            "April",
            "May",
            "June",
            "July",
            "August",
            "September",
            "October",
            "November",
            "December"
        };

        //caches the days in a dict where the key is the number of days
        //the key is a hash of month, year
        readonly Dictionary<KeyValuePair<int, int>, DayCell[]> daysArrays = new Dictionary<KeyValuePair<int, int>, DayCell[]>();

        /// <summary>
        /// Generates an array of days in a month
        /// </summary>
        /// <param name="month">The month to get the days for </param>
        /// <param name="year">The year to get the days for </param>
        /// <param name="maxDate">The max date to generate enabled cells</param>
        /// <param name="minDate">The min date to generate enabled cells</param>
        /// <param name="isCurrentMonth">flag to indicate if this is the current month</param>
        /// <returns>Returns an int array full of days in a month</returns>
        public DayCell[] GetDaysOfMonth(int month, int year,
            DateTime minDate, DateTime maxDate, bool isCurrentMonth)
        {
            KeyValuePair<int, int> key = new KeyValuePair<int, int>(month, year);
            int daysCount = DateTime.DaysInMonth(year, month);

            DayCell[] days = null;

            if (daysArrays.ContainsKey(key))
            {
                days = daysArrays[key];
                foreach (DayCell item in days)
                {
                    item.IsEnabled = IsDateWithinRange(minDate, maxDate, item);
                    item.IsInCurrentMonth = isCurrentMonth;
                }
            }
            else
            {
                days = new DayCell[daysCount];

                for (int i = 0; i < days.Length; i++)
                {
                    DayCell item = new DayCell(i + 1, month, year);
                    item.IsEnabled = IsDateWithinRange(minDate, maxDate, item);
                    item.IsInCurrentMonth = isCurrentMonth;
                    days[i] = item;
                }

                daysArrays[key] = days;//cache the array
            }

            return days;
        }

        #region Helper Methods
        /// <summary>
        /// Checks if the specified date is greater than 
        /// </summary>
        /// <param name="minDate">The min date</param>
        /// <param name="maxDate">The max date</param>
        /// <param name="cell">The cell to check</param>
        /// <returns>Returns true if the cell is greater</returns>
        public static bool IsDateWithinRange(DateTime minDate, DateTime maxDate, DayCell cell)
        {
            long ticks = new DateTime(cell.YearNumber, cell.MonthNumber, cell.DayNumber).Ticks;
            return ticks >= minDate.Ticks && ticks <= maxDate.Ticks;
        }

        /// <summary>
        /// Gets the day of week for a specific date
        /// </summary>
        /// <param name="year">The year of the date</param>
        /// <param name="month">The month of the date</param>
        /// <param name="day">The day of the date</param>
        /// <returns>Returns the day of week</returns>
        public static DayOfWeek GetDayOfWeek(int year, int month, int day)
        {
            return new DateTime(year, month, day).DayOfWeek;
        }

        /// <summary>
        /// Gets a string that represents the string for the current month
        /// </summary>
        /// <param name="month">a number from 1 to 12</param>
        /// <returns>Returns the string that represents the month</returns>
        /// <exception cref="ArgumentException">Thrown if the month number is less than 1 or greater than 12</exception>
        public static string GetMonthDisplayName(int month)
        {
            if (month < 1 || month > 12)
                throw new ArgumentException(ExceptionStrings.INVALID_MONTH_NUMBER, "month");

            return Months[month - 1];
        }

        /// <summary>
        /// Moves one month forward
        /// </summary>
        /// <param name="currentMonth">The current month</param>
        /// <param name="currentYear">The current year</param>
        /// <param name="monthToGetNext">The next month</param>
        /// <param name="yearTogetNext">The relative year for the new month</param>
        public static void MoveMonthForward(int currentMonth, int currentYear,
            out int monthToGetNext, out int yearTogetNext)
        {
            monthToGetNext = currentMonth;
            yearTogetNext = currentYear;
            if (monthToGetNext < 12)
                monthToGetNext++;
            else//move a year forward
            {
                yearTogetNext++;
                monthToGetNext = 1;
            }
        }
        /// <summary>
        /// Move one month back
        /// </summary>
        /// <param name="currentMonth">The current month</param>
        /// <param name="currentYear">The current year</param>
        /// <param name="monthToGetPrevious">The previous month</param>
        /// <param name="yearToGetPrevious">The relative year for the new month</param>
        public static void MoveMonthBack(int currentMonth, int currentYear,
            out int monthToGetPrevious, out int yearToGetPrevious)
        {
            monthToGetPrevious = currentMonth;
            yearToGetPrevious = currentYear;
            if (monthToGetPrevious > 1)
                monthToGetPrevious--;
            else // move one year down
            {
                yearToGetPrevious--;
                monthToGetPrevious = 12;
            }
        }
        #endregion
    }

    /// <summary>
    /// Enum that specifies the list of months
    /// </summary>
    public enum Months
    {
        /// <summary>
        /// January 
        /// </summary>
        January = 1,
        /// <summary>
        /// February
        /// </summary>
        February = 2,
        /// <summary>
        /// March
        /// </summary>
        March = 3,
        /// <summary>
        /// April
        /// </summary>
        April = 4,
        /// <summary>
        /// May
        /// </summary>
        May = 5,
        /// <summary>
        /// June
        /// </summary>
        June = 6,
        /// <summary>
        /// July
        /// </summary>
        July = 7,
        /// <summary>
        /// August
        /// </summary>
        August = 8,
        /// <summary>
        /// September
        /// </summary>
        September = 9,
        /// <summary>
        /// October
        /// </summary>
        October = 10,
        /// <summary>
        /// November
        /// </summary>
        November = 11,
        /// <summary>
        /// December
        /// </summary>
        December = 12
    }
}
