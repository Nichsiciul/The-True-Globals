using System;
using Map;
using Util;
using SeleniumClient;

namespace Keywords
{
    public class UIKeywords
    {
        public UIKeywords(WebDriverClient client)
        {
            Client = client;
        }

        private WebDriverClient Client { get; set; }

        public void OpenPage()
        {
            Client.Go(WebApp.BaseUrl);
            Client.Element(Map.UIMap.Input).SendKeys("Something");

        }

        public bool IsTrue()
        {
            return Client.Element(Map.UIMap.Input).GetAttribute("value").Equals("Something");
        }
    }
}
