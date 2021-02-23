using CoverholderPortal.Pages;
using System;
using TechTalk.SpecFlow;

namespace CoverholderPortal.Steps.Tenant
{
    [Binding]
    public class SystemSettingsSteps
    {
        private PageObjectFactory _page;
        public SystemSettingsSteps(PageObjectFactory page)
        {
            _page = page;
        }
        [Given(@"I navigate into system settings page")]
        public void GivenINavigateIntoSystemSettingsPage()
        {
            _page.HomePage().ClickSystemSettingsLink();
        }
        
        [When(@"I edit Api details api url as '(.*)'")]
        public void WhenIEditApiDetailsApiUrlAs(string apiUrl)
        {
            _page.SystemSettingsPage().ClickEditApiButton();
            _page.ApiDetailsPage().EditApiDetails(apiUrl);
        }
        
        
        [Then(@"I verify the updated Api details '(.*)'")]
        public void ThenIVerifyTheUpdatedApiDetails(string apiUrl)
        {
            _page.HomePage().ClickSystemSettingsLink();
            _page.ApiDetailsPage().VerifyApiDetails(apiUrl);
        }
    }
}
