using AutomationPlatformVipr.CoreUI;
using CoverholderPortal.Pages;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace CoverholderPortal.Scenarios
{

    [Binding]
    public class AccountTestSteps
    {
        private PageObjectFactory _page;
        public AccountTestSteps(PageObjectFactory page)
        {
            _page = page;
        }
        #region Given Steps

        [Given(@"I am logged into Coverholder Portal")]
        [When(@"I am logged into Coverholder Portal")]
        public void GivenIAmLoggedIntoCoverholderPortal()
        {
            BasePage.NavigateToUrl(AppConfigManager.BaseUrl());
            _page.LoginPage().Login("admin", "Qwerty123");
        }

        [Given(@"I am logged into Coverholder Portal Host")]
        public void GivenIAmLoggedIntoCoverholderPortalHost()
        {
            BasePage.NavigateToUrl(AppConfigManager.HostBaseUrl());
            _page.LoginPage().HostLogin("vipr_administrator", "h0m35dal3!");
        }

        [Given(@"I am on Coverholder Portal Logon Screen")]
        public void GivenIAmOnCoverholderPortalLogonScreen()
        {
            BasePage.NavigateToUrl(AppConfigManager.BaseUrl());
            _page.LoginPage().Authenticate();
        }

       
        #endregion

        #region When Steps
        [When(@"I click the logout link")]
        public void WhenIClickTheLogoutLink()
        {
            _page.HomePage().ClickLogoutLink();
        }
        #endregion


        #region Then Steps
        [Then(@"I verify the user has logged in sucessfully")]
        public void ThenIVerifyTheUserHasLoggedInSucessfully()
        {
            Assert.IsTrue(_page.LoginPage().VerifyLoginUser());
        }

        [Then(@"I verify  the logout has been sucessful")]
        public void ThenIVerifyTheLogoutHasBeenSucessful()
        {
            Assert.IsTrue(_page.LoginPage().VerifyLoginButton());
        }

        [Then(@"I verify the following text/strapline: '(.*)'")]
        public void ThenIVerifyTheFollowingTextStrapline(string strapText)
        {
            Assert.True(_page.LoginPage().WaitForDetailsToDisplay(strapText), $"{strapText} was displayed");
            
        }

        #endregion
    }
}
