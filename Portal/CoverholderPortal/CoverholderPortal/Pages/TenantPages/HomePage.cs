using AutomationPlatformVipr.CoreUI;
using AutomationPlatformVipr.Extensions;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoverholderPortal.Pages
{
    public class HomePage
    {
        protected WebDriverSupport _driverSupport = new WebDriverSupport();
        #region Home Page Elements
        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Logout')]")]
        private IWebElement LogoutLink { get; set; }

        [FindsBy(How = How.Id, Using = "kt_quick_user_toggle")]
        private IWebElement UserNameLink { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'Release Notes')]")]
        private IWebElement ReleaseNoteLink { get; set; }
        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'Setup')]")]
        private IWebElement SetupLink { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'System Settings')]")]
        private IWebElement SystemSettingsLink { get; set; }

        #region Administration
        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'Administration')]")]
        private IWebElement AdministrationLink { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'Users')]")]
        private IWebElement UsersLink { get; set; }
        #endregion

        #endregion
        #region Home Page actions
        public void ClickLogoutLink()
        {
            UserNameLink.ClickElement();
            LogoutLink.ClickElement();
        }
        public bool VerifyReleaseNoteTabDisplay()
        {
            return ReleaseNoteLink.WaitUntilDisplayed();
        }
        public bool VerifyReleaseNoteTabNotDisplay()
        {
            return ReleaseNoteLink.WaitUntilNotDisplayed();
        }

        public bool VerifySetupTabDisplay()
        {
            return SetupLink.WaitUntilDisplayed();
        }
        public bool VerifySetupTabNotDisplay()
        {
            return SetupLink.WaitUntilNotDisplayed();
        }

        public void ClickSystemSettingsLink()
        {
            SetupLink.ClickElement();
            SystemSettingsLink.ClickElement();
        }

        public void ClickAdministrationLink()
        {
            AdministrationLink.ClickElement();
        }

        public void ClickUserLink()
        {
            AdministrationLink.ClickElement();
            UsersLink.ClickElement();
        }

        #endregion
    }
}
