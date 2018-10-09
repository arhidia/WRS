using System;

namespace WashingtonRedskins.Extensions
{
    public static class TimeSpanExtensions
    {
        public static int toSeconds(this TimeSpan timeSpan)
        {
            return (int)Math.Floor(timeSpan.TotalSeconds);
        }
    }
}