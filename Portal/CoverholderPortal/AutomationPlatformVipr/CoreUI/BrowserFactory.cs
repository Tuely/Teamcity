using AutomationPlatformVipr.Enums;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using static AutomationPlatformVipr.Enums.BrowserType;
namespace AutomationPlatformVipr.CoreUI
{
    public class BrowserFactory
    {
        [ThreadStatic] public static IWebDriver Driver;

        private static readonly TimeSpan _timeSpan = AppConfigManager.ImplicitTimeout;

        public static IWebDriver InitBrowser(BrowserType? browserType)
        {
            browserType = browserType ?? Chrome;

            switch (browserType)
            {
                case Chrome:
                    Driver = ChromeDriver();
                    break;
                //case Firefox:
                //    Driver = FireFoxDriver();
                //    break;
                //case Ie:
                //    Driver = InternetExplorerDriver();
                //    break;
                default:
                    Driver = ChromeDriver();
                    break;
            }
            Driver.Manage().Timeouts().ImplicitWait = _timeSpan;
            Driver.Manage().Timeouts().PageLoad = _timeSpan;
            Driver.Manage().Window.Maximize();
            return Driver;
        }

        #region Browser configurations

        private static IWebDriver ChromeDriver()
        {
            //var options = new ChromeOptions { PageLoadStrategy = PageLoadStrategy.Normal };
            //options.AddUserProfilePreference("profile.managed_default_content_settings.notifications", 2);
            //var chromeDriverService = ChromeDriverService.CreateDefaultService();
            //options.AddArguments(new List<string> { "no-sandbox", "-incognito" });
            //Driver = new ChromeDriver(chromeDriverService, options);
            //return Driver;

            var options = new ChromeOptions { PageLoadStrategy = PageLoadStrategy.Normal };
            options.AddUserProfilePreference("profile.managed_default_content_settings.notifications", 2);
            var chromeDriverService = ChromeDriverService.CreateDefaultService();
            if (AppConfigManager.IsVM())
            {
                options.AddArguments(new List<string>() {
                "--silent-launch",
                "--no-startup-window",
                "no-sandbox",
                "headless",
                "disable-gpu",
                "-incognito",
                "--window-size=1920x1080"
                });
                chromeDriverService.HideCommandPromptWindow = true;    // This is to hidden the console.
            }
            else
            {
                options.AddArguments(new List<string> { "no-sandbox", "-incognito" });
            }

            Driver = new ChromeDriver(chromeDriverService, options);
           return Driver;
        }

        //private static IWebDriver FireFoxDriver()
        //{
        //    Log.Info("Creating new firefox driver.");
        //    var options = new FirefoxOptions();
        //    options.AddArgument("-incognito");
        //    options.AddArgument("--no-sandbox");
        //    Driver = new FirefoxDriver(options);
        //    //Driver.Manage().Timeouts().ImplicitWait = _timeSpan;
        //    //Driver.Manage().Window.Maximize();

        //    return Driver;
        //}

        //private static IWebDriver InternetExplorerDriver()
        //{
        //    Log.Info("Creating new internet explorer driver.");
        //    var dir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        //    var fileLocation = Path.Combine(dir ?? "", @"Drivers");

        //    var options = new InternetExplorerOptions { IgnoreZoomLevel = true, RequireWindowFocus = false };
        //    //options.AddAdditionalCapability("ignoreZoomSetting",true);
        //    //options.AddAdditionalCapability("EnableNativeEvents",false);
        //    Driver = new InternetExplorerDriver(fileLocation, options);

        //    return Driver;
        //}

        #endregion

    }


}
