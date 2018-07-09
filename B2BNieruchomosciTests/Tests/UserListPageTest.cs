using NUnit.Framework;
using OpenQA.Selenium;
using PageObjectModel;
using TestResources;

namespace Tests
{
    class UserListPageTest : BaseTest
    {
        public UserListPageTest(DriverManager manager) : base(manager) { }
        public UserListPageTest() { }

        [Test]
        public void CreateNewUser()
        {
            LoginPage loginPage = new LoginPage(manager);
            HomePage homePage = loginPage.SetCorrectLoginData(login, password);
            UserListPage userPage = homePage.GoTo<UserListPage>(NavigationTo.ADMIN, By.Id("users-grid"));
            AddingUserFormPage addUserForm = userPage.GoToAddNewUserForm();
            addUserForm.SetNewUserData(email,name,lastName);
            UserListPage userPageAfterAddNewUser = addUserForm.ConfirmationForm();
            Assert.IsTrue(userPageAfterAddNewUser.UsersTable.GridContainsData(name, email, lastName));
        }
        [Test]
        public void EmptyEmailFiled()
        {
            LoginPage loginPage = new LoginPage(manager);
            HomePage homePage = loginPage.SetCorrectLoginData(login, password);
            UserListPage userPage = homePage.GoTo<UserListPage>(NavigationTo.ADMIN, By.Id("users-grid"));
            AddingUserFormPage addingUserForm = userPage.GoToAddNewUserForm();

            addingUserForm.Name.SendKeys(name);
            addingUserForm.LastName.SendKeys(lastName);
            AddingUserFormPage addingUserFormAfterConfirm = addingUserForm.ConfirmationIncorrectForm();

            Assert.IsTrue(addingUserFormAfterConfirm.ErrorsField.IsDisplayEmarilErrorField);
            Assert.AreEqual(addingUserFormAfterConfirm.ErrorsField.EmptyEmailErrorText, "Pole jest wymagane.");
        }
        [Test]
        public void EmptyNameFiled()
        {
            LoginPage loginPage = new LoginPage(manager);
            HomePage homePage = loginPage.SetCorrectLoginData(login, password);
            UserListPage userPage = homePage.GoTo<UserListPage>(NavigationTo.ADMIN, By.Id("users-grid"));
            AddingUserFormPage addingUserForm = userPage.GoToAddNewUserForm();

            addingUserForm.Email.SendKeys(email);
            addingUserForm.LastName.SendKeys(lastName);

            AddingUserFormPage addingUserFormAfterConfirm = addingUserForm.ConfirmationIncorrectForm();

            Assert.IsTrue(addingUserFormAfterConfirm.ErrorsField.IsDisplayEmptyNameErrorField);
            Assert.AreEqual(addingUserFormAfterConfirm.ErrorsField.EmptyNameErrorText, "Pole jest wymagane.");
        }
        [Test]
        public void EmptyLastNameFiled()
        {
            LoginPage loginPage = new LoginPage(manager);
            HomePage homePage = loginPage.SetCorrectLoginData(login, password);
            UserListPage userPage = homePage.GoTo<UserListPage>(NavigationTo.ADMIN, By.Id("users-grid"));
            AddingUserFormPage addingUserForm = userPage.GoToAddNewUserForm();

            addingUserForm.Name.SendKeys(name);
            addingUserForm.Email.SendKeys(email);
            AddingUserFormPage addingUserFormAfterConfirm = addingUserForm.ConfirmationIncorrectForm();

            Assert.IsTrue(addingUserFormAfterConfirm.ErrorsField.IsDisplayEmptyLastNameErrorField);
            Assert.AreEqual(addingUserFormAfterConfirm.ErrorsField.EmptyLastNameErrorText, "Pole jest wymagane.");
        }
        [Test]
        public void CreateUserWithExistingEmail()
        {
            LoginPage loginPage = new LoginPage(manager);
            HomePage homePage = loginPage.SetCorrectLoginData(login, password);
            UserListPage userPage = homePage.GoTo<UserListPage>(NavigationTo.ADMIN, By.Id("users-grid"));
            string email = userPage.GetRandomExistingEmail();
            AddingUserFormPage addingUser = userPage.GoToAddNewUserForm();

            addingUser.Name.SendKeys(name);
            addingUser.LastName.SendKeys(lastName);
            addingUser.Email.SendKeys(email);

            AddingUserFormPage addingUserFormAfterConfirm = addingUser.ConfirmationIncorrectForm();

            Assert.IsTrue(addingUserFormAfterConfirm.ErrorsField.IsDisplayExistingEmailErrorField);
            Assert.AreEqual(addingUserFormAfterConfirm.ErrorsField.ExistingEmailErrorFieldText, "Konto z podanym adresem email już istnieje.");
        }
    }
    
}
