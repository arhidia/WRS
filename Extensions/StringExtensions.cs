using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace WashingtonRedskins.Extensions
{
    static class StringExtensions
    {
        public static string GrabFirst(this String s, string pattern, bool ignoreCase = true)
        {
            Match match = (ignoreCase) ? Regex.Match(s, pattern, RegexOptions.IgnoreCase) : Regex.Match(s, pattern);

            if (match.Success)
            {
                return match.Groups[1].Value;
            }

            return null;
        }
    }
}
