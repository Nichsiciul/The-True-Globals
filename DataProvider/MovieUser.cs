namespace DataProvider
{
    public class MovieUser
    {
        public string UserName { get; private set; }
        public string PassWord { get; private set; }
        public MovieUser(string username, string password)
        {
            this.UserName = username;
            this.PassWord = password;
        }

    }
}