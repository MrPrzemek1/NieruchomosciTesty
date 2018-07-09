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
        [FindsBy(How = How.XPath, Using = PageElementsLocators.WorngDataOrPasswordErrorFieldXpath)]
        private IWebElement WrongDataOrPassworError;
        public string WrongDataOrPassworErrorText => WrongDataOrPassworError.Text;
        public bool IsDisplayWrongDataOrPassworErrorField => WrongDataOrPassworError.Displayed;

        [FindsBy(How = How.XPath, Using = PageElementsLocators.EmptyNameErrorXpath)]
        private IWebElement EmptyNameError;
        public string EmptyNameErrorText => EmptyNameError.Text;
        public bool IsDisplayEmptyNameErrorField => EmptyNameError.Displayed;

        [FindsBy(How = How.XPath, Using = PageElementsLocators.EmptyLastNameErrorXpath)]
        private IWebElement EmptyLastNameError;
        public string EmptyLastNameErrorText => EmptyLastNameError.Text;
        public bool IsDisplayEmptyLastNameErrorField => EmptyLastNameError.Displayed;

        [FindsBy(How = How.XPath, Using = PageElementsLocators.EmptyPasswordErrorFieldXpath)]
        private IWebElement EmptyPasswordError;
        public string EmptyPasswordErrorText => EmptyPasswordError.Text;
        public bool IsDisplayEmptyPasswordErrorField => EmptyPasswordError.Displayed;

        [FindsBy(How = How.XPath, Using = PageElementsLocators.EmptyEmailErrorFieldXpath)]
        private IWebElement EmptyEmailError;
        public string EmptyEmailErrorText => EmptyEmailError.Text;
        public bool IsDisplayEmarilErrorField => EmptyEmailError.Displayed;

        [FindsBy(How = How.XPath, Using = PageElementsLocators.ExistingEmailErrorFieldXpath)]
        private IWebElement ExistingEmailErrorField;
        public string ExistingEmailErrorFieldText => ExistingEmailErrorField.Text;
        public bool IsDisplayExistingEmailErrorField => ExistingEmailErrorField.Displayed;

    }
}
