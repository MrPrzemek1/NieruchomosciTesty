using NUnit.Framework;
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
            UserForm editUser = GoToEditUserForm();

            string email = editUser.Header.Text;
            string newName = RandomDataHelper.RandomString(6);
            string lastName = RandomDataHelper.RandomString(6);
            editUser.EditUser(newName, lastName);
            UserPage userPageAfterEdit = editUser.SubmitUserForm();
            Assert.IsTrue(userPageAfterEdit.Table.IsDataExistsInTable(newName, lastName, email));
        }
        [Test, Order(2)]
        public void BlockUser()
        {
            UserForm editUser = GoToEditUserForm();
            string email = editUser.Header.Text;
            UserPage userList = editUser.BlockUser();
            Assert.IsTrue(userList.Table.AllRowsOnTable.Any(e => e.Text.Contains(email) && e.Text.Contains("Tak")));            
        }
        [Test, Order(3)]
        public void UnBlockUser()
        {
            UserPage userPage = GoToUserPager();
            UserForm editUser = userPage.GoToBlockedUser();
            string email = editUser.Header.Text;
            UserPage userList = editUser.UnBlockUser();
            Assert.IsTrue(userPage.SuccessAlert.Displayed);
            Assert.IsTrue(userPage.SuccessAlert.Text.Contains("Dane zostały zapisane"));
            Assert.IsTrue(userList.Table.AllRowsOnTable.Any(e => e.Text.Contains(email) && e.Text.Contains("Nie")));
        }

        [Test, Order(4)]
        public void PasswordReset()
        {
            UserForm editUser = GoToEditUserForm();
            UserPage userPage = editUser.ResetPassword();
            Assert.IsTrue(userPage.SuccessAlert.Displayed);
            Assert.AreEqual(userPage.SuccessAlert.Text, "Wiadomość została wysłana");
        }
        [Test]
        public void EmptyNameField()
        {
            UserForm editUserForm = GoToEditUserForm();
            editUserForm.EditUser(string.Empty,lastName);
            editUserForm.ConfirmationIncorrectForm();
            UserForm userPageAfterConfirmForm = new UserForm(manager);
            Assert.IsTrue(userPageAfterConfirmForm.Error.IsDisplayEmptyNameErrorField);
            Assert.AreEqual(userPageAfterConfirmForm.Error.EmptyNameErrorText, "Pole jest wymagane.");
        }
        [Test]
        public void EmptyLastNameField()
        {
            UserForm editUserForm = GoToEditUserForm();
            editUserForm.EditUser(name,string.Empty);
            editUserForm.ConfirmationIncorrectForm();
            UserForm userPageAfterConfirmForm = new UserForm(manager);
            Assert.IsTrue(userPageAfterConfirmForm.Error.IsDisplayEmptyLastNameErrorField);
            Assert.AreEqual(userPageAfterConfirmForm.Error.EmptyLastNameErrorText, "Pole jest wymagane.");
        }


        private UserForm GoToEditUserForm()
        {
            LoginPage loginPage = new LoginPage(manager);
            HomePage homePage = loginPage.SetCorrectLoginData(login, password);
            UserPage userPage = homePage.GoTo<UserPage>(NavigationTo.ADMIN);
            UserForm editUser = userPage.GoToEditUser();

            return editUser;
        }
        private UserPage GoToUserPager()
        {
            LoginPage loginPage = new LoginPage(manager);
            HomePage homePage = loginPage.SetCorrectLoginData(login, password);
            UserPage userPage = homePage.GoTo<UserPage>(NavigationTo.ADMIN);
            return userPage;
        }
    }
}
