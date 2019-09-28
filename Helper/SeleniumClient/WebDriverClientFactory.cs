using UiClient;
using Serilog;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.IO;
using UiHelper.Logging;

namespace SeleniumClient
{
    public class WebDriverClientFactory
    {
        private static readonly ILogger LOG = Logger.Instance;

        private readonly Browser browser;

        private int? pageLoadTimeOut;

        private int? implicitWaitTimeOut;

        private bool headless;

        private bool acceptInsecureCertificates;

        private bool ignoreProtectedModeSettings;

        private Dictionary<string, object> capabilities;

        private WebDriverClientFactory(Browser browser)
        {
            this.browser = browser;
            this.headless = false;
            this.capabilities = new Dictionary<string, object>();
            
        }

        public static WebDriverClientFactory WithBrowser(Browser browser)
        {
            return new WebDriverClientFactory(browser);
        }
        
        public WebDriverClientFactory WithHeadlessmode(bool enabled)
        {
            this.headless = enabled;
            return this;
        }

        public WebDriverClientFactory WithAcceptInsecureCertificates(bool enabled)
        {
            this.acceptInsecureCertificates = enabled;
            return this;
        }

        public WebDriverClientFactory WithIgnoreProtectedModeSettings(bool enabled)
        {
            this.ignoreProtectedModeSettings = enabled;
            return this;
        }

        public WebDriverClientFactory WithCapability(string name, object value)
        {
            capabilities.Add(name, value);
            return this;
        }
               
        public WebDriverClientFactory WithPageLoadTimeOut(int seconds)
        {
            pageLoadTimeOut = seconds;
            return this;
        }

        public WebDriverClientFactory WithImplicitWaitTimeOut(int seconds)
        {
            implicitWaitTimeOut = seconds;
            return this;
        }

        public Grid Grid(String gridUrl, DriverOptions driverOptions)
        {
            return new Grid(gridUrl, driverOptions);
        }

        public WebDriverClient Create()
        {
            IWebDriver webDriver;
            switch (browser)
            {
                case Browser.INTERNET_EXPLORER:
                    var ieOptions = new InternetExplorerOptions();
                    if (headless)
                    {
                        throw new NotSupportedException("Headless mode for IE not available.");
                    }
                    if (acceptInsecureCertificates)
                    {
                        ieOptions.AcceptInsecureCertificates = true;
                    }
                    if (ignoreProtectedModeSettings)
                    {
                        ieOptions.IntroduceInstabilityByIgnoringProtectedModeSettings = true;
                    }
                    LoadOptionsWithCapabilities(ref ieOptions);
                    webDriver = new InternetExplorerDriver(ieOptions);
                    break;
                case Browser.CHROME:
                    var chromeOptions = new ChromeOptions();
                    if (headless)
                    {
                        chromeOptions.AddArguments("headless");
                    }
                    if (acceptInsecureCertificates)
                    {
                        chromeOptions.AcceptInsecureCertificates = true;
                    }
                    LoadOptionsWithCapabilities(ref chromeOptions);
                    webDriver = new ChromeDriver(chromeOptions);
                    break;
                case Browser.FIREFOX:
                    var firefoxOptions = new FirefoxOptions();
                    if (headless)
                    {
                        firefoxOptions.AddArguments("-headless");
                    }
                    if (acceptInsecureCertificates)
                    {
                        firefoxOptions.AcceptInsecureCertificates = true;
                    }
                    LoadOptionsWithCapabilities(ref firefoxOptions);
                    firefoxOptions.AcceptInsecureCertificates = true;
                    webDriver = new FirefoxDriver(firefoxOptions);
                    break;
                case Browser.ANDROIDMOBIL:
                    throw new NotSupportedException("Please use CrossBrowserTesting Extension instead!");
                default:
                    throw new UnexpectedClientException("Unknown browser " + browser);
            }

            if(pageLoadTimeOut != null)
            {
                webDriver.Manage().Timeouts().PageLoad = new TimeSpan(0, 0, 0, pageLoadTimeOut.Value);
            }

            if (implicitWaitTimeOut != null)
            {
                webDriver.Manage().Timeouts().ImplicitWait = new TimeSpan(0, 0, 0, implicitWaitTimeOut.Value);
            }

            return new WebDriverClient(webDriver);
        }

        private void LoadOptionsWithCapabilities<T> (ref T options) where T : DriverOptions
        {
            foreach (var cap in capabilities) {
                options.AddAdditionalCapability(cap.Key, cap.Value);
            }
        }
    }
} 