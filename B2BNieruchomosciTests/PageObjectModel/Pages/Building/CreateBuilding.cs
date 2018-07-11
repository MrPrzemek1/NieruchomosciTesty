using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using TestResources;

namespace PageObjectModel.Pages.Building
{
    public class CreateBuilding
    {
        [FindsBy(How = How.XPath, Using = PageElementsLocators.NameId)]
        public IWebElement Name { get; private set; }
        [FindsBy(How = How.XPath, Using = PageElementsLocators.StreetId)]
        public IWebElement Street { get; private set; }
        [FindsBy(How = How.XPath, Using = PageElementsLocators.PostCodeId)]
        public IWebElement PostCode { get; private set; }
        [FindsBy(How = How.XPath, Using = PageElementsLocators.CityId)]
        public IWebElement City { get; private set; }
        [FindsBy(How = How.XPath, Using = PageElementsLocators.SubmitButtonXpath)]
        public IWebElement Status { get; private set; }

        public BuildingListPage CreateNewBuilding(string name, string street, string postCode, string city)
        {
            CreateBuilding create = new CreateBuilding();
            create.Name.SendKeys(name);
            create.Street.SendKeys(street);
            create.PostCode.SendKeys(postCode);
            create.City.SendKeys(city);
            create.Status;
            create.
        }
    }
}