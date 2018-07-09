using TestResources;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using System.Collections.Generic;
using System.Linq;

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

        IList<IWebElement> AllCellsOnGrid => UsersGrid.FindElements(By.TagName("tr"));

        public bool CheckCorrectAdd(string name,string lastName,string email)
        {
            DriverHelper.WaitUntil(driverManager.Driver,ExpectedConditions.ElementIsVisible(By.TagName("tr")));
            return AllCellsOnGrid.Any(e => e.Text.Contains(name) && e.Text.Contains(lastName) && e.Text.Contains(email));
        }
    }
}