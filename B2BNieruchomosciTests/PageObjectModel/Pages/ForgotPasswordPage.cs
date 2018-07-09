using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestResources;

namespace PageObjectModel.Pages
{
    public class ForgotPasswordPage : BasePage
    {
        public ForgotPasswordPage(DriverManager manager) : base(manager)
        {
            PageFactory.InitElements(manager.Driver,this);
        }
        public Header header;
        [FindsBy(How = How.Id, Using = PageElementsLocators.Email)]
        private IWebElement Email;
        [FindsBy(How = How.Id, Using = PageElementsLocators.ConfirmButton)]
        private IWebElement ConfirmButton;
        [FindsBy(How = How.ClassName, Using = PageElementsLocators.CorrectPasswordReset)]
        private IWebElement CorrectPasswordReset;

        public string CorrectPasswordResetText => CorrectPasswordReset.Text;

        public ForgotPasswordPage SendPassword()
        {
            Email.SendKeys(RandomDataHelper.RandomString(7)+"@test.pl");
            ConfirmButton.Click();
            return new ForgotPasswordPage(driverManager);
        }
    }
}
