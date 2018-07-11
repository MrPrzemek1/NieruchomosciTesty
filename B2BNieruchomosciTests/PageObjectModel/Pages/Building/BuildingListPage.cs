using OpenQA.Selenium;
using PageObjectModel.PageElemets;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using System.Linq;
using TestResources;

namespace PageObjectModel.Pages.Building
{
    public class BuildingListPage : BasePage
    {
        public BuildingListPage(DriverManager manager) : base(manager)
        {
            buildingGrid = new BuildingGrid(manager);
            PageFactory.InitElements(driverManager.Driver, this);
        }

        [FindsBy(How = How.XPath, Using = PageElementsLocators.AddButtonXpath)]
        public IWebElement AddBuildingButton;

        public BuildingGrid buildingGrid { get; }

        public CreateBuilding GoToCreateBuildingForm()
        {
            AddBuildingButton.ClickIfElementIsClickable(driverManager.Driver);
            return new CreateBuilding(driverManager);
        }
        public bool IsCreationOfBuildingSuccesful(string name, string street, string city, string status)
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id(PageElementsLocators.BuildingGridId)));
            return buildingGrid.AllRowsOnGrid.Any(e => e.Text.Contains(name) && e.Text.Contains(street) && e.Text.Contains(city) && e.Text.Contains(status));
        }
    }
}
