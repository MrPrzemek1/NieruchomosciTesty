using OpenQA.Selenium;
using PageObjectModel.PageElemets;
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
        }
        public Tables Table { get; }
        public Buttons Button { get; }


        public BuildingForm GoToEditBuilding()
        {
            WaitOnTableLoad();
            Table.AllRowsOnTable.Where(e => !string.IsNullOrEmpty(e.Text)).Select(e => e.FindElement(By.LinkText("Edytuj"))).ElementAt(Table.RandomElement()).Click();
            return new BuildingForm(driverManager);
        }
    }
}
