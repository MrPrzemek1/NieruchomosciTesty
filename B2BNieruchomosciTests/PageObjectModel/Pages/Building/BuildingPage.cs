using PageObjectModel.PageElemets;
using SeleniumExtras.PageObjects;
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
    }
}
