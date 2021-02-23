using AutomationPlatformVipr.CoreUI;
using AutomationPlatformVipr.Extensions;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoverholderPortal.Pages.TenantPages
{
    public class SystemSettingsPage
    {
        protected WebDriverSupport _driverSupport = new WebDriverSupport();
        #region SystemSettingsPage Elements
        [FindsBy(How = How.Id, Using = "btnEdit")]
        private IWebElement EditButton { get; set; }
        
        #endregion

        #region SystemSettingsPage Actions
       
        public void ClickEditApiButton()
        {
            EditButton.ClickElement();
        }
        #endregion
    }
}
