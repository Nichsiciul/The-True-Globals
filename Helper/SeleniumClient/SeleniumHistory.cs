using UiClient;
using Serilog;
using OpenQA.Selenium;
using UiHelper.Logging;

namespace SeleniumClient
{
    public class SeleniumHistory : History
    {
        private static readonly ILogger LOG = Logger.Instance;

        private readonly IWebDriver webDriver;

        public SeleniumHistory(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }

        public void Back()
        {
            LOG.Information("Navigating back");
            webDriver.Navigate().Back();
        }


        public void Forward()
        {
            LOG.Information("Navigating forward");
            webDriver.Navigate().Forward();
        }
    }
}
