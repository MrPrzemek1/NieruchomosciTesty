using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using TestResources;

namespace PageObjectModel.PageElemets
{
    public class BuildingGrid : BaseGrid
    {
        public BuildingGrid(DriverManager manager) : base(manager)
        {
            PageFactory.InitElements(driverManager.Driver, this);
        }

        [FindsBy(How = How.Id, Using = PageElementsLocators.BuildingGridId)]
        public override IWebElement Table { get; set; }
    }
}
