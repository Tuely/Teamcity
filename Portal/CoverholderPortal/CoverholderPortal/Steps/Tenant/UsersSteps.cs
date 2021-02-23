using CoverholderPortal.Pages;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace CoverholderPortal.Steps.Tenant
{
    [Binding]
    public class UsersSteps
    {
        private PageObjectFactory _page;
        public UsersSteps(PageObjectFactory page)
        {
            _page = page;
        }
        [Given(@"I navigate into users page")]
        public void GivenINavigateIntoUsersPage()
        {
            _page.HomePage().ClickUserLink();
        }

        [When(@"I create a new user with details '(.*)' '(.*)' '(.*)'")]
        public void WhenICreateANewUserWithDetails(string name, string email, string password)
        {
            _page.UserPage().CreateNewUser(name, email, password);
        }
        [When(@"I search for the user details '(.*)'")]
        public void WhenISearchForTheUserDetails(string name)
        {
            _page.UserPage().SearchUser(name);
        }

        [When(@"I edit the user details as '(.*)'")]
        public void WhenIEditTheUserDetailsAs(string name)
        {
            _page.CommonPage().Edit();
            _page.UserPage().EditUser(name);
        }


        [Then(@"I verify the user is created '(.*)'")]
        public void ThenIVerifyTheUserIsCreated(string name)
        {
            _page.HomePage().ClickUserLink();
            _page.UserPage().SearchUser(name);
            Assert.IsTrue(_page.UserPage().VerifyUserSearchResult());
        }

    }
}
