using UiClient;
using Serilog;
using OpenQA.Selenium;
using System;
using UiHelper.Logging;

namespace SeleniumClient
{
    public class SeleniumPrompt : Prompt
    {
        private static readonly ILogger LOG = Logger.Instance;

        private readonly IWebDriver webDriver;
        public SeleniumPrompt(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }

        public void DismissAlert()
        {
            LOG.Information("Dismissing alert");
            webDriver.SwitchTo().Alert().Dismiss();
        }


        public void AcceptAlert()
        {
            LOG.Information("Accepting alert");
            webDriver.SwitchTo().Alert().Accept();
        }


        public String GetAlertText()
        {
            LOG.Information("Retrieving alert text");
            String text = webDriver.SwitchTo().Alert().Text;
            LOG.Information("Text: {}", text);
            return text;
        }


        public void SendAlertText(String keys)
        {
            LOG.Information("Send keys to alert: {0}", keys);
            webDriver.SwitchTo().Alert().SendKeys(keys);
        }


        public bool IsDisplayed()
        {
            LOG.Debug("Checking if alert is displayed...");
            try
            {
                webDriver.SwitchTo().Alert();
                LOG.Information("...alert is displayed");
                return true;
            }
            catch (NoAlertPresentException)
            {
                LOG.Information("Alert isn't displayed");
                return false;
            }
        }
    }
}
