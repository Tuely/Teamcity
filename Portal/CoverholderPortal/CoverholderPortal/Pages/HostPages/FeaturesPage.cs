using AutomationPlatformVipr.CoreUI;
using AutomationPlatformVipr.Extensions;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoverholderPortal.Pages.HostPages
{
   public class FeaturesPage
    {
        protected WebDriverSupport _driverSupport = new WebDriverSupport();
        #region FeaturesPage Elements
        [FindsBy(How = How.Id, Using = "App.Administration_anchor")]
        private IWebElement AdministrationFeatureCheckBox { get; set; }

        [FindsBy(How = How.Id, Using = "App.ReleaseNotes_anchor")]
        private IWebElement ReleaseNoteFeatureCheckBox { get; set; }
        [FindsBy(How = How.Id, Using = "App.Setup_anchor")]
        private IWebElement SetupFeatureCheckBox { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'Save')]")]
        
        private IWebElement SaveButton { get; set; }

        #endregion

        #region FeaturesPage Actions
        public void DisableAdministrationFeature()
        {
            if (AdministrationFeatureCheckBox.GetAttribute("Class").Contains("jstree-clicked"))
            {
                AdministrationFeatureCheckBox.ClickElement();
                Assert.True(AdministrationFeatureCheckBox.WaitUntilDisplayed(2), $"Option {AdministrationFeatureCheckBox} is able to select in the UI");
            }
            ClickSaveButton();
        }
        public void EnableReleaseNoteFeature()
        {
            if (!ReleaseNoteFeatureCheckBox.GetAttribute("Class").Contains("jstree-clicked"))
            {
                ReleaseNoteFeatureCheckBox.ClickElement();
                Assert.True(ReleaseNoteFeatureCheckBox.WaitUntilDisplayed(2), $"Option {ReleaseNoteFeatureCheckBox} is enabled");
            }
            ClickSaveButton();
        }
        public void DisableReleaseNoteFeature()
        {
            if (ReleaseNoteFeatureCheckBox.GetAttribute("Class").Contains("jstree-clicked"))
            {
                ReleaseNoteFeatureCheckBox.ClickElement();
                Assert.True(ReleaseNoteFeatureCheckBox.WaitUntilDisplayed(2), $"Option {ReleaseNoteFeatureCheckBox} is disabled");
            }
            ClickSaveButton();
        }

        public void EnableSetupFeature()
        {
            if (!SetupFeatureCheckBox.GetAttribute("Class").Contains("jstree-clicked"))
            {
                SetupFeatureCheckBox.ClickElement();
                Assert.True(SetupFeatureCheckBox.WaitUntilDisplayed(2), $"Option {SetupFeatureCheckBox} is enabled");
            }
            ClickSaveButton();
        }

        public void DisableSetupFeature()
        {
            if (SetupFeatureCheckBox.GetAttribute("Class").Contains("jstree-clicked"))
            {
                SetupFeatureCheckBox.ClickElement();
                Assert.True(SetupFeatureCheckBox.WaitUntilDisplayed(2), $"Option {SetupFeatureCheckBox} is disabled");
            }
            ClickSaveButton();
        }
        public void ClickSaveButton()
        { SaveButton.ClickElement(); }
        #endregion
    }
}
