using NUnit.Framework;
using PageObjectModel;
using TestResources;
using TestResources.Helpers;

namespace Tests
{
    class UserListPageTest : BaseTest
    {
        public UserListPageTest(DriverManager manager) : base(manager) { }
        public UserListPageTest() { }

        [Test]
        public void AddingNewUser()
        {
            LoginPage loginPage = new LoginPage(manager);
            HomePage homePage = loginPage.SetCorrectLoginData(DataReaderHelper.GetLogin(), DataReaderHelper.GetPassword());
            UserListPage userPage = homePage.GoTo<UserListPage>(NavigationTo.ADMIN);
            string name = RandomDataHelper.RandomString(5);
            string email = RandomDataHelper.RandomString(5) + "@test.pl";
            string lastName = RandomDataHelper.RandomString(7);
            UserListPage userPageAfterAddNewUser = userPage.AddNewUser(email, name, lastName);
            Assert.IsTrue(userPageAfterAddNewUser.UsersTable.GridContainsData(name, email, lastName));
        }
    }
}
