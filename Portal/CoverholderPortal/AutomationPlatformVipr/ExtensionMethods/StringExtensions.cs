using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace AutomationPlatformVipr.ExtensionMethods
{
  public static  class StringExtensions
    {
        public static DateTime DateFromRegex(this string s)
        {
            var days = int.Parse(Regex.Match(s, "^.*?(?=d)").Value);
            var months = int.Parse(Regex.Match(s, "(?<=d)(.*?)(?=m)").Value);
            var years = int.Parse(Regex.Match(s, "(?<=m)(.*?)(?=y)").Value);

            if (days == 0 && months == 0 && years == 0) return DateTime.Now;

            return DateTime.Today.AddDays(days).AddMonths(months).AddYears(years);
        }
    }
}
