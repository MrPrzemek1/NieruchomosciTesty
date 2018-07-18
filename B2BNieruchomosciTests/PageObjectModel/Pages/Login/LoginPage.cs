using TestResources;
using PageObjectModel.PageElemets;
using PageObjectModel.Pages;

namespace PageObjectModel
{
    public class LoginPage:BasePage
    {
        public LoginPage(DriverManager manager):base(manager)
        {
            Button = new Buttons(manager);
            Field = new FormsFields(manager);
            ErrorFields = new ErrorsFields(driverManager);
        }
        public ErrorsFields ErrorFields { get; }
        public Buttons Button { get; }
        public FormsFields Field { get; }

        public HomePage SetCorrectLoginData(string login,string password)
        {
            Field.Email.SendKeys(login);
            Field.Password.SendKeys(password);
            Button.Submit.Click();
            return new HomePage(driverManager);    
        }
        public LoginPage SetLoginData(string login, string password)
        {
            Field.Email.SendKeys(login);
            Field.Password.SendKeys(password);
            Button.Submit.Click();
            return new LoginPage(driverManager);
        }
        public ForgotPasswordPage GoToForgotPasswordPage()
        {
            Button.ForgotPassword.Click();
            return new ForgotPasswordPage(driverManager);
        }
    }
}
