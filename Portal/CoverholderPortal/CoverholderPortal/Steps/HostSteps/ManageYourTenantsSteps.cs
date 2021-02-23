using CoverholderPortal.Pages;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace CoverholderPortal.Scenarios.Tenant
{
    [Binding]
    public class ManageYourTenantsSteps
    {
        private PageObjectFactory _page;
        public ManageYourTenantsSteps(PageObjectFactory page)
        {
            _page = page;
        }

        #region when steps
        [When(@"I create a new tenant '(.*)' and '(.*)'")]
        public void WhenICreateANewTenantAnd(string name, string email)
        {
            _page.HostHomePage().ClickTenantsMenu();
            _page.ManageTenantPage().ClickCreateNewTenantButton();
            _page.ManageTenantPage().TenacyDetails(name, email);
        }
        [When(@"I enter the API url and authentication details as '(.*)' '(.*)' '(.*)'")]
        public void WhenIEnterTheAPIUrlAndAuthenticationDetailsAs(string apiUrl, string apiAuthUrl, string authCode)
        {
            _page.ApiDetailsPage().ApiDetails(apiUrl, apiAuthUrl, authCode);
        }

        [When(@"I search for tenant details '(.*)'")]
        public void WhenISearchForTenantDetails(string name)
        {
            _page.HostHomePage().ClickTenantsMenu();
            _page.ManageTenantPage().SearchTenant(name);
        }

        [When(@"I edit tenant details '(.*)'")]
        public void WhenIEditTenantDetails(string name)
        {
            _page.CommonPage().Edit();
            _page.ManageTenantPage().EditTenantDetails(name);
        }


        #endregion
        #region Then steps
        [Then(@"I verify the tenant has created '(.*)'")]
        public void ThenIVerifyTheTenantHasCreated(string name)
        {
            _page.HostHomePage().ClickTenantsMenu();
            _page.ManageTenantPage().SearchTenant(name);
            Assert.IsTrue(_page.ManageTenantPage().VerifyTenantSearchResult());
        }
        #endregion
    }
}
