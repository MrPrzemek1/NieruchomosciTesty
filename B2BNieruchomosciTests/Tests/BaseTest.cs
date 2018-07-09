using NUnit.Framework;
using TestResources;

namespace Tests
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
            manager = new DriverManager(DriverTypeEnum.Chrome);
            manager.GoTo();
        }
        [OneTimeTearDown]
        public void EndTest()
        {
            manager.Quit();
        }
    }
}
