using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using TestResources;

namespace PageObjectModel.Pages.Building
{
    public class CreateBuilding : BasePage
    {
        public CreateBuilding(DriverManager manager) : base(manager)
        {
            PageFactory.InitElements(driverManager.Driver, this);
        }

        [FindsBy(How = How.Id, Using = PageElementsLocators.BuildingNameId)]
        public IWebElement Name { get; private set; }
        [FindsBy(How = How.Id, Using = PageElementsLocators.StreetId)]
        public IWebElement Street { get; private set; }
        [FindsBy(How = How.Id, Using = PageElementsLocators.PostCodeId)]
        public IWebElement PostCode { get; private set; }
        [FindsBy(How = How.Id, Using = PageElementsLocators.CityId)]
        public IWebElement City { get; private set; }
        [FindsBy(How = How.Id, Using = PageElementsLocators.StatusId)]
        public IWebElement Status { get; private set; }
        [FindsBy(How = How.XPath, Using = PageElementsLocators.SubmitButtonXpath)]
        public IWebElement SubmitButton { get; private set; }

        public BuildingListPage CreateNewBuilding(string name, string street, int postCode, string city, string status)
        {
            SelectElement selectStatus = new SelectElement(Status);
            Name.SendKeys(name);
            Street.SendKeys(street);
            PostCode.SendKeys(postCode.ToString());
            City.SendKeys(city);
            selectStatus.SelectByText(status);
            SubmitButton.ClickIfElementIsClickable(driverManager.Driver);
            return new BuildingListPage(driverManager);
        }
    }
}