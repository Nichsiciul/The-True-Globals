using UiClient;
using Serilog;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.IO;
using UiHelper.Logging;

namespace SeleniumClient
{
    public class SeleniumElement : Element<WebLocator>
    {
        private static readonly ILogger LOG = Logger.Instance;

        private IWebElement webElement;
        public IWebElement WebElement
        {
            get
            {
                if (this.webElement == null)
                {
                    try
                    {
                        this.webElement = this.WebDriver.FindElement(ExpectedConditions.ElementIsVisible(this.locator.By), TimeSpan.FromSeconds(5));
                    }
                    catch (WebDriverTimeoutException)
                    {
                        this.webElement = new ElementNotFound();
                    }
                }
                return this.webElement;
            }
        }

        public IWebDriver WebDriver { get; }

        private WebLocator locator;

        public SeleniumElement(WebLocator locator, IWebDriver WebDriver)
        {
            this.WebDriver = WebDriver;
            this.locator = locator;
        }

        public SeleniumElement(IWebElement webElement, IWebDriver WebDriver)
        {
            this.WebDriver = WebDriver;
            this.webElement = webElement;
        }

        public bool IsSelected()
        {
            LOG.Information("Retrieving select status for element: {0}", WebElement);
            bool selected = WebElement.Selected;
            LOG.Information("Selected: {0}", selected);

            return selected;
        }


        public string GetAttribute(string attributeName)
        {
            LOG.Information("Retrieving attribute {0} from element: {1}", attributeName, WebElement);
            string attribute = WebElement.GetAttribute(attributeName);
            LOG.Information("{0}: {1}", attributeName, attribute);
            return attribute;
        }


        public string GetText()
        {
            LOG.Information("Retrieving text from element: {0}", WebElement);
            string text = WebElement.Text;
            LOG.Information("Text: {0}", text);
            return text;
        }


        public string GetElementType()
        {
            LOG.Information("Retrieving tag name from element: {0}", WebElement);
            string tagName = WebElement.TagName;
            LOG.Information("Tag name: {0}", tagName);
            return tagName;
        }


        public bool IsEnabled()
        {
            LOG.Information("Retrieving enabled status from element: {0}", WebElement);
            bool enabled = WebElement.Enabled;
            LOG.Information("Enabled: {0}", enabled);
            return enabled;
        }


        public bool IsDisplayed()
        {
            LOG.Information("Retrieving displayed status from element: {0}", WebElement);

            try
            {
                bool displayed = WebElement.Displayed;
                LOG.Information("Displayed: {0}", displayed);
                return displayed;
            }
            catch (NoSuchElementException)
            {
                LOG.Information("Displayed: Couldn't find element");
                return false;
            }
        }


        public void Click()
        {
            LOG.Information("Clicking on element: {0}", WebElement);
            WebElement.Click();
        }

        public void DoubleClick()
        {
            LOG.Information("Double clicking on element: {0}", WebElement);
            var action = new OpenQA.Selenium.Interactions.Actions(WebDriver);
            action.DoubleClick(WebElement).Perform();

        }

        public void RightClick()
        {
            LOG.Information("Right clicking on element: {0}", WebElement);
            var action = new OpenQA.Selenium.Interactions.Actions(WebDriver);
            action.ContextClick(WebElement).Perform();

        }

        public void MouseOver()
        {
            LOG.Information("Mouse over on element: {0}", WebElement);
            var action = new OpenQA.Selenium.Interactions.Actions(WebDriver);
            action.MoveToElement(WebElement).Perform();
        }

        public void Check()
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            LOG.Information("Clearing element: {0}", WebElement);
            WebElement.Clear();
        }


        public void SendKeys(String keys)
        {
            LOG.Information("Sending keys {0} to element: {1}", keys, WebElement);
            WebElement.SendKeys(keys);
        }

        public void SendKeys(IEnumerable<char> key)
        {
            LOG.Information("Sending keys {0} to element: {1}", key, WebElement.ToString());
            WebElement.SendKeys(key.ToString());
        }

        public void SendEnterKey()
        {
            SendKeys(Keys.Enter);
        }


        public Bitmap TakeScreenshot()
        {
            LOG.Information("Taking screenshot");
            return new Bitmap(new MemoryStream(((ITakesScreenshot)WebDriver).GetScreenshot().AsByteArray));
        }


        public void SelectDropdown(String visibleText)
        {
            SelectElement select = new SelectElement(WebElement);
            // TODO more select signatures
            select.SelectByText(visibleText);
        }


        public Element<WebLocator> GetChild(WebLocator locator)
        {
            return new SeleniumElement(WebElement.FindElement(locator.By), WebDriver);
        }

        public void SetText(string text)
        {
            Clear();

            if (text != null)
            {
                SendKeys(text);
            }
        }

        public void ScrollToElement()
        {
            var actions = new Actions(WebDriver);
            actions.MoveToElement(WebElement);
            actions.Perform();
        }
        public bool EnsureVisible()
        {
            throw new NotImplementedException();
        }

        public bool Focus()
        {
            WebElement.SendKeys(Keys.Shift);
            return WebElement.Enabled;
        }

        public class ElementNotFound : IWebElement
        {
            public bool Displayed { get { return false; } }

            public bool Enabled { get { return false; } }

            public Point Location { get { return Point.Empty; } }

            public bool Selected { get { return false; } }

            public Size Size { get { return Size.Empty; } }

            public string TagName { get { return String.Empty; } }

            public string Text { get { return String.Empty; } }

            public void Clear() { }

            public void Click() { }

            public IWebElement FindElement(By by) { return this; }

            public ReadOnlyCollection<IWebElement> FindElements(By by)
            {
                return new ReadOnlyCollection<IWebElement>(new List<IWebElement>());
            }

            public string GetAttribute(string attributeName) { return String.Empty;  }

            public string GetCssValue(string propertyName) { return String.Empty; }

            public string GetProperty(string propertyName)
            {
                throw new NotImplementedException();
            }

            public void SendKeys(string text) { }

            public void Submit() { }
        }
    }
}
