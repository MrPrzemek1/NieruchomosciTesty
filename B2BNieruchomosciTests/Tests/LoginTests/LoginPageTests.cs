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
        public void CorrectLogin()
        {
            LoginPage loginPage = new LoginPage(manager);
            HomePage homePage = loginPage.SetCorrectLoginData(login, password);
            Assert.IsTrue(homePage.Header.IsDisplay);
            Assert.AreEqual(homePage.Header.Text, "Strona główna");
        }
        [Test]
        public void WrongDataLogin()
        {
            LoginPage loginPage = new LoginPage(manager);
            loginPage.SetLoginData("Test@test1.pl", "test");
            Assert.IsTrue(loginPage.ErrorFields.WrongDataOrPassworErrorText.Equals("Niepoprawny login lub hasło."));
        }
        [Test]
        public void EmptyPasswordField()
        {
            LoginPage loginPage = new LoginPage(manager);
            loginPage.SetLoginData("Test@test1.pl", string.Empty);
            Assert.IsTrue(loginPage.ErrorFields.EmptyPasswordErrorText.Equals("Pole jest wymagane."));
        }
        [Test]
        public void EmptyEmailField()
        {
            LoginPage loginPage = new LoginPage(manager);
            loginPage.SetLoginData(string.Empty, "Test");
            Assert.IsTrue(loginPage.ErrorFields.EmptyEmailErrorText.Equals("Pole jest wymagane."));
        }
    }
}
