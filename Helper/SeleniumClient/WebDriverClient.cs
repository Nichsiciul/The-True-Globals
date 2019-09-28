using UiClient;
using Serilog;
using OpenQA.Selenium;
using System;
using OpenQA.Selenium.Support.UI;
using Util;
using System.Collections.Generic;
using UiHelper.Logging;

namespace SeleniumClient
{
    public class WebDriverClient : BrowserClient<WebLocator>
    {
        private static readonly ILogger LOG = Logger.Instance;

        private IWebDriver WebDriver;

        public WebDriverClient(IWebDriver WebDriver)
        {
            LOG.Debug("Creating WebDriverClient");
            this.WebDriver = WebDriver;
        }

        public IWebDriver GetWebDriver()
        {
            return WebDriver;
        }

        public void Quit()
        {
            LOG.Debug("Closing WebDriver");

            WebDriver.Quit();
        }

        public object Element(object openNavigationButton)
        {
            throw new NotImplementedException();
        }

        public Window Window()
        {
            return new SeleniumWindow(WebDriver);
        }

        public Element<WebLocator> Element(WebLocator locator)
        {
            return new SeleniumElement(locator, WebDriver);
        }

        public void Go(String url)
        {
            LOG.Information("Navigating to URL: " + url);

            WebDriver.Navigate().GoToUrl(url);
        }


        public String GetCurrentUrl()
        {
            String currentUrl = WebDriver.Url;
            LOG.Information("Retrieving current URL: " + currentUrl);
            return currentUrl;
        }


        public void Refresh()
        {
            LOG.Information("Reloading page");

            WebDriver.Navigate().Refresh();
        }


        public Object ExecuteScript(String script, params Object[] parameter)
        {
            if (WebDriver is IJavaScriptExecutor)
            {
                LOG.Information("Executing JavaScript:\n{0}\n\nwith args: {1}", script, parameter);
                return ((IJavaScriptExecutor)WebDriver).ExecuteScript(script, parameter);
            }
            else
            {
                LOG.Warning("Executing scripts isn't supported by the current browser");
                return null;
            }
        }


        public History History()
        {
            return new SeleniumHistory(WebDriver);
        }


        public Prompt Prompt()
        {
            return new SeleniumPrompt(WebDriver);
        }

        [Obsolete]
        public void WaitForElement(WebLocator element)
        {
            var wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(element.By));
        }
        public string GetCurrentWindowHandle()
        {
            return WebDriver.CurrentWindowHandle;
        }
        public List<string> GetWindowHandles()
        {
            return new List<string>(WebDriver.WindowHandles);
        }

        public void SwitchTo(int maxWaitTimeSeconds = 10, int windowIndex = 1)
        {
            if (FuncWaiter.WaitFor(() => WebDriver.WindowHandles.Count > 1, maxWaitTimeSeconds, 500))
                WebDriver.SwitchTo().Window(WebDriver.WindowHandles[windowIndex]);
            else
                throw new TimeoutException("Wait in SwitchTo-method exceeded maximum wait time.");
        }
        public void SwitchTo(string windowHandle)
        {
            WebDriver.SwitchTo().Window(windowHandle);
        }
        public void SwitchToFrame(WebLocator locator)
        {
            WebDriver.SwitchTo().Frame(WebDriver.FindElement(locator.By));
        }
        public void SwitchToDefaultContent()
        {
            WebDriver.SwitchTo().DefaultContent();
        }
        [System.Obsolete("vom alten Client, bessere Lösung finden")]
        public void SwitchToMainFrame()
        {
            WebDriver.SwitchTo().Window(WebDriver.WindowHandles[0]);
        }
    }
}

