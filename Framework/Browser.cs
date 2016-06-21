using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Core;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;

namespace demo.framework
{

    public class Browser : BaseEntity
    {
        protected static Browser _browser;
        private static IWebDriver _driver;
       
        public static Browser GetInstance()
        {
           _driver = BrowserFactory.SetupBrowser();
            return new Browser();

        }

        public static IWebDriver GetDriver()
        {
            return _driver;
        }

        public static void WaitForPageToLoad()
        {
            var wait = new WebDriverWait(GetDriver(), TimeSpan.FromMilliseconds(Convert.ToDouble(Configuration.GetTimeout())));
            try
            {
                wait.Until<Boolean>(waiting =>
                {
                    try
                    {
                        var result = ((IJavaScriptExecutor)Browser.GetDriver()).ExecuteScript("return document['readyState'] ? 'complete' == document.readyState : true");
                        return result != null && result is Boolean && (Boolean)result;
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                });
            }
            catch (Exception e)
            {
            }
        }

        public static void WaitForElementNotVisible(By locator)
        {

            try
            {
                var wait = new OpenQA.Selenium.Support.UI.WebDriverWait(Browser.GetDriver(), TimeSpan.FromMilliseconds(Convert.ToDouble(Configuration.GetTimeout())));
                wait.Until(driver1 => !visibility(locator));
            }
            catch (WebDriverTimeoutException)
            {
            }
        }

         static bool visibility(By locator)
        {
            bool flag;
            try
            {
                flag = Browser.GetDriver().FindElement(locator).Displayed;
            }
            catch (NoSuchElementException)
            {
                flag = false;
            }
            return flag;
        }

        public static ReadOnlyCollection<IWebElement> getWhenVisible(By locator)
        {

           ReadOnlyCollection<IWebElement> elements = null;

            WebDriverWait wait = new WebDriverWait(Browser.GetDriver(), TimeSpan.FromMilliseconds(Convert.ToDouble(Configuration.GetTimeout())));

            elements = wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(locator));

            return elements;

        }

    }

    
    }
