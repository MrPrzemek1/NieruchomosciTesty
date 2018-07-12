using TestResources;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System.Linq;
using PageObjectModel.PageElemets;
using System;

namespace PageObjectModel
{
    public class UserPage : BasePage
    {
        public UserPage(DriverManager manager) : base(manager)
        {
            Header = new Headers(manager);
            ErrorField = new ErrorsFields(manager);
            PageFactory.InitElements(manager.Driver, this);
        }
        public Buttons Buttons { get; }
        public Headers Header { get; }
        public EditUserForm EditUser { get; }
        public ErrorsFields ErrorField { get; }
        public Tables Table { get; }

        public IWebElement SuccessAlert => driverManager.FindWebElementAndWait(By.XPath(PageElementsLocators.CorrectPasswordResetMessageXpath));

        public AddUserForm GoToAddNewUserForm()
        {
            Buttons.Add.Click();
            return new AddUserForm(driverManager);
        }
         
        public EditUserForm GoToEditUser()
        {
            Table.AllRowsOnTable.Where(e => e.Text.Contains("@") && !e.Text.Contains("@netrix.com.pl")).Select(e => e.FindElement(By.LinkText("Edytuj"))).ElementAt(RandomElement()).Click();
            return new EditUserForm(driverManager);
        }
        public string GetRandomExistingEmail()
        {
            return Table.AllCellsOnTable.Where(e=>e.Text.Contains("@")).ElementAt(RandomElement()).Text;
        }

        public EditUserForm GoToBlockedUser()
        {
            Table.AllRowsOnTable.Where(e => e.Text.Contains("Tak")).Select(e => e.FindWebElementAndWait(By.LinkText("Edytuj"))).FirstOrDefault().Click();
            return new EditUserForm(driverManager);
        }

        private int RandomElement()
        {
            Random random = new Random();
            Console.WriteLine("Wielkosc kolekcji to: {0}",Table.AllRowsOnTable.Count);
            int element = random.Next(3,Table.AllRowsOnTable.Count);
            Console.WriteLine("Wylosowany element to {0}",element);
            return element;
        }
    }
}