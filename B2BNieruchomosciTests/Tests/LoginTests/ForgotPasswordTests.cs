using NUnit.Framework;
using PageObjectModel;
using PageObjectModel.Pages;
using TestResources;

namespace Tests
{
    public class ForgotPasswordTests : BaseTest
    {
        public ForgotPasswordTests() { }
        public ForgotPasswordTests(DriverManager manager) : base(manager) { }

        [Test]
        public void CorrectResertPassword()
        {
            LoginPage loginPage = new LoginPage(manager);
            ForgotPasswordPage forgotPasswordPage = loginPage.GoToForgotPasswordPage();
            var correctPasswordReset = forgotPasswordPage.CorrectResertPassword();
            Assert.IsTrue(correctPasswordReset.CorrectPasswordResetText.Contains("Na podany adres, został wysłany"));
        }
        [Test]
        public void EmptyEmailField()
        {
            LoginPage loginPage = new LoginPage(manager);
            ForgotPasswordPage forgotPasswordPage = loginPage.GoToForgotPasswordPage();
            forgotPasswordPage.ConfirmButton.Click();
            ForgotPasswordPage pageAfterConfirmForm = new ForgotPasswordPage(manager);

            Assert.IsTrue(pageAfterConfirmForm.ErrorField.IsDisplayEmarilErrorField);
            Assert.AreEqual(pageAfterConfirmForm.ErrorField.EmptyEmailErrorText, "Pole jest wymagane.");
        }
        [Test]
        public void WrongEmail()
        {
            LoginPage loginPage = new LoginPage(manager);
            ForgotPasswordPage forgotPasswordPage = loginPage.GoToForgotPasswordPage();
            forgotPasswordPage.Email.SendKeys("lalala");
            forgotPasswordPage.ConfirmButton.Click();
            ForgotPasswordPage pageAfterConfirmForm = new ForgotPasswordPage(manager);

            Assert.IsTrue(pageAfterConfirmForm.ErrorField.IsDisplayEmarilErrorField);
            Assert.AreEqual(pageAfterConfirmForm.ErrorField.EmptyEmailErrorText, "Adres email jest niepoprawny.");
        }
    }
}
