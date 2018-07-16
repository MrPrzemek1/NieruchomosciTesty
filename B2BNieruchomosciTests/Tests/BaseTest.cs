using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using System;
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
        protected string street = RandomDataHelper.RandomString(7);
        protected string city = RandomDataHelper.RandomString(7);
        protected int randomInt = RandomDataHelper.RandomInt();

        protected WebDriverWait wait;

        public BaseTest() { }
        public BaseTest(DriverManager manager)
        {
            wait = new WebDriverWait(manager.Driver, TimeSpan.FromSeconds(20));
            wait.PollingInterval = TimeSpan.FromMilliseconds(100);
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
