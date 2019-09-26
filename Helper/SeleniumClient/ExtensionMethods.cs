using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumClient
{
    public static class ExtensionMethods
    {
        public static IWebElement FindElement(this IWebDriver webDriver, Func<IWebDriver, IWebElement> expectedCondition, TimeSpan timeout)
        {
            var wait = new WebDriverWait(webDriver, timeout);
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(StaleElementReferenceException));
            wait.PollingInterval = TimeSpan.FromMilliseconds(500);
            return wait.Until(expectedCondition);
        }
    }
}
