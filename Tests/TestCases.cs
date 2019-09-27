using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AutothonTests
{
    [TestClass]
    public class TestCases : TestCaseBase
    {

        [TestMethod]
        [TestCategory("RegressionTest")]
        [WorkItem(000000)]
        public void Check_OpenPage()
        {
            //Arrange
            Autothon.Ui.OpenPage();
            //Act
            //Assert
            Autothon.Ui.IsTrue().Should().BeTrue();
        }
    }
}