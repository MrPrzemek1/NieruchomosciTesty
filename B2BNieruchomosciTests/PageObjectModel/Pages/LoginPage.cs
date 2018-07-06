using B2BNieruchomosciTests;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using TestResources;

namespace PageObjectModel
{
    public class LoginPage:BasePage
    {
        public LoginPage(DriverManager manager):base(manager)
        {
            PageFactory.InitElements(manager.Driver, this);
        }

        [FindsBy(How = How.Id, Using = PageElementsLocators.Email)]
        private IWebElement Login;
        [FindsBy(How = How.Id, Using = PageElementsLocators.LoginPassword)]
        private IWebElement Password;
        [FindsBy(How = How.XPath, Using = PageElementsLocators.LoginButton)]
        private IWebElement LoginButton;

        public HomePage SetLogin(string login,string password)
        {
            Login.SendKeys(login);
            Password.SendKeys(password);
            LoginButton.Click();
            return new HomePage(driverManager);
        }
    }
}
