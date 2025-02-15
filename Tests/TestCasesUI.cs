﻿using DataProvider;
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
        public void Check_AddNewMovie_Admin_AddData_Succesfull()
        {
            //Arrange
            Autothon.Ui.OpenPage();
            Autothon.Ui.Login(MovieUser.Admin);
            Autothon.Ui.ClickAddMovie();
            //Act
            Autothon.Ui.AddMovieData();
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
        public void Check_AddNewMovie_Admin_AddMovie_Succesfull()
        {
            //Arrange
            Autothon.Ui.OpenPage();
            Autothon.Ui.Login(MovieUser.Admin);
            Autothon.Ui.ClickAddMovie();
            //Act
            Autothon.Ui.AddMovieData();
            Autothon.Ui.Save();
            //Assert
            
        }

        [TestMethod]
        [TestCategory("UiTest")]
        public void Check_TwoParallelBrowserSessions_User_Succesfull()
        {
            //Arrange
            Autothon.Ui.OpenPage();
            Autothon.Ui.Login(MovieUser.User);

            SecondSession.Ui.OpenPage();
            SecondSession.Ui.Login(MovieUser.Admin);
            SecondSession.Ui.ClickAddMovie();

            //Act
            var movieTitle = SecondSession.Ui.AddMovieData();
            SecondSession.Ui.Save();
            Autothon.Ui.RefreshClient();

            //Assert
            Autothon.Ui.GetLastCreatedMovieTitle().Should().Be(movieTitle);

        }
    }
}