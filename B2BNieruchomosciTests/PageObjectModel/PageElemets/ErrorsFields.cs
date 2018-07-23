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

        [FindsBy(How = How.XPath, Using = PageElementsLocators.EmptyFirstNameErrorXpath)]
        private IWebElement EmptyFirstNameError;
        public string EmptyFirstNameErrorText => EmptyFirstNameError.Text;
        public bool IsDisplayEmptyFirstNameErrorField => EmptyFirstNameError.Displayed;

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
        /// <summary>
        /// </summary>
        [FindsBy(How = How.XPath, Using = PageElementsLocators.EmptyStreetErrorFieldXpath)]
        private IWebElement EmptyStreetError;
        public string EmptyStreetErrorText => EmptyStreetError.Text;
        public bool IsDisplayEmptyStreetErrorField => EmptyStreetError.Displayed;

        [FindsBy(How = How.XPath, Using = PageElementsLocators.EmptyPostCodeErrorFieldXpath)]
        private IWebElement EmptyPostCodeError;
        public string EmptyPostCodeErrorText => EmptyPostCodeError.Text;
        public bool IsDisplayEmptyPostCodeErrorField => EmptyPostCodeError.Displayed;

        [FindsBy(How = How.XPath, Using = PageElementsLocators.EmptyCityFieldXpath)]
        private IWebElement EmptyCityError;
        public string EmptyCityErrorText => EmptyCityError.Text;
        public bool IsDisplayEmptyCityErrorField => EmptyCityError.Displayed;

        [FindsBy(How = How.XPath, Using = PageElementsLocators.UnselectedStatusXpath)]
        private IWebElement UnselectedStatusError;
        public string UnselectedStatusErrorText => UnselectedStatusError.Text;
        public bool IsDisplayUnselectedStatusErrorField => UnselectedStatusError.Displayed;
    }
}
