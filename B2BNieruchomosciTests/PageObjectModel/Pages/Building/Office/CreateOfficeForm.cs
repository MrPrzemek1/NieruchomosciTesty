using OpenQA.Selenium.Support.UI;
using PageObjectModel.PageElemets;
using TestResources;

namespace PageObjectModel.Pages.Building
{
    public class CreateOfficeForm : BasePage
    {
        public CreateOfficeForm(DriverManager manager) : base(manager)
        {
            Field = new FormsFields(manager);
            Button = new Buttons(manager);
            Error = new ErrorsFields(manager);
        }
        public FormsFields Field { get; }
        public Buttons Button { get; }
        public ErrorsFields Error { get; }

        public OfficePage AddNewOffice(string officeName, int officePrice, int officeArea)
        {
            SelectElement selectElement = new SelectElement(Field.Status);
            Field.Name.SendKeys(officeName);
            Field.Price.SendKeys(officePrice.ToString());
            Field.Area.SendKeys(officeArea.ToString());
            selectElement.SelectByText("Aktywny");
            Button.Submit.Click();
            WaitOnTableLoad();
            return new OfficePage(driverManager);
        }
        private OfficePage SubmitForm()
        {
            Button.Submit.Click();
            return new OfficePage(driverManager);
        }
    }
}