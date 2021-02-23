using CoverholderPortal.Pages;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace CoverholderPortal.Scenarios.Host
{
    [Binding]
    public class FeatureSwitchSteps
    {
        private PageObjectFactory _page;
        public FeatureSwitchSteps(PageObjectFactory page)
        {
            _page = page;
        }
        #region When Steps
        [When(@"I edit an application edition")]
        public void WhenIEditAnApplicationEdition()
        {
            _page.EditionsPage().EditFeatures();
            _page.CommonPage().Edit();
            _page.EditionsPage().SelectEditOtion();
        }
     
        [When(@"I disable the Administration feature for '(.*)'")]
        public void WhenIDisableTheAdministrationFeatureFor(string adminFeature)
        {
            _page.FeaturesPage().DisableAdministrationFeature();
        }
        [When(@"I enable Release Note feature")]
        public void WhenIEnableReleaseNoteFeature()
        {
            _page.FeaturesPage().EnableReleaseNoteFeature();
        }
        [When(@"I disable Release Note feature")]
        public void WhenIDisableReleaseNoteFeature()
        {
            _page.FeaturesPage().DisableReleaseNoteFeature();
        }

        [When(@"I enable setup feature")]
        public void WhenIEnableSetupFeature()
        {
            _page.FeaturesPage().EnableSetupFeature();
        }
        [When(@"I disable setup feature")]
        public void WhenIDisableSetupFeature()
        {
            _page.FeaturesPage().DisableSetupFeature();
        }


        #endregion


        #region Then steps
        [Then(@"I can enable or disable features for tenant")]
        public void ThenICanEnableOrDisableFeaturesForTenant()
        {
            _page.FeaturesPage().DisableAdministrationFeature();
        }

        [Then(@"I verify Release Note features are showing for the user")]
        public void ThenIVerifyReleaseNoteFeaturesAreShowingForTheUser()
        {
            Assert.IsTrue(_page.HomePage().VerifyReleaseNoteTabDisplay());
        }
        [Then(@"I verify Release Note features are not showing for the user")]
        public void ThenIVerifyReleaseNoteFeaturesAreNotShowingForTheUser()
        {
            Assert.IsTrue(_page.HomePage().VerifyReleaseNoteTabNotDisplay());
        }
        [Then(@"I verify Setup features are showing for the user")]
        public void ThenIVerifySetupFeaturesAreShowingForTheUser()
        {
            Assert.IsTrue(_page.HomePage().VerifySetupTabDisplay());
        }
        [Then(@"I verify Setup features are not showing for the user")]
        public void ThenIVerifySetupFeaturesAreNotShowingForTheUser()
        {
            Assert.IsTrue(_page.HomePage().VerifySetupTabNotDisplay());
        }


        #endregion
    }
}
