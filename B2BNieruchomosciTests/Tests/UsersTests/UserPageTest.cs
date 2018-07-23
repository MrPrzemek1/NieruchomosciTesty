using NUnit.Framework;
using PageObjectModel;
using TestResources;

namespace Tests
{
    class UserPageTest : BaseTest
    {
        public UserPageTest(DriverManager manager) : base(manager) { }
        public UserPageTest() { }

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
        public void EmptyEmailFile()
        {
            LoginPage loginPage = new LoginPage(manager);
            HomePage homePage = loginPage.SetCorrectLoginData(login, password);
            UserPage userPage = homePage.GoTo<UserPage>(NavigationTo.ADMIN);
            UserForm addingUserForm = userPage.GoTo<UserForm>();

            addingUserForm.Field.FirstName.SendKeys(name);
            addingUserForm.Field.LastName.SendKeys(lastName);
            UserForm addingUserFormAfterConfirm = addingUserForm.ConfirmationIncorrectForm();

            Assert.IsTrue(addingUserFormAfterConfirm.Error.IsDisplayEmarilErrorField);
            Assert.AreEqual(addingUserFormAfterConfirm.Error.EmptyEmailErrorText, "Pole jest wymagane.");
        }
        [Test]
        public void EmptyNameFile()
        {
            LoginPage loginPage = new LoginPage(manager);
            HomePage homePage = loginPage.SetCorrectLoginData(login, password);
            UserPage userPage = homePage.GoTo<UserPage>(NavigationTo.ADMIN);
            UserForm addingUserForm = userPage.GoTo<UserForm>();

            addingUserForm.Field.Email.SendKeys(email);
            addingUserForm.Field.LastName.SendKeys(lastName);

            UserForm addingUserFormAfterConfirm = addingUserForm.ConfirmationIncorrectForm();

            Assert.IsTrue(addingUserFormAfterConfirm.Error.IsDisplayEmptyFirstNameErrorField);
            Assert.AreEqual(addingUserFormAfterConfirm.Error.EmptyFirstNameErrorText, "Pole jest wymagane.");
        }
        [Test]
        public void EmptyLastNameFile()
        {
            LoginPage loginPage = new LoginPage(manager);
            HomePage homePage = loginPage.SetCorrectLoginData(login, password);
            UserPage userPage = homePage.GoTo<UserPage>(NavigationTo.ADMIN);
            UserForm addingUserForm = userPage.GoTo<UserForm>();
            addingUserForm.Field.FirstName.SendKeys(name);
            addingUserForm.Field.Email.SendKeys(email);
            UserForm addingUserFormAfterConfirm = addingUserForm.ConfirmationIncorrectForm();

            Assert.IsTrue(addingUserFormAfterConfirm.Error.IsDisplayEmptyLastNameErrorField);
            Assert.AreEqual(addingUserFormAfterConfirm.Error.EmptyLastNameErrorText, "Pole jest wymagane.");
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

            Assert.IsTrue(addingUserFormAfterConfirm.Error.IsDisplayExistingEmailErrorField);
            Assert.AreEqual(addingUserFormAfterConfirm.Error.ExistingEmailErrorFieldText, "Konto z podanym adresem email już istnieje.");
        }
    }
    
}
