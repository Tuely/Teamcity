
using AutomationPlatformVipr.CoreUI;
using AutomationPlatformVipr.ExtensionMethods;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;
namespace AutomationPlatformVipr.Extensions
{
    public static class WebElementExtension
    {
        public static bool WaitUntilDisplayed(this IWebElement e, int timeout = 240)
        {
            return WaitHandler(e, timeout, ElementOptions.Displayed);
        }

        public static void EnterText(this IWebElement e, string text, bool clearPopulatedField = true)
        {
            WaitUntilDisplayed(e);
            // Field has text and calling element intends to clear
            if (clearPopulatedField && !e.IsEmpty()) e.Clear();
            e.SendKeys(text);
        }


        private enum ElementOptions
        {
            Displayed,
            NotDisplayed,
            Enabled,
            SelectOptionDisplayed
        }

        //public static bool WaitUntilElementDisplayed(IWebElement element, int timeout = 120)
        //{
        //    var driver = WebDriverSupport.SupportDriver();
        //    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
        //    Watch = new Stopwatch();
        //    Watch.Start();
        //    var elementDisplayed = false;
        //    while (Watch.Elapsed.TotalMilliseconds <= timeout * 1000 && !elementDisplayed)
        //    {
        //        try
        //        {
        //            if (element.Displayed)
        //            {
        //                elementDisplayed = true;
        //            }
        //        }
        //        catch
        //        {
        //            //Ignored
        //        }
        //    }

        //    driver.Manage().Timeouts().ImplicitWait = AppConfigManager.ImplictWaitPeriod();
        //    return elementDisplayed;
        //}



        public static bool WaitUntilNotDisplayed(this IWebElement e, int timeout = 10)
        {
            return e == null || WaitHandler(e, timeout, ElementOptions.NotDisplayed);
        }

        public static bool WaitUntilEnabled(this IWebElement e, int timeout = 60)
        {
            return WaitHandler(e, timeout, ElementOptions.Enabled);
        }

        public static bool WaitUntilOptionDisplayed(this IWebElement e, string optionText, int timeout = 10)
        {
            return WaitHandler(e, timeout, ElementOptions.SelectOptionDisplayed, optionText); ;
        }



        private static bool WaitHandler(IWebElement e, int timeout, ElementOptions option, string text = "")
        {
            var watch = new Stopwatch();
            var driver = WebDriverSupport.SupportDriver();
            var result = false;
            watch.Start();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
            while (watch.Elapsed.TotalMilliseconds <= timeout.ToMilliseconds() && !result)
            {
                try
                {
                    switch (option)
                    {
                        case ElementOptions.Displayed:
                            if (e.Displayed)
                            {
                                result = true;
                            }

                            break;
                        case ElementOptions.NotDisplayed:
                            if (e == null || !e.Displayed)
                            {
                                result = true;
                            }

                            break;
                        case ElementOptions.Enabled:
                            if (e.Enabled)
                            {
                                result = true;
                            }

                            break;
                        case ElementOptions.SelectOptionDisplayed:
                            if (e.FindElements(By.TagName("option")).Count(x => x.Text.Contains(text)) > 0)
                            {
                                result = true;
                            }

                            break;
                        default:
                            throw new ArgumentOutOfRangeException(nameof(option), option, null);
                    }

                }
                catch (NoSuchElementException)
                {
                    if (option == ElementOptions.NotDisplayed) result = true;
                }
                catch (StaleElementReferenceException)
                {
                    if (option == ElementOptions.NotDisplayed) result = true;
                }
                catch
                {
                    //Ignored
                }
            }

           // if (watch.Elapsed.Seconds > 1) Log.Info($"Waited for {watch.Elapsed.Seconds} seconds for the element state {option}");

            return result;
        }

        public static void ClickElement(this IWebElement e)
        {
            try
            {
                WaitUntilDisplayed(e);
                e.Click();
            }
            catch (TargetInvocationException)
            {
                //TODO make this more realistic for chrome.
                IJavaScriptExecutor executor = (IJavaScriptExecutor)WebDriverSupport.SupportDriver();
                executor.ExecuteScript("arguments[0].click();", e);
            }
            catch (ElementClickInterceptedException)
            {
                //TODO make this more realistic for chrome.
                IJavaScriptExecutor executor = (IJavaScriptExecutor)WebDriverSupport.SupportDriver();
                executor.ExecuteScript("arguments[0].click();", e);
            }
            catch(ElementNotInteractableException)
            {
                IJavaScriptExecutor executor = (IJavaScriptExecutor)WebDriverSupport.SupportDriver();
                executor.ExecuteScript("arguments[0].click();", e);
            }
        }

        public static void SelectElementByText(this IWebElement e, string text)
        {
            e.WaitUntilDisplayed();
            e.WaitUntilOptionDisplayed(text);
            var select = new SelectElement(e);
            select.SelectByText(text);
        }

        public static void SelectElementByIndex(this IWebElement e)
        {
            var select = new SelectElement(e);
            select.SelectByIndex(1);
        }
        public static void SelectElementByValue(this IWebElement element, string value)
        {
            element.WaitUntilOptionDisplayed(value);
            var select = new SelectElement(element);
            select.SelectByValue(value);
        }

        public static string WaitForText(this IWebElement e, string expectedText, int timeout = 10)
        {
            var watch = new Stopwatch();
            var driver = WebDriverSupport.SupportDriver();
            var textContains = false;
            watch.Start();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
            while (!textContains && watch.Elapsed.TotalMilliseconds <= timeout.ToMilliseconds())
            {
                try
                {
                    if (e.Text.Contains(expectedText))
                    {
                        return e.Text;
                    }
                }
                catch
                {

                }
            }

            return null;
        }


        public static void WaitForElement(this IWebElement e, IWebDriver driver)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));

            bool WaitForElement(IWebDriver web) => e.Displayed;

            wait.Until(WaitForElement);
        }

        public static string SelectedText(this IWebElement e)
        {
            SelectElement selectedValue = new SelectElement(e);
            return selectedValue.SelectedOption.Text;
        }

        public static bool VerifyElementReadonly(this IWebElement e)
        {
            return e.GetAttribute("readonly").Contains("readonly");
        }
        public static void WaitUntilClickable(this IWebElement e)
        {
            var driver = WebDriverSupport.SupportDriver();
            var isClickableWait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));

            isClickableWait.Until(ExpectedConditions.ElementToBeClickable(e));

            e.Click();
        }

        public static bool IsEmpty(this IWebElement e)
        {
            return e.GetAttribute("value").Length == 0;
        }

        public static By GetByFromElement(this IWebElement e)
        {
            By by = null;
            string[] pathVariables = (e.ToString().Split('>')[1].Replace("(?s)(.*)\\]", "$1" + "")).Split(':');
            string selector = pathVariables[0].Trim();
            string value = pathVariables[1].Trim();

            switch (selector)
            {
                case "Id":
                    by = By.Id(value);
                    break;
                case "ClassName":
                    by = By.ClassName(value);
                    break;
                case "TagName":
                    by = By.TagName(value);
                    break;
                case "XPath":
                    by = By.XPath(value);
                    break;
                case "CssSelector":
                    by = By.CssSelector(value);
                    break;
                case "LinkText":
                    by = By.LinkText(value);
                    break;
                case "Name":
                    by = By.Name(value);
                    break;
                case "PartialLinkText":
                    by = By.PartialLinkText(value);
                    break;
                default:
                    throw new Exception("Locator : " + selector + " not found!");
            }
            return by;
        }



    }
}
