using AutomationPlatformVipr.CoreUI;
using CoverholderPortal.Pages.CommonPages;
using CoverholderPortal.Pages.HostPages;
using CoverholderPortal.Pages.TenantPages;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoverholderPortal.Pages
{
    public class PageObjectFactory
    {
        public IWebDriver _driver;
        public BasePage _basePage;
        public PageObjectFactory(IWebDriver driver, BasePage basePage)
        {
            _driver = driver;
            _basePage = basePage;
        }

        public LoginPage LoginPage()
        {
            return _basePage.GetPage<LoginPage>(_driver);
        }

        public HomePage HomePage()
        {
            return _basePage.GetPage<HomePage>(_driver);
        }
        public CommonPage CommonPage()
        {
            return _basePage.GetPage<CommonPage>(_driver);
        }


        #region HostPages

        public HostHomePage HostHomePage()
        {
            return _basePage.GetPage<HostHomePage>(_driver);
        }
        public EditionsPage EditionsPage()
        {
            return _basePage.GetPage<EditionsPage>(_driver);
        }
        public FeaturesPage FeaturesPage()
        {
            return _basePage.GetPage<FeaturesPage>(_driver);
        }
        public ManageTenantPage ManageTenantPage()
        {
            return _basePage.GetPage<ManageTenantPage>(_driver);
        }


        #endregion

        #region Tenant Pages
        public SystemSettingsPage SystemSettingsPage()
        {
            return _basePage.GetPage<SystemSettingsPage>(_driver);
        }
        public UserPage UserPage()
        {
            return _basePage.GetPage<UserPage>(_driver);
        }
        
        #endregion

        #region common pages
        public ApiDetailsPage ApiDetailsPage()
        {
            return _basePage.GetPage<ApiDetailsPage>(_driver);
        }
        
        #endregion
    }
}
