using OpenQA.Selenium;

namespace CrossBrowserTesting
{
    public class CrossBrowserTestingConfig
    {
        public CrossBrowserTestingConfig(CrossBrowserTestingUser user, RemoteSessionSettings sessionSettings)
        {
            this.SessionSettings = sessionSettings;
            this.SessionSettings.AddMetadataSetting("username", user.Username);
            this.SessionSettings.AddMetadataSetting("password", user.Authkey);
        }
        public RemoteSessionSettings SessionSettings { get; set; }

        public static CrossBrowserTestingConfig Android9_GooglePixel3_Chrome
        {
            get
            {
                var settings = new RemoteSessionSettings();
                settings.AddMetadataSetting("browserName", "Chrome");
                settings.AddMetadataSetting("deviceName", "Pixel 3");
                settings.AddMetadataSetting("platformVersion", "9.0");
                settings.AddMetadataSetting("platformName", "Android");
                settings.AddMetadataSetting("deviceOrientation", "portrait");
                settings.AddMetadataSetting("record_video", "true");
                settings.AddMetadataSetting("record_network", "false");
                return new CrossBrowserTestingConfig(CrossBrowserTestingUser.Default, settings);
            }
        }

        public static CrossBrowserTestingConfig Android6_Nexus9_Tablet_Chrome
        {
            get
            {
                var settings = new RemoteSessionSettings();
                settings.AddMetadataSetting("browserName", "Chrome");
                settings.AddMetadataSetting("deviceName", "Nexus 9");
                settings.AddMetadataSetting("platformVersion", "6.0");
                settings.AddMetadataSetting("platformName", "Android");
                settings.AddMetadataSetting("deviceOrientation", "portrait");
                settings.AddMetadataSetting("record_video", "true");
                settings.AddMetadataSetting("record_network", "false");
                return new CrossBrowserTestingConfig(CrossBrowserTestingUser.Default, settings);
            }
        }
    }
}