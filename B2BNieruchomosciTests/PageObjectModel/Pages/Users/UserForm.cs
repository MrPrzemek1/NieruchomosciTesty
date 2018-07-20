using PageObjectModel.Pages;
using TestResources;

namespace PageObjectModel
{
    public class UserForm : BaseForm
    {
        public UserForm(DriverManager manager) : base(manager) { }

        public void SetNewUserData(string email, string name, string lastName)
        {
            Field.Email.SendKeys(email);
            Field.FirstName.SendKeys(name);
            Field.LastName.SendKeys(lastName);
        }

        public void EditUser(string name, string lastName)
        {
            Field.FirstName.ClearAndSendKeys(name);
            Field.LastName.ClearAndSendKeys(lastName);
        }

        public UserPage SubmitUserForm()
        {
            Button.Submit.Click();
            WaitOnTableLoad();
            return new UserPage(driverManager);
        }
        public UserForm ConfirmationIncorrectForm()
        {
            Button.Submit.Click();
            return new UserForm(driverManager);
        }
        public UserPage BlockUser()
        {
            Button.BlockUser.ClickIfElementIsClickable(driverManager.Driver);
            WaitOnTableLoad();
            return new UserPage(driverManager);
        }
        public UserPage UnBlockUser()
        {
            Button.UnBlockUser.ClickIfElementIsClickable(driverManager.Driver);
            WaitOnTableLoad();
            return new UserPage(driverManager);
        }
        public UserPage ResetPassword()
        {
            Button.ResetPassword.ClickIfElementIsClickable(driverManager.Driver);
            WaitOnTableLoad();
            return new UserPage(driverManager);
        }
    }
}