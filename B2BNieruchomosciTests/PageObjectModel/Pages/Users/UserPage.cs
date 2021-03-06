﻿using TestResources;
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

        public UserForm GoToEditUser()
        {
            WaitOnTableLoad();
            var list = Table.AllRowsOnTable.Where(e => (e.Text.Contains("@")) && (e.Text.Contains("@netrix.com.pl") == false) && (e.Text.Contains("Tak") == false));
            list.Select(e => e.FindElement(By.LinkText("Edytuj"))).ElementAt(Table.RandomElement()).Click();
            return new UserForm(driverManager);
        }

        public UserForm GoToBlockedUser()
        {
            WaitOnTableLoad();
            Table.AllRowsOnTable.Where(e => e.Text.Contains("Tak")).Select(e => e.FindWebElementAndWait(By.LinkText("Edytuj"))).FirstOrDefault().Click();
            return new UserForm(driverManager);
        }

        public UserForm GoToUnBlockUser()
        {
            WaitOnTableLoad();
            Table.AllRowsOnTable.Where(e => e.Text.Contains("Nie")).Select(e => e.FindWebElementAndWait(By.LinkText("Edytuj"))).FirstOrDefault().Click();
            return new UserForm(driverManager);
        }
    }
}