using System;
using Map;
using Util;
using SeleniumClient;
using DataProvider;

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
        }

        public bool IsTrue()
        {
            return Client.Element(Map.UIMap.Input).GetAttribute("value").Equals("Something");
        }

        public UIKeywords Login(string username, string password)
        {
            Client.Element(Map.UIMap.OpenNavigationButton).Click();
            Sleeper.Sleep(1, SleepReason.UI);
            Client.Element(Map.UIMap.NavigationLoginLink).Click();
            Client.Element(Map.UIMap.LoginUserName).SetText(username);
            Client.Element(Map.UIMap.LoginPassword).SetText(password);
            Client.Element(Map.UIMap.LoginButton).Click();
            return this;
        }

        public void ClickAddMovie()
        {
            Client.Element(Map.UIMap.NavigationAddMovieLink).Click();
        }

        public String AddMovieData()
        {
            String title = InsertTitle();
            InsertDirector();
            InsertDescription();
            InsertCategories();
            InsertURL();
            InsertRating(3);

            return title;
        }

        public String GetLastCreatedMovieTitle()
        {
            return Client.Element(Map.UIMap.LastMovieTitle).GetText();
        }

        public void InsertRating(int rating)
        {
            switch (rating)
            {
                case 1:
                    Client.Element(Map.UIMap.AddMovieRating1Field).Click();
                    break;
                case 2:
                    Client.Element(Map.UIMap.AddMovieRating2Field).Click();
                    break;
                case 3:
                    Client.Element(Map.UIMap.AddMovieRating3Field).Click();
                    break;
                case 4:
                    Client.Element(Map.UIMap.AddMovieRating4Field).Click();
                    break;
                case 5:
                    Client.Element(Map.UIMap.AddMovieRating5Field).Click();
                    break;
            }
        }

        public void Save()
        {
            Client.Element(Map.UIMap.AddMoviedSaveButton).Click();
        }

        public bool Title_IsValid()
        {
            return Client.Element(Map.UIMap.AddMovieTitleField).GetAttribute("class").Contains("is-valid");
        }

        public void RefreshClient()
        {
            Client.Refresh();
        }

        public bool Description_IsValid()
        {
            return Client.Element(Map.UIMap.AddMovieDescriptionField).GetAttribute("class").Contains("is-valid");
        }

        public bool URL_IsValid()
        {
            return Client.Element(Map.UIMap.AddMovieURLField).GetAttribute("class").Contains("is-valid");
        }

        public bool Rating_IsValid()
        {
            return Client.Element(Map.UIMap.AddMovieRatingValid).IsDisplayed();
        }

        public bool Categories_IsValid()
        {
            return Client.Element(Map.UIMap.AddMovieCategoriesField).GetAttribute("class").Contains("is-valid");
        }

        public bool Director_IsValid()
        {
            return Client.Element(Map.UIMap.AddMovieDirectorField).GetAttribute("class").Contains("is-valid");
        }

        public void InsertURL()
        {
            Client.Element(Map.UIMap.AddMovieURLField).SetText("https://picsum.photos/200/300");
        }

        public void InsertCategories()
        {
            Client.Element(Map.UIMap.AddMovieDramaOption).Click();
        }

        public void InsertDescription()
        {
            Client.Element(Map.UIMap.AddMovieDescriptionField).SetText("A manipulative woman and a roguish man conduct a turbulent romance during the American Civil War and Reconstruction periods.");
        }

        public void InsertDirector()
        {
            Client.Element(Map.UIMap.AddMovieDirectorField).SetText("Victor Fleming");
        }

        public String InsertTitle()
        {
            var randomNumber = new Random().Next(0, 999999);
            String title = "New Movie " + randomNumber.ToString();
            Client.Element(Map.UIMap.AddMovieTitleField).SetText(title);

            return title;
        }

        public bool CheckAdminIsLoggedIn()
        {
            return Client.Element(Map.UIMap.AdminNavigationMenu).IsDisplayed();
        }

        public bool CheckUserIsLoggedIn()
        {
            return !(Client.Element(Map.UIMap.AdminNavigationMenu).IsDisplayed()) && Client.Element(Map.UIMap.NavigationProfileLink).IsDisplayed();
        }

        public UIKeywords Login(MovieUser user)
        {
            return Login(user.UserName, user.PassWord);
        }
    }
}
