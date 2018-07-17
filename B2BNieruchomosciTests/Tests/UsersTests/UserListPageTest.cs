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
            UserPage userPage = homePage.GoTo<UserPage>(NavigationTo.ADMIN, By.Id("users-grid"));
            AddUserForm addUserForm = userPage.GoToAddNewUserForm();
            addUserForm.SetNewUserData(email,name,lastName);
            UserPage userPageAfterAddNewUser = addUserForm.SubmitAddUserForm();
            Assert.IsTrue(userPageAfterAddNewUser.Table.SprawdzanieWartosciWTabeli(name, email, lastName));
        }
        [Test]
        public void EmptyEmailFiled()
        {
            LoginPage loginPage = new LoginPage(manager);
            HomePage homePage = loginPage.SetCorrectLoginData(login, password);
            UserPage userPage = homePage.GoTo<UserPage>(NavigationTo.ADMIN, By.Id("users-grid"));
            AddUserForm addingUserForm = userPage.GoToAddNewUserForm();

            addingUserForm.Field.Name.SendKeys(name);
            addingUserForm.Field.LastName.SendKeys(lastName);
            AddUserForm addingUserFormAfterConfirm = addingUserForm.ConfirmationIncorrectForm();

            Assert.IsTrue(addingUserFormAfterConfirm.ErrorsField.IsDisplayEmarilErrorField);
            Assert.AreEqual(addingUserFormAfterConfirm.ErrorsField.EmptyEmailErrorText, "Pole jest wymagane.");
        }
        [Test]
        public void EmptyNameFiled()
        {
            LoginPage loginPage = new LoginPage(manager);
            HomePage homePage = loginPage.SetCorrectLoginData(login, password);
            UserPage userPage = homePage.GoTo<UserPage>(NavigationTo.ADMIN, By.Id("users-grid"));
            AddUserForm addingUserForm = userPage.GoToAddNewUserForm();

            addingUserForm.Field.Email.SendKeys(email);
            addingUserForm.Field.LastName.SendKeys(lastName);

            AddUserForm addingUserFormAfterConfirm = addingUserForm.ConfirmationIncorrectForm();

            Assert.IsTrue(addingUserFormAfterConfirm.ErrorsField.IsDisplayEmptyNameErrorField);
            Assert.AreEqual(addingUserFormAfterConfirm.ErrorsField.EmptyNameErrorText, "Pole jest wymagane.");
        }
        [Test]
        public void EmptyLastNameFiled()
        {
            LoginPage loginPage = new LoginPage(manager);
            HomePage homePage = loginPage.SetCorrectLoginData(login, password);
            UserPage userPage = homePage.GoTo<UserPage>(NavigationTo.ADMIN, By.Id("users-grid"));
            AddUserForm addingUserForm = userPage.GoToAddNewUserForm();

            addingUserForm.Field.Name.SendKeys(name);
            addingUserForm.Field.Email.SendKeys(email);
            AddUserForm addingUserFormAfterConfirm = addingUserForm.ConfirmationIncorrectForm();

            Assert.IsTrue(addingUserFormAfterConfirm.ErrorsField.IsDisplayEmptyLastNameErrorField);
            Assert.AreEqual(addingUserFormAfterConfirm.ErrorsField.EmptyLastNameErrorText, "Pole jest wymagane.");
        }
        [Test]
        public void CreateUserWithExistingEmail()
        {
            LoginPage loginPage = new LoginPage(manager);
            HomePage homePage = loginPage.SetCorrectLoginData(login, password);
            UserPage userPage = homePage.GoTo<UserPage>(NavigationTo.ADMIN, By.Id("users-grid"));
            string email = userPage.GetRandomExistingEmail();
            AddUserForm addingUser = userPage.GoToAddNewUserForm();

            addingUser.Field.Name.SendKeys(name);
            addingUser.Field.LastName.SendKeys(lastName);
            addingUser.Field.Email.SendKeys(email);

            AddUserForm addingUserFormAfterConfirm = addingUser.ConfirmationIncorrectForm();

            Assert.IsTrue(addingUserFormAfterConfirm.ErrorsField.IsDisplayExistingEmailErrorField);
            Assert.AreEqual(addingUserFormAfterConfirm.ErrorsField.ExistingEmailErrorFieldText, "Konto z podanym adresem email już istnieje.");
        }
    }
    
}
