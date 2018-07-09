using NUnit.Framework;
using TestResources;
using TestResources.Helpers;

namespace Tests
{
    [TestFixture]
    public class BaseTest
    {
        protected DriverManager manager;
        protected readonly string login = DataReaderHelper.GetLogin();
        protected readonly string password = DataReaderHelper.GetPassword();
        protected string name = RandomDataHelper.RandomString(5);
        protected string lastName = RandomDataHelper.RandomString(7);
        protected string email = RandomDataHelper.RandomString(5) + "@test.pl";

        public BaseTest() { }
        public BaseTest(DriverManager manager)
        {
            this.manager = manager;
        }
        [SetUp]
        public void SetUpTests()
        {
            manager = new DriverManager(DriverTypeEnum.Chrome);
            manager.GoTo();
        }
        [TearDown]
        public void EndTest()
        {
            manager.Quit();
        }
    }
}
