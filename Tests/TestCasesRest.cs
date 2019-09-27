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
    }
}