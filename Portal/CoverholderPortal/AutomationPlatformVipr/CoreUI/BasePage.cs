using NUnit.Framework;
using OpenQA.Selenium;

using SeleniumExtras.PageObjects;
using System.Collections.Generic;
using System.Text;

namespace AutomationPlatformVipr.CoreUI
{
   public class BasePage
    {
        private IWebDriver _driver;

        public BasePage(IWebDriver driver)
        {
            _driver = driver;
        }

        public TPage GetPage<TPage>(IWebDriver driver) where TPage : new()
        {
            if (_driver == null)
            {
                _driver = driver;
            }
            var pageInstance = new TPage();
            PageFactory.InitElements(driver, pageInstance);
            return pageInstance;
        }

        public void Is<TPage>() where TPage : BasePage, new()
        {
            if (!(this is TPage))
            {
                throw new AssertionException(string.Format("Page Type Mismatch: Current page is not a '{0}'", typeof(TPage).Name));
            }
        }

        public TPage As<TPage>() where TPage : BasePage, new()
        {

            return (TPage)this;
        }

        public string Title => _driver?.Title;

        public static string BaseUrl { get; set; }

        public static void NavigateToBase()
        {
            WebDriverSupport.SupportDriver().Navigate().GoToUrl(BaseUrl);
        }
        public static void NavigateToUrl(string url)
        {
           // Log.Info($"Navigating to url: {url}");
            WebDriverSupport.SupportDriver().Navigate().GoToUrl(url);
        }
        public string GetPageSource()
        {
            return WebDriverSupport.SupportDriver().PageSource;
        }

    }
}
