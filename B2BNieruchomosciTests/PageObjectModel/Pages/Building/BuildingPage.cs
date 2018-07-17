using OpenQA.Selenium;
using PageObjectModel.PageElemets;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using System.Linq;
using TestResources;

namespace PageObjectModel.Pages.Building
{
    public class BuildingPage : BasePage
    {
        public BuildingPage(DriverManager manager) : base(manager)
        {
            Table = new Tables(manager);
            Button = new Buttons(manager);
            PageFactory.InitElements(driverManager.Driver, this);
        }

        public Tables Table { get; }
        public Buttons Button { get; }

        public bool ValueExistsInTable(string name, string street, string city, string status)
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id(PageElementsLocators.BaseTableClass)));
            return Table.AllRowsOnTable.Any(e => e.Text.Contains(name) && e.Text.Contains(street) && e.Text.Contains(city) && e.Text.Contains(status));
        }
    }
}
