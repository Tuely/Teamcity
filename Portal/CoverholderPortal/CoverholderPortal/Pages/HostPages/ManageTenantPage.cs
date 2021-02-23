using AutomationPlatformVipr.CoreUI;
using AutomationPlatformVipr.Extensions;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoverholderPortal.Pages.HostPages
{
    public class ManageTenantPage
    {
        protected WebDriverSupport _driverSupport = new WebDriverSupport();

        #region ManageTenantPage Elements
        [FindsBy(How = How.Id, Using = "CreateNewTenantButton")]
        private IWebElement CreateNewTenantButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='TenancyName']")]
        private IWebElement EnterTenancyNameText { get; set; }
        [FindsBy(How = How.XPath, Using = "//input[@id='Name']")]
        private IWebElement EnterTenancyName1Text { get; set; }
        [FindsBy(How = How.XPath, Using = "//input[@id='AdminEmailAddress']")]
        private IWebElement EnterEmailText { get; set; }

        [FindsBy(How = How.Id, Using = "CreateTenant_UseHostDb")]
        private IWebElement SelectHostDBCheckBox { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'Save')]")]
        private IWebElement SaveTenancyButton { get; set; }
        [FindsBy(How = How.Id, Using = "PortalAppSettings_Intrali_ApiUrl")]
       
        [FindsBy(How = How.Id, Using = "TenantsTableFilter")]
        private IWebElement TenancyNameText { get; set; }
        [FindsBy(How = How.Id, Using = "GetTenantsButton")]
        private IWebElement SearchTenancyButton { get; set; }
        [FindsBy(How = How.XPath, Using = "//td[contains(text(),'TestTenant')]")]
        private IWebElement TenantSearchResult { get; set; }

      
        #endregion

        #region ManageTenantPage Actions
        public void ClickCreateNewTenantButton()
        {
            CreateNewTenantButton.ClickElement();
        }

        private void EnterTenancyname(string data)
        {
            EnterTenancyNameText.EnterText(data + DateTime.Now.ToString("yyyyMMddHHmmssfff"));
            EnterTenancyName1Text.EnterText(data+ DateTime.Now.ToString("yyyyMMddHHmmssfff"));
        }

        public void EnterEmail(string email)
        {
            EnterEmailText.EnterText(email);
        }

        public void SaveTenancyDetails()
        {
            SaveTenancyButton.WaitUntilDisplayed(2);
            SaveTenancyButton.ClickElement();
        }
        public void TenacyDetails(string name, string email)
        {
            EnterTenancyname(name);
            EnterEmail(email);
           // SelectHostDBCheckBox.ClickElement();
            SaveTenancyDetails();
        }

        public void EnterTenancyNameSearch(string name)
        {
            TenancyNameText.EnterText(name + DateTime.Now.ToString("yyyyMMddHHmm"));
        }
        public void SearchTenant(string name)
        {
            EnterTenancyNameSearch(name);
            SearchTenancyButton.ClickElement();
        }
        public bool VerifyTenantSearchResult()
        {
            return TenantSearchResult.WaitUntilDisplayed();
        }

        public void EditTenantDetails(string name)
        {
            EnterTenancyName1Text.EnterText(name + DateTime.Now.ToString("yyyyMMddHHmmssfff"));
            SaveTenancyDetails();
        }
        #endregion
    }
}
