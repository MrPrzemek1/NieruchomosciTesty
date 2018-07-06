using TestResources;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using TestResources;

namespace PageObjectModel
{
    public class UserListPage : BasePage
    {
        public UserListPage(DriverManager manager) : base(manager)
        {
            Header = new Header(manager);
            UsersTable = new UsersTable(manager);
            PageFactory.InitElements(manager.Driver, this);
        }

        public Header Header { get; }
        public UsersTable UsersTable { get; }
        [FindsBy(How = How.Id, Using = PageElementsLocators.Email)]
        public IWebElement Email { get; private set; }
        [FindsBy(How = How.Id, Using = PageElementsLocators.Name)]
        public IWebElement Name { get; private set; }
        [FindsBy(How = How.Id, Using = PageElementsLocators.LastName)]
        public IWebElement LastName { get; private set; }
        [FindsBy(How = How.XPath, Using = PageElementsLocators.AddButton)]
        public IWebElement AddButton { get; private set; }
        [FindsBy(How = How.XPath, Using = PageElementsLocators.ConfirmButton)]
        public IWebElement ConfirmButton { get; private set; }


        private UserListPage GoToAddNewUserForm()
        {
            AddButton.Click();
            return new UserListPage(driverManager);
        }
        public UserListPage AddNewUser(string email, string name, string sureName)
        {
            GoToAddNewUserForm();
            Email.SendKeys(email);
            Name.SendKeys(name);
            LastName.SendKeys(sureName);
            ConfirmButton.Click();
            return new UserListPage(driverManager);
        }
    }
}