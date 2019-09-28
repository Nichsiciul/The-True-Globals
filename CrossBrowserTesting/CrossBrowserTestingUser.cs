namespace CrossBrowserTesting
{
    public class CrossBrowserTestingUser
    {
        public CrossBrowserTestingUser(string username, string authKey)
        {
            this.Username = username;
            this.Authkey = authKey;
        }
        public string Username { get; set; }
        public string Authkey { get; set; }

        public static CrossBrowserTestingUser Default
        {
            get
            {
                return new CrossBrowserTestingUser("alexandru.mutescul@nagarro.com", "Blacklightmouse07!");
            }    
        }

    }
}