using UiClient;
using OpenQA.Selenium;
using System;


namespace SeleniumClient
{
    public class WebLocator
    {
        public WebLocatorStrategy LocatorStrategy { get; }
        public String Locator { get; }

        public By By { get; }

        private WebLocator(WebLocatorStrategy locatorStrategy, String locator)
        {
            this.LocatorStrategy = locatorStrategy;
            this.Locator = locator;

            switch (locatorStrategy)
            {
                case WebLocatorStrategy.ID:
                    By = By.Id(Locator);
                    break;
                case WebLocatorStrategy.CLASS_NAME:
                    By = By.ClassName(Locator);
                    break;
                case WebLocatorStrategy.CSS:
                    By = By.CssSelector(Locator);
                    break;
                case WebLocatorStrategy.XPATH:
                    By = By.XPath(Locator);
                    break;
                case WebLocatorStrategy.LINK_TEXT:
                    By = By.LinkText(Locator);
                    break;
                case WebLocatorStrategy.PARTIAL_LINK_TEXT:
                    By = By.PartialLinkText(Locator);
                    break;
                case WebLocatorStrategy.NAME:
                    By = By.Name(locator);
                    break;
                default:
                    throw new UnexpectedClientException("No idea how to locate elements by " + LocatorStrategy);
            }
        }

        public static WebLocator Id(String id)
        {
            return new WebLocator(WebLocatorStrategy.ID, id);
        }

        public static WebLocator ClassName(String className)
        {
            return new WebLocator(WebLocatorStrategy.CLASS_NAME, className);
        }

        public static WebLocator Xpath(String xpath)
        {
            return new WebLocator(WebLocatorStrategy.XPATH, xpath);
        }

        public static WebLocator Css(String css)
        {
            return new WebLocator(WebLocatorStrategy.CSS, css);
        }

        public static WebLocator LinkText(String linkText)
        {
            return new WebLocator(WebLocatorStrategy.LINK_TEXT, linkText);
        }

        public static WebLocator PartialLinkText(String partialLinkText)
        {
            return new WebLocator(WebLocatorStrategy.PARTIAL_LINK_TEXT, partialLinkText);
        }

        public static WebLocator Name(String name)
        {
            return new WebLocator(WebLocatorStrategy.NAME, name);
        }

        override
        public String ToString()
        {
            return By.ToString();
        }
    }
}
