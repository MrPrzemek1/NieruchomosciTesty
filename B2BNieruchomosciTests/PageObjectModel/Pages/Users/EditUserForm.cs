using OpenQA.Selenium;
using PageObjectModel.PageElemets;
using SeleniumExtras.PageObjects;
using TestResources;

namespace PageObjectModel
{
    public class EditUserForm : BasePage
    {
        public EditUserForm(DriverManager manager) : base(manager)
        {
            Button = new Buttons(manager);
            Field = new FormsFields(manager);
            Header = new Headers(manager);
            ErrorField = new ErrorsFields(manager);
            PageFactory.InitElements(manager.Driver,this);
        }
        public Headers Header { get; }
        public ErrorsFields ErrorField { get; }
        public FormsFields Field { get; }
        public Buttons Button { get; }
        
        public void ChangeName(string name)
        {
            Field.FirstName.Clear();
            Field.FirstName.SendKeys(name);
        }
        public void ChangeLastName(string lastName)
        {
            Field.LastName.Clear();
            Field.LastName.SendKeys(lastName);
        }
        public UserPage SubmitEditUser()
        {
            Button.Submit.Click();
            return new UserPage(driverManager);
        }
        public UserPage BlockUser()
        {
            Button.BlockUser.Click();
            return new UserPage(driverManager);
        }
        public UserPage UnBlockUser()
        {
            Button.UnBlockUser.Click();
            return new UserPage(driverManager);
        }
        public UserPage ResetPassword()
        {
            Button.ResetPassword.Click();
            return new UserPage(driverManager);
        }
    }
}