using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace AutomationPlatformVipr.Reports
{
    public class Reporting
    {
        public static ExtentReports InitializeReport()
        {
            string LocalDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\Reports";

            if (!Directory.Exists(LocalDirectory)) Directory.CreateDirectory(LocalDirectory);
            string datestamp = DateTime.Now.ToString("dd-MM-yyyy HH-mm");
            string reportPath = LocalDirectory + "\\Portal Automation Test Report " + datestamp + "\\testing.html";
            var htmlReporter = new ExtentHtmlReporter(reportPath);
            htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;
            htmlReporter.Config.ReportName = "CoverholderPortal Test Execution Report";
            htmlReporter.Config.DocumentTitle = "Regression Result for Coverholder Portal";
            ExtentReports extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
            return extent;
        }

        public static void TearDownReport(ExtentReports extent)
        {
            extent.Flush();
        }
    }
}
