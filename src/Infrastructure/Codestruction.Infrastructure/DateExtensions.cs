using System;
using System.Globalization;

namespace Codestruction.Infrastructure
{
    public static class DateExtensions
    {
        public static DateTime? FromMonthName(this string monthNameYear)
        {
            DateTime output;
            if (DateTime.TryParseExact(monthNameYear, "MMMM-yyyy", null, DateTimeStyles.None, out output))
            {
                return output;
            }
            return null;
        }
        public static string MonthName(this DateTime datetime)
        {
            return datetime.ToString("MMMM", CultureInfo.InvariantCulture);
        }

        public static string ToMonthYear(this DateTime datetime)
        {
            return datetime.ToString("MMMM-yyyy", CultureInfo.InvariantCulture).ToLower();
        }
    }

}
