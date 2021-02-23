using AutomationPlatformVipr.ExtensionMethods;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using TechTalk.SpecFlow.Assist;

namespace AutomationPlatformVipr.ValueRetrivers
{
          public class DateTimeParsingValueRetriever : IValueRetriever
        {
            public bool CanRetrieve(KeyValuePair<string, string> keyValuePair, Type targetType, Type propertyType)
            {
                if (!keyValuePair.Key.Contains("date", StringComparison.OrdinalIgnoreCase))
                {
                    return false;
                }

                if ((Regex.IsMatch(keyValuePair.Value, "^.*?(?=d)(.*?)(?=m)(.*?)y")
                     || DateTime.TryParse(keyValuePair.Value, out var date))
                     && propertyType == typeof(DateTime))
                {
                    return true;
                }

                return false;
            }

            public object Retrieve(KeyValuePair<string, string> keyValuePair, Type targetType, Type propertyType)
            {
                //Instead check that we can parse as DateTime
                if (Regex.IsMatch(keyValuePair.Value, "^.*?(?=d)(.*?)(?=m)(.*?)y"))
                {
                    return keyValuePair.Value.DateFromRegex();
                }
                else
                {
                    return (object)this.GetValue(keyValuePair.Value);
                }
            }

            public virtual DateTime GetValue(string value)
            {
                DateTime result;
                DateTime.TryParse(value, (IFormatProvider)CultureInfo.CurrentCulture, DateTimeStyles.None, out result);
                return result;
            }
        
    }
}
