using System;
using OpenQA.Selenium;
using PageObjectModel.PageElemets;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using TestResources;

namespace PageObjectModel
{
    public class EditUserPage : BasePage
    {
        public EditUserPage(DriverManager manager) : base(manager)
        {
            Header = new Headers(manager);
            ErrorField = new ErrorsFields(manager);
            PageFactory.InitElements(manager.Driver,this);
        }
        public Headers Header { get; }
        public ErrorsFields ErrorField { get; }
        [FindsBy(How = How.Id, Using = PageElementsLocators.NameId)]
        private IWebElement Name;
        [FindsBy(How = How.Id, Using = PageElementsLocators.LastNameId)]
        private IWebElement LastName;
        [FindsBy(How = How.XPath, Using = PageElementsLocators.ConfirmButtonXpath)]
        public IWebElement ConfirmButton;

        public void ChangeName(string name)
        {
            Name.Clear();
            Name.SendKeys(name);
        }

        public void ChangeLastName(string lastName)
        {
            LastName.Clear();
            LastName.SendKeys(lastName);
        }
        public UserListPage ConfirmEditUser()
        {
            ConfirmButton.Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("users-grid")));
            return new UserListPage(driverManager);
        }
    }
}