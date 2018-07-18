using TestResources;
using OpenQA.Selenium;
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
            Buttons = new Buttons(manager);
            Table = new Tables(manager);
        }
        public Buttons Buttons { get; }
        public Headers Header { get; }
        public ErrorsFields ErrorField { get; }
        public Tables Table { get; }

        public IWebElement SuccessAlert => driverManager.FindWebElementAndWait(By.XPath(PageElementsLocators.CorrectPasswordResetMessageXpath));

        public EditUserForm GoToEditUser()
        {
            WaitOnTableLoad();
            Table.AllRowsOnTable.Where(e => e.Text.Contains("@") && !(e.Text.Contains("@netrix.com.pl"))&& !(e.Text.Contains("TAK"))).Select(e => e.FindElement(By.LinkText("Edytuj"))).ElementAt(Table.RandomElement()).Click();
            return new EditUserForm(driverManager);
        }

        public EditUserForm GoToBlockedUser()
        {
            WaitOnTableLoad();
            Table.AllRowsOnTable.Where(e => e.Text.Contains("Tak")).Select(e => e.FindWebElementAndWait(By.LinkText("Edytuj"))).FirstOrDefault().Click();
            return new EditUserForm(driverManager);
        }

        public EditUserForm GoToUnBlockUser()
        {
            throw new NotImplementedException();
        }
    }
}