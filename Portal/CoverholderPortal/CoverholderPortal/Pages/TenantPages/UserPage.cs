using AutomationPlatformVipr.CoreUI;
using AutomationPlatformVipr.Extensions;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoverholderPortal.Pages.TenantPages
{
    public class UserPage
    {
        protected WebDriverSupport _driverSupport = new WebDriverSupport();
        #region UserPage Elements
        [FindsBy(How = How.Id, Using = "CreateNewUserButton")]
        private IWebElement CreateNewUserButton { get; set; }
        [FindsBy(How = How.Id, Using = "Name")]
        private IWebElement EnterNameText { get; set; }
        [FindsBy(How = How.Id, Using = "Surname")]
        private IWebElement EnterSurNameText { get; set; }
        [FindsBy(How = How.Id, Using = "EmailAddress")]
        private IWebElement EnterEmailText { get; set; }
        [FindsBy(How = How.Id, Using = "UserName")]
        private IWebElement EnterUserNameText { get; set; }
        [FindsBy(How = How.XPath, Using = "//label[@for='EditUser_SetRandomPassword']")]
        private IWebElement SelectPassword { get; set; }
        [FindsBy(How = How.Id, Using = "EditUser_Password")]
        private IWebElement EnterPasswordText { get; set; }
        [FindsBy(How = How.Id, Using = "PasswordRepeat")]
        private IWebElement RepetPasswordText { get; set; }
        [FindsBy(How = How.XPath, Using = "//button[.//span[contains(text(),'Save')]]")]
        private IWebElement SaveButton { get; set; }

        [FindsBy(How = How.Id, Using = "UsersTableFilter")]
        private IWebElement SearchUserText { get; set; }
        [FindsBy(How = How.Id, Using = "GetUsersButton")]
        private IWebElement SearchUserButton { get; set; }
        [FindsBy(How = How.XPath, Using = "//td[contains(text(),'user')]")]
        private IWebElement UserSearchResult { get; set; }
        #endregion

        #region UserPage actions
        public void CreateNewUser(string name, string email, string password)
        {
            CreateNewUserButton.ClickElement();
            EnterNameText.EnterText(name + DateTime.Now.ToString("yyyyMMddHHmmssfff"));
            EnterSurNameText.EnterText(name);
            EnterEmailText.EnterText(email + DateTime.Now.ToString("yyyyMMddHHmmssfff") + "@test.com");
            EnterUserNameText.EnterText(name + DateTime.Now.ToString("yyyyMMddHHmmssfff"));
            SelectPassword.ClickElement();
            EnterPasswordText.EnterText(password);
            RepetPasswordText.EnterText(password);
            SaveButton.ClickElement();
        }

        public void SearchUser(string name)
        {
            SearchUserButton.WaitUntilDisplayed(4);
            SearchUserText.EnterText(name + DateTime.Now.ToString("yyyyMMddHHmm"));
            SearchUserButton.ClickElement();
        }
        public bool VerifyUserSearchResult()
        {
            return UserSearchResult.WaitUntilDisplayed(5);
        }

        public void EditUser(string name)
        {
            EnterNameText.EnterText(name + DateTime.Now.ToString("yyyyMMddHHmmssfff"));
            SaveButton.ClickElement();
        }
        #endregion
    }
}
