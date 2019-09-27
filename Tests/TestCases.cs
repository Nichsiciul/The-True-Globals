using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;

namespace AutothonTests
{
    [TestClass]
    public class TestCases : TestCaseBase
    {

        [TestMethod]
        [TestCategory("UiTest")]
        [WorkItem(000000)]
        public void Check_OpenPage()
        {
            //Arrange
            Autothon.Ui.OpenPage();
            //Act
            //Assert
            Autothon.Ui.IsTrue().Should().BeTrue();
        }
        [TestMethod]
        [TestCategory("RestApiTest")]
        [WorkItem(000001)]
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