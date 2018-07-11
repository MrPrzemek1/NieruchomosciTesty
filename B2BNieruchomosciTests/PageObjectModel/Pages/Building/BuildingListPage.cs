using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using TestResources;

namespace PageObjectModel.Pages.Building
{
    class BuildingListPage : BasePage
    {
        public BuildingListPage(DriverManager manager) : base(manager) { }

        [FindsBy(How = How.XPath, Using = PageElementsLocators.AddButtonXpath)]
        public IWebElement AddBuildingButton;

    }
}
