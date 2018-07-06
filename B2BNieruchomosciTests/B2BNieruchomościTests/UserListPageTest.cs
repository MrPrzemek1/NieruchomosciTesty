using NUnit.Framework;
using PageObjectModel;
using System;
using System.Linq;
using TestResources;

namespace Tests
{
    class UserListPageTest : BaseTest
    {
        public UserListPageTest(DriverManager manager) : base(manager) { }
        public UserListPageTest() { }

        [Test]
        public void GoTo()
        {
            LoginPage loginPage = new LoginPage(manager);
            HomePage homePage = loginPage.SetLogin("admin@netrix.com.pl", "N@trix.765");
            UserListPage userPage = homePage.GoTo<UserListPage>(NavigationTo.ADMIN);
            string name = RandomString(5);
            string email = RandomString(5) + "@test.pl";
            string lastName = RandomString(7);
            UserListPage userPageAfterAddNewUser = userPage.AddNewUser(email, name, lastName);
            userPageAfterAddNewUser.UsersTable.CheckCorrectAdd(name,email,lastName);
        }

        private string RandomString(int lenght)
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, lenght)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
