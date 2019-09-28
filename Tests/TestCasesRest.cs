using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using ApiHelper.Models;
using Newtonsoft.Json;
using Microsoft.Rest;
using RestSharp;
using System;
using System.Net;
namespace AutothonTests
{
    [TestClass]
    public class TestCasesRest : TestCaseBase
    {
        [TestMethod]
        [TestCategory("RestApiTest")]
        public void Create_Movie_Is_Available_In_List_And_Could_Be_Rented()
        {
            UserRequest userRequest = new UserRequest();
            userRequest.username = "admin";
            userRequest.password = "password";

            // login admin user
            var userStr = Autothon.Rest.PostPage("login", userRequest, null);

            var user = JsonConvert.DeserializeObject<User>(userStr);

            // create movie
            Movie movie = new Movie();
            movie.title = "Richi Test";
            movie.description = "Richi Test";
            movie.image = "https://m.media-amazon.com/images/M/MV5BYzVmYzVkMmUtOGRhMi00MTNmLThlMmUtZTljYjlkMjNkMjJkXkEyXkFqcGdeQXVyNDk3NzU2MTQ@._V1_SY1000_CR0,0,675,1000_AL_.jpg";
            movie.director = "Richi Test";
            movie.rating = 10;
            movie.categories.Add(Movie.Category.Comedy);

            var request = new { movie = movie };

            var movieStr = Autothon.Rest.PostPage("movies", request, user.id.ToString());
            var movieResponse = JsonConvert.DeserializeObject<Movie>(movieStr);

            Assert.IsNotNull(movie);


            Autothon.Rest.GetPage("logout");

            /*
            // Login User
            Autothon.Rest.PostPage(deliveryBaseUrl + "/login", null, null);

            // Get Movies and check if new is available r
           var movieList = Autothon.Rest.GetPage(deliveryBaseUrl + "/movies");
            // check if new movie is in the list

            // rent movie
            Autothon.Rest.GetPage(deliveryBaseUrl + "/rent/" + "{movieId}");

    */
        }
    }
}