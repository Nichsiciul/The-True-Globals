using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;

namespace AutothonTests
{
    [TestClass]
    public class TestCasesRest : TestCaseBase
    {

        [TestMethod]
        [TestCategory("RestApiTest")]
        public void GetPage_HttpStatusOK_Successful()
        {
            // Arrange
            var expected = HttpStatusCode.OK;

            //Act
            var actual = Autothon.Rest.GetPage(deliveryBaseUrl);

            //Assert
            actual.Should().Be(expected);
        }

        [Ignore]
        [TestMethod]
        [TestCategory("RestApiTest")]
        public void createMovieIsAvailableInListAndCouldBeRent()
        {


            // login admin user
            Autothon.Rest.PostPage(deliveryBaseUrl + "/login", null);

            // create movie
            var movieStr = Autothon.Rest.PostPage(deliveryBaseUrl + "/movie", null);
            // assert movie to be sucessfully added
            // movieStr to object

            // Logout admin user
            Autothon.Rest.GetPage(deliveryBaseUrl + "/logout");

            // Login User
            Autothon.Rest.PostPage(deliveryBaseUrl + "/login", null);

            // Get Movies and check if new is available r
           var movieList = Autothon.Rest.GetPage(deliveryBaseUrl + "/movies");
            // check if new movie is in the list

            // rent movie
            Autothon.Rest.GetPage(deliveryBaseUrl + "/rent/" + "{movieId}");


        }
    }
}