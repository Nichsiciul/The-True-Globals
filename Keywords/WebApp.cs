using SeleniumClient;

namespace Keywords
{
    public class WebApp
    {
        private WebDriverClient client;
        private UIKeywords ui;
        private readonly Browser browser;
        private string testname;
        public static string BaseUrl { get; private set; }

        public WebApp(string baseurl, string browser, string testname)
        {
            WebApp.BaseUrl = baseurl;
            this.testname = testname;
            switch (browser)
            {
                case "IE":
                    this.browser = Browser.INTERNET_EXPLORER;
                    break;
                case "Firefox":
                    this.browser = Browser.FIREFOX;
                    break;
                default:
                    this.browser = Browser.CHROME;
                    break;
            }
        }

        public UIKeywords Ui
        {
            get
            {
                if (ui == null)
                {
                    switch (this.browser)
                    {
                        case Browser.INTERNET_EXPLORER:
                            client = WebDriverClientFactory.WithBrowser(this.browser).WithIgnoreProtectedModeSettings(true).Create();
                            break;
                        case Browser.FIREFOX:
                            client = WebDriverClientFactory.WithBrowser(this.browser).WithAcceptInsecureCertificates(true).Create();
                            break;
                        default:
                            client = WebDriverClientFactory.WithBrowser(this.browser).Create();
                            break;
                    }
                    client.Window().Fullscreen();
                    ui = new UIKeywords(client);

                }
                return ui;
            }
        }

        public void UiCleanUp()
        {
            if (client != null)
            {
                client.Quit();
            }
        }

    }
}
