using OpenQA.Selenium;
using PageObjectModel.PageElemets;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using TestResources;

namespace PageObjectModel
{
    public class AddingUserFormPage : BasePage
    {
        public AddingUserFormPage(DriverManager manager) : base(manager)
        {
            ErrorsField = new ErrorsFields(manager);
            PageFactory.InitElements(manager.Driver, this);
        }

        public ErrorsFields ErrorsField { get; }
        [FindsBy(How = How.Id, Using = PageElementsLocators.EmailId)]
        public IWebElement Email { get; private set; }
        [FindsBy(How = How.Id, Using = PageElementsLocators.NameId)]
        public IWebElement Name { get; private set; }
        [FindsBy(How = How.Id, Using = PageElementsLocators.LastNameId)]
        public IWebElement LastName { get; private set; }
        [FindsBy(How = How.XPath, Using = PageElementsLocators.ConfirmButtonXpath)]
        public IWebElement ConfirmButton { get; private set; }

        public void SetNewUserData(string email, string name, string lastName)
        {
            Email.SendKeys(email);
            Name.SendKeys(name);
            LastName.SendKeys(lastName);
        }
        public UserListPage ConfirmationForm()
        {
            ConfirmButton.Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("users-grid")));
            return new UserListPage(driverManager);
        }
        public AddingUserFormPage ConfirmationIncorrectForm()
        {
            ConfirmButton.Click();
            return new AddingUserFormPage(driverManager);
        }
    }
}