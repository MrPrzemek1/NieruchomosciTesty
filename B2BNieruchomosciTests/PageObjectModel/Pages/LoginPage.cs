using TestResources;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using PageObjectModel.PageElemets;
using PageObjectModel.Pages;

namespace PageObjectModel
{
    public class LoginPage:BasePage
    {
        public LoginPage(DriverManager manager):base(manager)
        {
            ErrorFields = new ErrorsFields(driverManager);
            PageFactory.InitElements(manager.Driver, this);
        }
        public ErrorsFields ErrorFields { get; }

        [FindsBy(How = How.Id, Using = PageElementsLocators.Email)]
        private IWebElement Login;
        [FindsBy(How = How.Id, Using = PageElementsLocators.LoginPassword)]
        private IWebElement Password;
        [FindsBy(How = How.XPath, Using = PageElementsLocators.LoginButton)]
        private IWebElement LoginButton;
        [FindsBy(How=How.LinkText, Using =PageElementsLocators.ForgotPasswordLink)]
        private IWebElement ForgotPasswordLink;

        public HomePage SetCorrectLoginData(string login,string password)
        {
            Login.SendKeys(login);
            Password.SendKeys(password);
            LoginButton.Click();
            return new HomePage(driverManager);    
        }
        public LoginPage SetLoginData(string login, string password)
        {
            Login.SendKeys(login);
            Password.SendKeys(password);
            LoginButton.Click();
            return new LoginPage(driverManager);
        }
        public ForgotPasswordPage GoToForgotPasswordPage()
        {
            ForgotPasswordLink.Click();
            return new ForgotPasswordPage(driverManager);
        }
    }
}
