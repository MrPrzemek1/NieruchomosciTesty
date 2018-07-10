using TestResources;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System.Linq;
using PageObjectModel.PageElemets;
using System;
using System.Collections.Generic;

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

        public IWebElement SuccessAlert => driverManager.FindWebElementAndWait(By.XPath(PageElementsLocators.CorrectPasswordResetMessageXpath));

        public AddingUserFormPage GoToAddNewUserForm()
        {
            AddButton.Click();
            return new AddingUserFormPage(driverManager);
        }
         
        public EditUserPage GoToEditUser()
        {
            UsersTable.AllRowsOnGrid.Where(e => e.Text.Contains("@") && !e.Text.Contains("@netrix.com.pl")).Select(e => e.FindElement(By.LinkText("Edytuj"))).ElementAt(RandomElement()).Click();
            return new EditUserPage(driverManager);
        }
        public string GetRandomExistingEmail()
        {
            return UsersTable.AllCellsOnGrid.Where(e=>e.Text.Contains("@")).ElementAt(RandomElement()).Text;
        }

        public EditUserPage GoToBlockedUser()
        {
            UsersTable.AllRowsOnGrid.Where(e => e.Text.Contains("Tak")).Select(e => e.FindWebElementAndWait(By.LinkText("Edytuj"))).FirstOrDefault().Click();
            return new EditUserPage(driverManager);
        }

        private int RandomElement()
        {
            Random random = new Random();
            Console.WriteLine("Wielkosc kolekcji to: {0}",UsersTable.AllRowsOnGrid.Count);
            int element = random.Next(3,UsersTable.AllRowsOnGrid.Count-1);
            Console.WriteLine("Wylosowany element to {0}",element);
            return element;
        }
    }
}