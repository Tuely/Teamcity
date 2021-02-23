using AutomationPlatformVipr.Enums;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace AutomationPlatformVipr.CoreUI
{
   public class WebDriverSupport
    {
        [ThreadStatic] private static IWebDriver _supportDriver;
        public static IWebDriver SupportDriver()
        {
            return _supportDriver;
        }
        public static void DisposeDriver()
        {
            _supportDriver.Dispose();
            _supportDriver.Quit();
            _supportDriver.Close();
        }
        public static IWebDriver LaunchDriver()
        {
            _supportDriver = BrowserFactory.InitBrowser((BrowserType)Enum.Parse(typeof(BrowserType), AppConfigManager.Browser()));
            
            return _supportDriver;
        }

        public static IWebDriver LaunchDriver(string browserType)
        {
            _supportDriver = BrowserFactory.InitBrowser((BrowserType)Enum.Parse(typeof(BrowserType), browserType));
             return _supportDriver;
        }

        public static void BrowserBack()
        {
            _supportDriver.Navigate().Back();
        }
        public IWebElement FindNewElement(By by, int timeout = 10)
        {
            _supportDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(timeout);

            try
            {
                //Log.Info($"Searching for a new element by: {by}");
                return _supportDriver.FindElement(by);
            }
            catch (Exception e)
            {
                //Log.Error(e.Message);
                return default(IWebElement);
            }
            finally
            {
                _supportDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(timeout);
            }
        }

        public void SpecifiedPause(int milliSeconds)
        {
            Thread.Sleep(milliSeconds);
        }
    }
}
