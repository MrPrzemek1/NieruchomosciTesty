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
            UserPage userPage = homePage.GoTo<UserPage>(NavigationTo.ADMIN);
            UserForm addUserForm = userPage.GoTo<UserForm>();
            addUserForm.SetNewUserData(email,name,lastName);
            UserPage userPageAfterAddNewUser = addUserForm.SubmitUserForm();
            Assert.IsTrue(userPageAfterAddNewUser.Table.IsDataExistsInTable(name, email, lastName));
        }
        [Test]
        public void EmptyEmailFiled()
        {
            LoginPage loginPage = new LoginPage(manager);
            HomePage homePage = loginPage.SetCorrectLoginData(login, password);
            UserPage userPage = homePage.GoTo<UserPage>(NavigationTo.ADMIN);
            UserForm addingUserForm = userPage.GoTo<UserForm>();

            addingUserForm.Field.FirstName.SendKeys(name);
            addingUserForm.Field.LastName.SendKeys(lastName);
            UserForm addingUserFormAfterConfirm = addingUserForm.ConfirmationIncorrectForm();

            Assert.IsTrue(addingUserFormAfterConfirm.ErrorsField.IsDisplayEmarilErrorField);
            Assert.AreEqual(addingUserFormAfterConfirm.ErrorsField.EmptyEmailErrorText, "Pole jest wymagane.");
        }
        [Test]
        public void EmptyNameFiled()
        {
            LoginPage loginPage = new LoginPage(manager);
            HomePage homePage = loginPage.SetCorrectLoginData(login, password);
            UserPage userPage = homePage.GoTo<UserPage>(NavigationTo.ADMIN);
            UserForm addingUserForm = userPage.GoTo<UserForm>();

            addingUserForm.Field.Email.SendKeys(email);
            addingUserForm.Field.LastName.SendKeys(lastName);

            UserForm addingUserFormAfterConfirm = addingUserForm.ConfirmationIncorrectForm();

            Assert.IsTrue(addingUserFormAfterConfirm.ErrorsField.IsDisplayEmptyNameErrorField);
            Assert.AreEqual(addingUserFormAfterConfirm.ErrorsField.EmptyNameErrorText, "Pole jest wymagane.");
        }
        [Test]
        public void EmptyLastNameFiled()
        {
            LoginPage loginPage = new LoginPage(manager);
            HomePage homePage = loginPage.SetCorrectLoginData(login, password);
            UserPage userPage = homePage.GoTo<UserPage>(NavigationTo.ADMIN);
            UserForm addingUserForm = userPage.GoTo<UserForm>();
            addingUserForm.Field.FirstName.SendKeys(name);
            addingUserForm.Field.Email.SendKeys(email);
            UserForm addingUserFormAfterConfirm = addingUserForm.ConfirmationIncorrectForm();

            Assert.IsTrue(addingUserFormAfterConfirm.ErrorsField.IsDisplayEmptyLastNameErrorField);
            Assert.AreEqual(addingUserFormAfterConfirm.ErrorsField.EmptyLastNameErrorText, "Pole jest wymagane.");
        }
        [Test]
        public void CreateUserWithExistingEmail()
        {
            LoginPage loginPage = new LoginPage(manager);
            HomePage homePage = loginPage.SetCorrectLoginData(login, password);
            UserPage userPage = homePage.GoTo<UserPage>(NavigationTo.ADMIN);
            string email = userPage.Table.GetRandomExistingEmail();
            UserForm addingUser = userPage.GoTo<UserForm>();

            addingUser.Field.FirstName.SendKeys(name);
            addingUser.Field.LastName.SendKeys(lastName);
            addingUser.Field.Email.SendKeys(email);

            UserForm addingUserFormAfterConfirm = addingUser.ConfirmationIncorrectForm();

            Assert.IsTrue(addingUserFormAfterConfirm.ErrorsField.IsDisplayExistingEmailErrorField);
            Assert.AreEqual(addingUserFormAfterConfirm.ErrorsField.ExistingEmailErrorFieldText, "Konto z podanym adresem email już istnieje.");
        }
    }
    
}
