using AutomationPlatformVipr.Common;
using AutomationPlatformVipr.CoreUI;
using AutomationPlatformVipr.Reports;
using AutomationPlatformVipr.ValueRetrivers;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using BoDi;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using TechTalk.SpecFlow.Assist.ValueRetrievers;

namespace CoverholderPortal
{
    [Binding]
    public sealed class GlobalHook : IDisposable
    {
        [ThreadStatic] private static IWebDriver _currentDriver;

        private readonly IObjectContainer _objectContainer;
        private static ExtentTest featureName;
        private static ExtentTest scenario;
        private static ExtentReports extent;
        private readonly AppConfigManager _appConfigManager;
        private static ExtentKlovReporter klov;
        private readonly ScenarioContext _scenarioContext;
        private readonly FeatureContext _featureContext;

        //public GlobalHook(IObjectContainer objectContainer, ScenarioContext scenarioContext)
        //{
        //    _objectContainer = objectContainer;
        //    this.scenarioContext = scenarioContext;
        //}
        public GlobalHook(IObjectContainer objectContainer,
           ScenarioContext scenarioContext,
                     AppConfigManager appConfigManager,
           FeatureContext featureContext)
        {
            _objectContainer = objectContainer;
            _scenarioContext = scenarioContext;
            _appConfigManager = appConfigManager;
            _featureContext = featureContext;
        }
        [BeforeScenario]
        public void BeforeScenario()
        {

           // _currentDriver = WebDriverSupport.LaunchDriver();
            _currentDriver = WebDriverSupport.LaunchDriver($"{AppConfigManager.Browser()}");
            _objectContainer.RegisterInstanceAs<IWebDriver>(_currentDriver);

        }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            CoreUtilities.ExecuteCommand("taskkill /im chromedriver.exe /f");
            Service.Instance.RegisterValueRetriever(new DateTimeParsingValueRetriever());
            Service.Instance.UnregisterValueRetriever(Service.Instance.ValueRetrievers.Single(x => x.GetType() == typeof(DateTimeValueRetriever)));

            if (AppConfigManager.Reporting())
            {
                extent = Reporting.InitializeReport();

            }
        }
        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContext)
        {
            if (AppConfigManager.Reporting())
            {
                featureName = extent.CreateTest<Feature>(featureContext.FeatureInfo.Title);
            }
        }

        [BeforeScenario]
        public void Scenario()
        {
            if (AppConfigManager.Reporting())
            {
                scenario = featureName.CreateNode<Scenario>(_scenarioContext.ScenarioInfo.Title);
            }
        }

        [AfterStep]
        public void InsertReportingSteps()
        {
            if (AppConfigManager.Reporting())
            {
                var stepType = ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString();

                if (_scenarioContext.TestError == null)
                {
                    if (stepType == "Given")
                        scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text);
                    else if (stepType == "When")
                        scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text);
                    else if (stepType == "Then")
                        scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text);
                    else if (stepType == "And")
                        scenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text);
                }

                else if (_scenarioContext.TestError != null)
                {
                    if (stepType == "Given")
                        scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Fail(_scenarioContext.TestError.Message);
                    else if (stepType == "When")
                        scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Fail(_scenarioContext.TestError.Message);
                    else if (stepType == "Then")
                        scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Fail(_scenarioContext.TestError.Message);
                    else if (stepType == "And")
                        scenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text).Fail(_scenarioContext.TestError.Message);
                }
            }
        }

        public void Dispose()
        {
            if (AppConfigManager.Reporting())
            {
                Reporting.TearDownReport(extent);
            }
            _currentDriver.Close();
            _currentDriver?.Dispose();
            _currentDriver.Quit();

        }


    }
}
