using AutomationPlatformVipr.Common;
using AutomationPlatformVipr.ExtensionMethods;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using System;

namespace AutomationPlatformVipr.CoreUI
{
    public class AppConfigManager
    {
        public static readonly IConfigurationRoot configuration = new ConfigurationBuilder()
         .AddJsonFile("appsettings.json", true, true)
                .Build();
        private static TimeSpan _implicitTimeout;
        public static TimeSpan ImplicitTimeout => _implicitTimeout = _implicitTimeout =
            TimeSpan.FromSeconds(double.Parse(configuration["Browser:ImplicitTimeout"]));
        public static string BaseUrl()
        {
            return configuration["Client:BaseUrl"] ?? string.Empty;
        }

        public static string HostBaseUrl()
        {
            return configuration["Client:HostBaseUrl"] ?? string.Empty;
        }
        public static string Browser()
        {
            return configuration["Browser:BrowserType"] ?? string.Empty;
        }
        public static bool Reporting()
        {
            return bool.TryParse(configuration["TestOptions:Reporting"], out var b) && b;
        }
        public static bool IsVM()
        {
            return bool.TryParse(configuration["Browser:Headless"], out var b) && b;
        }

    }
}
