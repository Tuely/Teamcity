using AutomationPlatformVipr.CoreUI;
using AutomationPlatformVipr.Extensions;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoverholderPortal.Pages
{
   public  class CommonPage
    {
        protected WebDriverSupport _driverSupport = new WebDriverSupport();
        #region CommonPage Elements
        [FindsBy(How = How.XPath, Using = "//button[.//span[contains(@class,'caret')]]")]
        private IWebElement ActionsButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Edit')]")]
        private IWebElement ActionselectOption { get; set; }

        #endregion

        #region common page actions
        public void Edit()
        {
            ActionsButton.ClickElement();
            ActionselectOption.ClickElement();
        }
        #endregion
    }
}
