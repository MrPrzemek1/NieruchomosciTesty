using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using TestResources;

namespace PageObjectModel.PageElemets
{
    public class FormsFields : BasePage
    {
        public FormsFields(DriverManager manager) : base(manager)
        {
            PageFactory.InitElements(manager.Driver,this);
        }

        [FindsBy(How = How.Id, Using = PageElementsLocators.NameId)]
        public IWebElement Name { get; private set; }

        [FindsBy(How = How.Id, Using = PageElementsLocators.StreetId)]
        public IWebElement Street { get; private set; }

        [FindsBy(How = How.Id, Using = PageElementsLocators.PostCodeId)]
        public IWebElement PostCode { get; private set; }

        [FindsBy(How = How.Id, Using = PageElementsLocators.CityId)]
        public IWebElement City { get; private set; }

        [FindsBy(How = How.Id, Using = PageElementsLocators.StatusId)]
        public IWebElement Status { get; private set; }

        [FindsBy(How = How.Id, Using = PageElementsLocators.EmailId)]
        public IWebElement Email { get; private set; }

        [FindsBy(How = How.Id, Using = PageElementsLocators.FirstNameId)]
        public IWebElement FirstName { get; private set; }

        [FindsBy(How = How.Id, Using = PageElementsLocators.LastNameId)]
        public IWebElement LastName { get; private set; }

        [FindsBy(How = How.Id, Using = PageElementsLocators.LoginPasswordId)]
        public IWebElement Password { get; private set; }

        [FindsBy(How = How.Id, Using = PageElementsLocators.OfficePriceId)]
        public IWebElement Price { get; private set; }

        [FindsBy(How = How.Id, Using = PageElementsLocators.OfficeAreaId)]
        public IWebElement Area { get; private set; }
    }
}
