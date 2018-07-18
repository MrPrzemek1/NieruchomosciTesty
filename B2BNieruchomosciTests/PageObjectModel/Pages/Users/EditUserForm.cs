using PageObjectModel.PageElemets;
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
        }
        public Headers Header { get; }
        public ErrorsFields ErrorField { get; }
        public FormsFields Field { get; }
        public Buttons Button { get; }
        
        public void ChangeFirstName(string name)
        {
            Field.FirstName.Clear();
            Field.FirstName.SendKeys(name);
        }
        public void ChangeLastName(string lastName)
        {
            Field.LastName.Clear();
            Field.LastName.SendKeys(lastName);
        }
        public UserPage SubmitEditUserForm()
        {
            Button.Submit.ClickIfElementIsClickable(driverManager.Driver);
            WaitOnTableLoad();
            return new UserPage(driverManager);
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