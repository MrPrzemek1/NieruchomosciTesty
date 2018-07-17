using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;
using System;
using TestResources;
using OpenQA.Selenium.Support.UI;
using PageObjectModel.PageElemets;
using System.Linq;

namespace PageObjectModel
{
    public class BasePage
    {
        public DriverManager driverManager;
        protected WebDriverWait wait;

        public BasePage(DriverManager manager)
        {
            driverManager = manager;
            wait = new WebDriverWait(manager.Driver, TimeSpan.FromSeconds(20));
            wait.PollingInterval = TimeSpan.FromMilliseconds(100);
            PageFactory.InitElements(manager.Driver,this);
        }
        protected void WaitOnTableLoad()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName(PageElementsLocators.BaseTableClass)));
        }

        public T GoTo<T>(string linkText = null)
        { 
            Tables table = new Tables(driverManager);
            Buttons button = new Buttons(driverManager);

            if (!string.IsNullOrEmpty(linkText))
            {
                table.AllRowsOnTable.Where(e => e.Text.Contains("Aktywny")).Select(e => e.FindElement(By.LinkText(linkText))).ElementAt(Table.RandomElement()).Click();
            }
            else
            {
                button.Add.ClickIfElementIsClickable(driverManager.Driver);
            }

            return (T)Activator.CreateInstance(typeof(T), driverManager);
        }
    }
}
