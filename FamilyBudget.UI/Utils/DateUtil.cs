using System;
using System.Globalization;

namespace FamilyBudget.UI.Utils
{
    public static class DateUtil
    {
        public static DateTime GetFirstDayOfMonth(DateTime date)
        {
            return new DateTime(date.Year, date.Month, 1);
        }

        public static DateTime GetLastDayOfMonth(DateTime date)
        {
            return GetFirstDayOfMonth(date).AddMonths(1).AddDays(-1);
        }

        public static string FormatDate(DateTime date, string format = "yyyy-MM-dd")
        {
            return date.ToString(format);
        }

        public static bool TryParseDate(string dateString, string format, out DateTime date)
        {
            return DateTime.TryParseExact(dateString, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out date);
        }

        public static bool IsDateInRange(DateTime date, DateTime startDate, DateTime endDate)
        {
            return date >= startDate && date <= endDate;
        }

        
    }
}
