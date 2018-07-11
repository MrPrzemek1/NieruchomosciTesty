using TestResources;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using System.Collections.Generic;
using System.Linq;

namespace PageObjectModel
{
    public class UsersGrid : BaseGrid
    {
        public UsersGrid(DriverManager manager) : base(manager)
        {
            PageFactory.InitElements(driverManager.Driver, this);
        }
    
        [FindsBy(How = How.Id, Using = PageElementsLocators.UsersTableId)]
        public override IWebElement Table { get; set; }

        public bool GridContainsData(string name,string lastName,string email)
        {
            DriverHelper.WaitUntil(driverManager.Driver,ExpectedConditions.ElementIsVisible(By.TagName("tr")));
            return AllRowsOnGrid.Any(e => e.Text.Contains(name) && e.Text.Contains(lastName) && e.Text.Contains(email));
        }
    }
}