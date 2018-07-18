﻿using NUnit.Framework;
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
            EditUserForm editUser = GoToEditUserForm();

            string email = editUser.Header.Text;
            string newName = RandomDataHelper.RandomString(6);
            string lastName = RandomDataHelper.RandomString(6);

            editUser.ChangeFirstName(newName);
            editUser.ChangeLastName(lastName);
            UserPage userPageAfterEdit = editUser.SubmitEditUserForm();
            Assert.IsTrue(userPageAfterEdit.Table.IsDataExistsInTable(newName, lastName, email));
        }
        [Test, Order(2)]
        public void BlockUser()
        {
            EditUserForm editUser = GoToEditUserForm();
            string email = editUser.Header.Text;
            UserPage userList = editUser.BlockUser();
            Assert.IsTrue(userList.Table.AllRowsOnTable.Any(e => e.Text.Contains(email) && e.Text.Contains("Tak")));            
        }
        [Test, Order(3)]
        public void UnBlockUser()
        {
            UserPage userPage = GoToUserPager();
            EditUserForm editUser = userPage.GoToBlockedUser();
            string email = editUser.Header.Text;
            UserPage userList = editUser.UnBlockUser();
            Assert.IsTrue(userPage.SuccessAlert.Displayed);
            Assert.IsTrue(userPage.SuccessAlert.Text.Contains("Dane zostały zapisane"));
            Assert.IsTrue(userList.Table.AllRowsOnTable.Any(e => e.Text.Contains(email) && e.Text.Contains("Nie")));
        }

        [Test, Order(4)]
        public void PasswordReset()
        {
            EditUserForm editUser = GoToEditUserForm();
            UserPage userPage = editUser.ResetPassword();
            Assert.IsTrue(userPage.SuccessAlert.Displayed);
            Assert.AreEqual(userPage.SuccessAlert.Text, "Wiadomość została wysłana");
        }
        [Test]
        public void EmptyNameField()
        {
            EditUserForm editUser = GoToEditUserForm();
            string lastName = RandomDataHelper.RandomString(6);
            editUser.ChangeFirstName(string.Empty);
            editUser.ChangeLastName(lastName);
            editUser.Button.Submit.Click();
            EditUserForm userPageAfterConfirmForm = new EditUserForm(manager);
            Assert.IsTrue(userPageAfterConfirmForm.ErrorField.IsDisplayEmptyNameErrorField);
            Assert.AreEqual(userPageAfterConfirmForm.ErrorField.EmptyNameErrorText, "Pole jest wymagane.");
        }
        [Test]
        public void EmptyLastNameField()
        {
            EditUserForm editUser = GoToEditUserForm();
            string name = RandomDataHelper.RandomString(6);
            editUser.ChangeFirstName(name);
            editUser.ChangeLastName(string.Empty);
            editUser.Button.Submit.Click();
            EditUserForm userPageAfterConfirmForm = new EditUserForm(manager);
            Assert.IsTrue(userPageAfterConfirmForm.ErrorField.IsDisplayEmptyLastNameErrorField);
            Assert.AreEqual(userPageAfterConfirmForm.ErrorField.EmptyLastNameErrorText, "Pole jest wymagane.");
        }
        private EditUserForm GoToEditUserForm()
        {
            LoginPage loginPage = new LoginPage(manager);
            HomePage homePage = loginPage.SetCorrectLoginData(login, password);
            UserPage userPage = homePage.GoTo<UserPage>(NavigationTo.ADMIN);
            EditUserForm editUser = userPage.GoToEditUser();

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
