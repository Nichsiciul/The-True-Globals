using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AutothonTests
{
    [TestClass]
    public class TestCasesUI : TestCaseBase
    {

        [TestMethod]
        [TestCategory("UiTest")]
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