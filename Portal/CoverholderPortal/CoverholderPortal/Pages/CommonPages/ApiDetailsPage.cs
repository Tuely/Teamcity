using AutomationPlatformVipr.CoreUI;
using AutomationPlatformVipr.Extensions;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoverholderPortal.Pages.CommonPages
{
   public class ApiDetailsPage
    {
        protected WebDriverSupport _driverSupport = new WebDriverSupport();
        #region ApiDetailsPage Elements
        [FindsBy(How = How.Id, Using = "PortalAppSettings_Intrali_ApiUrl")]
        private IWebElement ApiUrlText { get; set; }
        [FindsBy(How = How.Id, Using = "PortalAppSettings_Intrali_ApiAuthorizationUrl")]
        private IWebElement ApiAuthUrlText { get; set; }
        [FindsBy(How = How.Id, Using = "PortalAppSettings_Intrali_ApiSecret")]
        private IWebElement AuthCodeText { get; set; }
        [FindsBy(How = How.Id, Using = "btnSave")]
        private IWebElement ApiSaveButton { get; set; }


        #endregion

        #region page Actions
        public void EnterAPIUrl(string apiUrl)
        {
            ApiUrlText.EnterText(apiUrl);
        }
        public void EnterApiAuthUrlText(string apiAuthUrl)
        {
            ApiAuthUrlText.EnterText(apiAuthUrl);
        }

        public void EnterAuthCodeText(string authCode)
        {
            AuthCodeText.EnterText(authCode);
        }
        public void ApiDetails(string apiUrl, string apiAuthUrl, string authCode)
        {
            EnterAPIUrl(apiUrl);
            EnterApiAuthUrlText(apiAuthUrl);
            EnterAuthCodeText(authCode);
            ApiSaveButton.ClickElement();
        }

        public void EditApiDetails(string apiUrl)
        {
            EnterAPIUrl(apiUrl);
            ApiSaveButton.ClickElement();
        }

        public void VerifyApiDetails(string apiUrl)
        {
            if (ApiUrlText.GetAttribute("value").Contains(apiUrl))
            {
                Assert.True(ApiUrlText.WaitUntilDisplayed(5), $"Api Url Value contains {apiUrl} ");
            }
        }
        #endregion
    }
}
