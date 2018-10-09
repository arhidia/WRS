using System;

namespace WashingtonRedskins.Extensions
{
    static class DateTimeExtensions
    {
        public static DateTime setToMidnight(this DateTime dateTime)
        {
            dateTime = dateTime.AddHours(dateTime.Hour * -1);
            dateTime = dateTime.AddMinutes(dateTime.Minute * -1);
            dateTime = dateTime.AddSeconds(dateTime.Second * -1);

            return dateTime;
        }

        public static int weekOfYear(this DateTime datetime)
        {
            DateTime thursdayOfWeek;
            switch (datetime.DayOfWeek)
            {
                case DayOfWeek.Monday:
                    thursdayOfWeek = datetime.AddDays(3);
                    break;
                case DayOfWeek.Tuesday:
                    thursdayOfWeek = datetime.AddDays(2);
                    break;
                case DayOfWeek.Wednesday:
                    thursdayOfWeek = datetime.AddDays(1);
                    break;
                case DayOfWeek.Thursday:
                    thursdayOfWeek = datetime;
                    break;
                case DayOfWeek.Friday:
                    thursdayOfWeek = datetime.AddDays(-1);
                    break;
                case DayOfWeek.Saturday:
                    thursdayOfWeek = datetime.AddDays(-2);
                    break;
                default:
                    thursdayOfWeek = datetime.AddDays(-3);
                    break;
            }
            return thursdayOfWeek.Year * 100 + (int)Math.Floor((double)thursdayOfWeek.DayOfYear / 7);
        }
    }
}
