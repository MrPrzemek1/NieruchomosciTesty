
using NUnit.Framework;
using PageObjectModel;
using TestResources;

namespace Tests
{
    [TestFixture]
    public class LoginPageTests : BaseTest
    {
        public LoginPageTests(DriverManager manager) : base(manager) { }
        public LoginPageTests() : base() { }
        [Test]
        public void SetLogin()
        {
            LoginPage loginPage = new LoginPage(manager);
            HomePage homePage = loginPage.SetLogin("admin@netrix.com.pl", "N@trix.765");
            Assert.IsTrue(homePage.Header.IsDisplay);
            Assert.AreEqual(homePage.Header.Text, "Strona główna");
        }
        [Test]
        public void GoToUserPage()
        {
            LoginPage loginPage = new LoginPage(manager);
            HomePage homePage = loginPage.SetLogin("admin@netrix.com.pl", "N@trix.765");
            UserListPage userPage = homePage.GoTo<UserListPage>(NavigationTo.ADMIN);
            Assert.AreEqual(userPage.Header.Text, "Administratorzy");
        }
    }
}
