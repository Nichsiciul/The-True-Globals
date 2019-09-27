using RestSharp;
using SeleniumClient;

namespace Keywords
{
    public class WebApp
    {
        private WebDriverClient webClient;
        private UIKeywords ui;
        private RestClient restClient;
        private RestKeywords rest;
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
                            webClient = WebDriverClientFactory.WithBrowser(this.browser).WithIgnoreProtectedModeSettings(true).Create();
                            break;
                        case Browser.FIREFOX:
                            webClient = WebDriverClientFactory.WithBrowser(this.browser).WithAcceptInsecureCertificates(true).Create();
                            break;
                        default:
                            webClient = WebDriverClientFactory.WithBrowser(this.browser).Create();
                            break;
                    }
                    webClient.Window().Fullscreen();
                    ui = new UIKeywords(webClient);

                }
                return ui;
            }
        }

        public RestKeywords Rest
        {
            get
            {
                if (rest == null)
                {
                    rest = new RestKeywords(restClient);
                }
                return rest;
            }
        }

        public void UiCleanUp()
        {
            if (webClient != null)
            {
                webClient.Quit();
            }
        }
    }
}
