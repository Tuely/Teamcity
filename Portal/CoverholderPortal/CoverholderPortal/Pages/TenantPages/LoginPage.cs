using AutomationPlatformVipr.CoreUI;
using AutomationPlatformVipr.Extensions;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoverholderPortal.Pages
{
    public class LoginPage
    {
        protected WebDriverSupport _driverSupport = new WebDriverSupport();

        #region Login Page Elements

        [FindsBy(How = How.Name, Using = "usernameOrEmailAddress")]
        private IWebElement UserName { get; set; }

        [FindsBy(How = How.Name, Using = "password")]
        private IWebElement Password { get; set; }

        [FindsBy(How = How.Id, Using = "kt_login_signin_submit")]
        private IWebElement LoginButton { get; set; }

        [FindsBy(How = How.Id, Using = "details-button")]
        private IWebElement AdvanceButton { get; set; }

        [FindsBy(How = How.Id, Using = "proceed-link")]
        private IWebElement ProceedLink { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'admin')]")]
        private IWebElement LoginUser { get; set; }

        #endregion


        #region Login Page Actions
        private void EnterUsername(string data)
        {
            UserName.WaitUntilDisplayed(2);
            UserName.EnterText(data);

        }
        private void EnterPassword(string data)
        {
            Password.EnterText(data);

        }
        private void ClickLoginButton()
        {
            LoginButton.ClickElement();
        }
        private void ClickAdvanceButton()
        {
            AdvanceButton.ClickElement();
        }
        private void ClickProceed()
        {
            ProceedLink.ClickElement();
        }
        public bool VerifyLoginButton()
        {
            return LoginButton.WaitUntilDisplayed();
        }

        public bool WaitForDetailsToDisplay(string details)
        {
            return _driverSupport.FindNewElement(By.XPath($"//h3[contains(text(), '{details}')]")).WaitUntilDisplayed(2);
        }
        public void Authenticate()
        {
            ClickAdvanceButton();
            ClickProceed();
        }
        public void LoginDetails(string userName, string password)
        {
            EnterUsername(userName);
            EnterPassword(password);
            ClickLoginButton();
        }
        public void Login(string userName, string password)
        {
            Authenticate();
            LoginDetails(userName, password);
        }

        public void HostLogin(string userName, string password)
        {
            LoginDetails(userName, password);
        }
        public bool VerifyLoginUser()
        {
            return LoginUser.WaitUntilDisplayed();
        }
        #endregion
    }
}
