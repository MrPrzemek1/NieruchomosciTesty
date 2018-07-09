using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        [FindsBy(How = How.XPath, Using = PageElementsLocators.EmptyPasswordErrorField)]
        private IWebElement EmptyPasswordError;
        public string EmptyPasswordErrorText => EmptyPasswordError.Text;

        [FindsBy(How = How.XPath, Using = PageElementsLocators.EmptyEmailErrorField)]
        private IWebElement EmptyEmailError;
        public string EmptyEmailErrorText => EmptyEmailError.Text;
    }
}
