using TestResources;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using TestResources;

namespace PageObjectModel
{
    public class UsersTable : BasePage
    {
        public UsersTable(DriverManager manager) : base(manager)
        {
            PageFactory.InitElements(driverManager.Driver, this);
        }
    
        [FindsBy(How = How.Id, Using = PageElementsLocators.UsersTable)]
        private IWebElement UsersGrid { get; set; }

        IList<IWebElement> AllCellsOnGrid => UsersGrid.FindElements(By.TagName("td"));

        public bool CheckCorrectAdd(string name,string lastName,string email)
        {
            DriverHelper.WaitUntil(driverManager.Driver,ExpectedConditions.ElementIsVisible(By.TagName("td")));
            return AllCellsOnGrid.Any(e => e.Text.Equals(name) && e.Text.Equals(lastName)&& e.Text.Equals(email));
        }
    }
}