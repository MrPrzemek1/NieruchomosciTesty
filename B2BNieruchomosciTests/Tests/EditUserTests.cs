using NUnit.Framework;
using OpenQA.Selenium;
using PageObjectModel;
using TestResources;
using System.Linq;
namespace Tests
{
    class EditUserTests:BaseTest
    {
        public EditUserTests() { }
        public EditUserTests(DriverManager manager) : base(manager) { }

        [Test, Order(1)]
        public void CorrectEditUser()
        {
            EditUserPage editUser = GoToUserEditPage();

            string email = editUser.Header.Text;
            string newName = RandomDataHelper.RandomString(6);
            string lastName = RandomDataHelper.RandomString(6);

            editUser.ChangeName(newName);
            editUser.ChangeLastName(lastName);
            UserListPage userPageAfterEdit = editUser.ConfirmEditUser();
            Assert.IsTrue(userPageAfterEdit.UsersTable.GridContainsData(newName, lastName, email));
        }
        [Test, Order(2)]
        public void BlockUser()
        {
            EditUserPage editUser = GoToUserEditPage();
            string email = editUser.Header.Text;
            UserListPage userList = editUser.BlockUser();
            Assert.IsTrue(userList.UsersTable.AllRowsOnGrid.Any(e => e.Text.Contains(email)&&e.Text.Contains("Tak")));            
        }
        [Test, Order(3)]
        public void UnBlockUser()
        {
            LoginPage loginPage = new LoginPage(manager);
            HomePage homePage = loginPage.SetCorrectLoginData(login, password);
            UserListPage userPage = homePage.GoTo<UserListPage>(NavigationTo.ADMIN, By.Id("users-grid"));
            EditUserPage editUser = userPage.GoToBlockedUser();
            string email = editUser.Header.Text;
            UserListPage userList = editUser.UnBlockUser();
            Assert.IsTrue(userPage.SuccessAlert.Displayed);
            Assert.IsTrue(userPage.SuccessAlert.Text.Contains("Dane zostały zapisane"));
            Assert.IsTrue(userList.UsersTable.AllRowsOnGrid.Any(e => e.Text.Contains(email) && e.Text.Contains("Nie")));
        }
        [Test, Order(4)]
        public void PasswordReset()
        {
            EditUserPage editUser = GoToUserEditPage();
            UserListPage userPage = editUser.ResetPassword();
            Assert.IsTrue(userPage.SuccessAlert.Displayed);
            Assert.AreEqual(userPage.SuccessAlert.Text, "Wiadomość została wysłana");
        }
        [Test]
        public void EmptyNameField()
        {
            EditUserPage editUser = GoToUserEditPage();
            string lastName = RandomDataHelper.RandomString(6);
            editUser.ChangeName(string.Empty);
            editUser.ChangeLastName(lastName);
            editUser.ConfirmButton.Click();
            EditUserPage userPageAfterConfirmForm = new EditUserPage(manager);
            Assert.IsTrue(userPageAfterConfirmForm.ErrorField.IsDisplayEmptyNameErrorField);
            Assert.AreEqual(userPageAfterConfirmForm.ErrorField.EmptyNameErrorText, "Pole jest wymagane.");
        }
        [Test]
        public void EmptyLastNameField()
        {
            EditUserPage editUser = GoToUserEditPage();
            string name = RandomDataHelper.RandomString(6);
            editUser.ChangeName(name);
            editUser.ChangeLastName(string.Empty);
            editUser.ConfirmButton.Click();
            EditUserPage userPageAfterConfirmForm = new EditUserPage(manager);
            Assert.IsTrue(userPageAfterConfirmForm.ErrorField.IsDisplayEmptyLastNameErrorField);
            Assert.AreEqual(userPageAfterConfirmForm.ErrorField.EmptyLastNameErrorText, "Pole jest wymagane.");
        }
        private EditUserPage GoToUserEditPage()
        {
            LoginPage loginPage = new LoginPage(manager);
            HomePage homePage = loginPage.SetCorrectLoginData(login, password);
            UserListPage userPage = homePage.GoTo<UserListPage>(NavigationTo.ADMIN, By.Id("users-grid"));
            EditUserPage editUser = userPage.GoToEditUser();

            return editUser;
        }
    }
}
