using OpenQA.Selenium.Remote;
using System;
using SeleniumClient;

namespace CrossBrowserTesting
{
    public static class CrossBrowserDriverFactory
    {
        public static WebDriverClient Create(CrossBrowserTestingConfig config)
        {
            RemoteWebDriver driver = new RemoteWebDriver(new Uri("http://hub.crossbrowsertesting.com:80/wd/hub"), config.SessionSettings, TimeSpan.FromSeconds(180));
            return new WebDriverClient(driver);
        }
    }
}
