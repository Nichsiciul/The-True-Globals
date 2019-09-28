using DataProvider;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AutothonTests
{
    [TestClass]
    public class TestCasesUI : TestCaseBase
    {
        [TestMethod]
        [TestCategory("UiTest")]
        public void Check_LogIn_Admin_Succesfull()
        {
            //Arrange
            Autothon.Ui.OpenPage();
            //Act
            Autothon.Ui.Login(MovieUser.Admin);
            //Assert
            Autothon.Ui.CheckAdminIsLoggedIn().Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("UiTest")]
        public void Check_LogIn_User_Succesfull()
        {
            //Arrange
            Autothon.Ui.OpenPage();
            //Act
            Autothon.Ui.Login(MovieUser.User);
            //Assert
            Autothon.Ui.CheckUserIsLoggedIn().Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("UiTest")]
        public void Check_AddNewMovie_User_Succesfull()
        {
            //Arrange
            Autothon.Ui.OpenPage();
            Autothon.Ui.Login(MovieUser.Admin);
            Autothon.Ui.ClickAddMovie();
            //Act
            Autothon.Ui.InsertTitle();
            Autothon.Ui.InsertDirector();
            Autothon.Ui.InsertDescription();
            Autothon.Ui.InsertCategories();
            Autothon.Ui.InsertURL();
            Autothon.Ui.InsertRating(3);
            //Autothon.Ui.Save();
            //Assert
            Autothon.Ui.Title_IsValid().Should().BeTrue();
            Autothon.Ui.Director_IsValid().Should().BeTrue();
            Autothon.Ui.Description_IsValid().Should().BeTrue();
            Autothon.Ui.Categories_IsValid().Should().BeTrue();
            Autothon.Ui.URL_IsValid().Should().BeTrue();
            Autothon.Ui.Rating_IsValid().Should().BeTrue();
        }

        [TestMethod]
        [TestCategory("UiTest")]
        public void Check_TwoParallelBrowserSessions_User_Succesfull()
        {
            //Arrange
            Autothon.Ui.OpenPage();
            Autothon.Ui.Login(MovieUser.User);
            //Act
            SecondSession.Ui.OpenPage();
            Autothon.Ui.Login(MovieUser.Admin);
            Autothon.Ui.Rating_IsValid().Should().BeTrue();
            //Assert

        }
    }
}