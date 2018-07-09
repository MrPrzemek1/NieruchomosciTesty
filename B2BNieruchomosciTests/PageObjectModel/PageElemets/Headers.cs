using TestResources;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;


namespace PageObjectModel
{
    public class Headers : BasePage
    {
        public Headers(DriverManager manager) : base(manager)
        {
            PageFactory.InitElements(manager.Driver, this);
        }

        [FindsBy(How = How.ClassName, Using = PageElementsLocators.Header)]
        private IWebElement Header { get; set; }

        public bool IsDisplay => Header.Displayed;
        public string Text => Header.Text;
    }
}