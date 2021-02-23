using AutomationPlatformVipr.CoreUI;
using AutomationPlatformVipr.Extensions;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoverholderPortal.Pages.HostPages
{
    public class HostHomePage
    {
        protected WebDriverSupport _driverSupport = new WebDriverSupport();
        #region HostHomePage Elements
        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'Tenants')]")]
        private IWebElement TenantsMenu { get; set; }
        #endregion
        #region HostHomePage actions

        public void ClickTenantsMenu()
        {
            TenantsMenu.ClickElement();
        }
        #endregion

    }
}
