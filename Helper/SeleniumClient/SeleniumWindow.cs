using UiClient;
using Serilog;
using OpenQA.Selenium;
using System;
using System.Drawing;
using System.IO;
using UiHelper.Logging;

namespace SeleniumClient
{
    public class SeleniumWindow : Window
    {
        private static readonly ILogger LOG = Logger.Instance;

        private readonly IWebDriver webDriver;

        public SeleniumWindow(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }
    
        public void Close()
        {
            LOG.Debug("Closing browser window");

            webDriver.Close();
        }


        public String GetTitle()
        {
            LOG.Information("Retrieving window title");
            String title = webDriver.Title;
            LOG.Information("Title: {0}", title);
            return title;
        }


        public void Maximize()
        {
            LOG.Information("Maximizing browser window");
            webDriver.Manage().Window.Maximize();
        }


        public void Fullscreen()
        {
            LOG.Information("Setting browser window to fullscreen");
            webDriver.Manage().Window.Maximize();
        }


        public Dimension GetSize()
        {
            LOG.Information("Retrieving window size");
            Size size = webDriver.Manage().Window.Size;
            LOG.Information("Window size - width: {0}, height: {1}", size.Width, size.Height);
            return new Dimension(size.Width, size.Height);
        }


        public void SetSize(Dimension size)
        {
            LOG.Information("Setting window size to {0}", size);
            webDriver.Manage().Window.Size = new Size(size.Width, size.Height);
        }


        public Bitmap TakeScreenshot()
        {
            if (webDriver is ITakesScreenshot)
            {
                return new Bitmap(new MemoryStream(((ITakesScreenshot)webDriver).GetScreenshot().AsByteArray));
            }
            else
            {
                return null;
            }
        }
    }
}
