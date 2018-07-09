using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using TestResources;

namespace PageObjectModel.PageElemets
{
    public class ErrorsFields : BasePage
    {
        public ErrorsFields(DriverManager manager) : base(manager)
        {
            PageFactory.InitElements(manager.Driver, this);
        }
        [FindsBy(How = How.XPath, Using = PageElementsLocators.WorngDataOrPasswordErrorField)]
        private IWebElement WrongDataOrPassworError;
        public string WrongDataOrPassworErrorText => WrongDataOrPassworError.Text;
        public bool IsDisplayWrongDataOrPassworError => WrongDataOrPassworError.Displayed;

        [FindsBy(How = How.XPath, Using = PageElementsLocators.EmptyPasswordErrorField)]
        private IWebElement EmptyPasswordError;
        public string EmptyPasswordErrorText => EmptyPasswordError.Text;
        public bool IsDisplayEmptyPasswordError => EmptyPasswordError.Displayed;

        [FindsBy(How = How.XPath, Using = PageElementsLocators.EmptyEmailErrorField)]
        private IWebElement EmptyEmailError;
        public string EmptyEmailErrorText => EmptyEmailError.Text;
        public bool IsDisplayEmarilErrorText => EmptyEmailError.Displayed;
    }
}
