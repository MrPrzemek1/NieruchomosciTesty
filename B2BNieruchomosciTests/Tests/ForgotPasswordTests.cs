using NUnit.Framework;
using PageObjectModel;
using PageObjectModel.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestResources;

namespace Tests
{
    public class ForgotPasswordTests : BaseTest
    {
        public ForgotPasswordTests() { }
        public ForgotPasswordTests(DriverManager manager) : base(manager) { }

        [Test]
        public void TestTest()
        {
            LoginPage loginPage = new LoginPage(manager);
            ForgotPasswordPage forgotPasswordPage = loginPage.GoToForgotPasswordPage();
            var correctPasswordReset = forgotPasswordPage.SendPassword();
            Assert.IsTrue(correctPasswordReset.CorrectPasswordResetText.Contains("Na podany adres, został wysłany"));
        }
    }
}
