using Serilog;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using SeleniumClient;
using System;
using UiHelper.Logging;

namespace SeleniumClient
{
    public class Grid
    {
        private static readonly ILogger LOG = Logger.Instance;

        private readonly Uri gridUrl;
        private readonly DriverOptions driverOptions;

        public Grid(String gridUrl, DriverOptions driverOptions) 
        {
            this.gridUrl = new Uri(gridUrl);
            this.driverOptions = driverOptions;
        }

        public WebDriverClient Create()
        {
            LOG.Information("Creating Grid WebDriver at {} with options {}", gridUrl, driverOptions);

            return new WebDriverClient(new RemoteWebDriver(gridUrl, driverOptions));
        }
    }
}
