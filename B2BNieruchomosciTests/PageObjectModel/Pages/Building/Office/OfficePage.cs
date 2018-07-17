using OpenQA.Selenium;
using PageObjectModel.PageElemets;
using SeleniumExtras.WaitHelpers;
using System.Linq;
using TestResources;

namespace PageObjectModel.Pages.Building
{
    public class OfficePage : BasePage
    {
        public OfficePage(DriverManager manager) : base(manager)
        {
            Button = new Buttons(manager);
            Table = new Tables(manager);
        }

        public Buttons Button { get; }
        public Tables Table { get; }

        public bool ValueExistsInTable(string name, int price, int area)
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id(PageElementsLocators.BaseTableClass)));
            return Table.AllRowsOnTable.Any(e => e.Text.Contains(name) && e.Text.Contains(price.ToString()) && e.Text.Contains(area.ToString()));
        }

    }
}