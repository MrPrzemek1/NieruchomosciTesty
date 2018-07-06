using B2BNieruchomosciTests;
using NUnit.Framework;

namespace B2BNieruchomościTests
{
    [TestFixture]
    public class BaseTest
    {
        protected DriverManager manager;
        public BaseTest() { }
        public BaseTest(DriverManager manager)
        {
            this.manager = manager;
        }
        [OneTimeSetUp]
        public void SetUpTests()
        {
            manager = new DriverManager(DriverType.Chrome);
            manager.GoTo();
        }
        [OneTimeTearDown]
        public void EndTest()
        {
            manager.Quit();
        }
    }
}
