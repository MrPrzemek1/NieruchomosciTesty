using TestResources;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using TestResources;
using System.Linq;
using PageObjectModel.PageElemets;
using System;

namespace PageObjectModel
{
    public class UserListPage : BasePage
    {
        public UserListPage(DriverManager manager) : base(manager)
        {
            Header = new Headers(manager);
            UsersTable = new UsersTable(manager);
            ErrorField = new ErrorsFields(manager);
            PageFactory.InitElements(manager.Driver, this);
        }

        public Headers Header { get; }
        public UsersTable UsersTable { get; }
        public EditUserPage EditUser { get; }
        public ErrorsFields ErrorField { get; }
        
        [FindsBy(How = How.XPath, Using = PageElementsLocators.AddButtonXpath)]
        public IWebElement AddButton { get; private set; }

        public AddingUserFormPage GoToAddNewUserForm()
        {
            AddButton.Click();
            return new AddingUserFormPage(driverManager);
        }
         
        public EditUserPage GoToEditUser()
        {
            UsersTable.AllRowsOnGrid.Where(e => e.Text.Contains("7MPCM@test.pl")).Select(e => e.FindElement(By.LinkText("Edytuj"))).First().Click();
            return new EditUserPage(driverManager);
        }
        public string GetRandomExistingEmail()
        {
            Random random = new Random();
            int element = random.Next(1, 10);
            return UsersTable.AllCellsOnGrid.Where(e=>e.Text.Contains("@")).ElementAt(element).Text;
        }
    }
}