using OpenQA.Selenium;
using PageObjectModel.PageElemets;
using SeleniumExtras.PageObjects;
using TestResources;

namespace PageObjectModel.Pages
{
    public class ForgotPasswordPage : BasePage
    {
        public ForgotPasswordPage(DriverManager manager) : base(manager)
        {
            Header = new Headers(manager);
            ErrorField = new ErrorsFields(manager);
            PageFactory.InitElements(manager.Driver,this);
        }
        public Headers Header { get; }
        public ErrorsFields ErrorField;

        [FindsBy(How = How.Id, Using = PageElementsLocators.Email)]
        public IWebElement Email;
        [FindsBy(How = How.XPath, Using = PageElementsLocators.ConfirmButton)]
        public IWebElement ConfirmButton;
        [FindsBy(How = How.ClassName, Using = PageElementsLocators.CorrectPasswordReset)]
        private IWebElement CorrectPasswordReset;

        public string CorrectPasswordResetText => CorrectPasswordReset.Text;

        public ForgotPasswordPage CorrectResertPassword()
        {
            Email.SendKeys(RandomDataHelper.RandomString(7)+"@test.pl");
            ConfirmButton.Click();
            return new ForgotPasswordPage(driverManager);
        }
    }
}
