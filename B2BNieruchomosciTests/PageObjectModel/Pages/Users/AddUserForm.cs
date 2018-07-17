using OpenQA.Selenium;
using PageObjectModel.PageElemets;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using TestResources;

namespace PageObjectModel
{
    public class AddUserForm : BasePage
    {
        public AddUserForm(DriverManager manager) : base(manager)
        {
            Button = new Buttons(manager);
            Field = new FormsFields(manager);
            ErrorsField = new ErrorsFields(manager);
            PageFactory.InitElements(manager.Driver, this);
        }

        public ErrorsFields ErrorsField { get; }
        public Buttons Button { get; }
        public FormsFields Field { get; }

        public void SetNewUserData(string email, string name, string lastName)
        {
            Field.Email.SendKeys(email);
            Field.FirstName.SendKeys(name);
            Field.LastName.SendKeys(lastName);
        }
        public UserPage SubmitAddUserForm()
        {
            Button.Submit.Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName(PageElementsLocators.BaseTableClass)));
            return new UserPage(driverManager);
        }
        public AddUserForm ConfirmationIncorrectForm()
        {
            Button.Submit.Click();
            return new AddUserForm(driverManager);
        }
    }
}