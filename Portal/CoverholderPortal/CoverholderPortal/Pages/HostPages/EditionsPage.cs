using AutomationPlatformVipr.CoreUI;
using AutomationPlatformVipr.Extensions;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoverholderPortal.Pages.HostPages
{
    public class EditionsPage
    {
        protected WebDriverSupport _driverSupport = new WebDriverSupport();
        #region EditionsPage Elements
        [FindsBy(How = How.XPath, Using = "//a[.//span[contains(text(),'Editions')]]")]
        private IWebElement EditionsLink { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Features')]")]
        private IWebElement FeaturesTab { get; set; }
        #endregion

        #region EditionsPage Actions
        public void ClickEditionsLink()
        {
            EditionsLink.ClickElement();
        }

        public void SelectEditOtion()
        {
            FeaturesTab.ClickElement();
        }

        public void EditFeatures()
        {
            ClickEditionsLink();
        }


        #endregion
    }
}
