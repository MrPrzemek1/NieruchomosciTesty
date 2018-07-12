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
            Field = new FormsFields(manager);
            Button = new Buttons(manager);
            Header = new Headers(manager);
            ErrorField = new ErrorsFields(manager);
            PageFactory.InitElements(manager.Driver,this);
        }

        public Headers Header { get; }

        public ErrorsFields ErrorField { get; }

        public Buttons Button { get; }

        public FormsFields Field { get; }

        [FindsBy(How = How.ClassName, Using = PageElementsLocators.CorrectPasswordResetStatementClass)]
        private IWebElement CorrectPasswordResetStatemenet;

        public string CorrectPasswordResetText => CorrectPasswordResetStatemenet.Text;

        public ForgotPasswordPage CorrectResertPassword()
        {
            Field.Email.SendKeys(RandomDataHelper.RandomString(7)+"@test.pl");
            Button.Submit.Click();
            return new ForgotPasswordPage(driverManager);
        }
    }
}
