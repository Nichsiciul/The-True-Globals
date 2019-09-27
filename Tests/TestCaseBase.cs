using Keywords;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AutothonTests
{
    public class TestCaseBase
    {
        public TestContext TestContext { get; set; }

        public WebApp Autothon { get; private set; }

        public string deliveryBaseUrl;
        
        [TestInitialize]
        public void Setup()
        {
            var browser = TestContext.Properties["Browser"].ToString();
            var deliveryBaseUrl = TestContext.Properties["DeliveryBaseUrl"].ToString();
            this.Autothon = new WebApp(deliveryBaseUrl, browser, TestContext.TestName);
        }

        
        [TestCleanup]
        public virtual void CleanUp()
        {
            Autothon.UiCleanUp();
        }
    }
}
