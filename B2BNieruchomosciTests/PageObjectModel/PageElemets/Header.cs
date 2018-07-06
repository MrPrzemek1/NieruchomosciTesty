using TestResources;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;


namespace PageObjectModel
{
    public class Header : BasePage
    {
        public Header(DriverManager manager) : base(manager)
        {
            PageFactory.InitElements(manager.Driver, this);
        }

        [FindsBy(How = How.ClassName, Using = PageElementsLocators.Header)]
        public IWebElement header;

        public bool IsDisplay => header.Displayed;
        public string Text => header.Text;
    }
}