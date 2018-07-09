using NUnit.Framework;
using OpenQA.Selenium;
using PageObjectModel;
using TestResources;

namespace Tests
{
    class EditUserTests:BaseTest
    {
        public EditUserTests() { }
        public EditUserTests(DriverManager manager) : base(manager) { }

        [Test]
        public void CorrectEditUser()
        {
            LoginPage loginPage = new LoginPage(manager);
            HomePage homePage = loginPage.SetCorrectLoginData(login, password);
            UserListPage userPage = homePage.GoTo<UserListPage>(NavigationTo.ADMIN, By.Id("users-grid"));

            EditUserPage editUser = userPage.GoToEditUser();
            string email = editUser.Header.Text;
            string newName = RandomDataHelper.RandomString(6);
            string lastName = RandomDataHelper.RandomString(6);

            editUser.ChangeName(newName);
            editUser.ChangeLastName(lastName);
            UserListPage userPageAfterEdit = editUser.ConfirmEditUser();
            Assert.IsTrue(userPageAfterEdit.UsersTable.GridContainsData(newName, lastName, email));
        }
    }
}
