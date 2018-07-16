using OpenQA.Selenium.Support.UI;
using PageObjectModel.PageElemets;
using SeleniumExtras.PageObjects;
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
            PageFactory.InitElements(manager.Driver, this);
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
            return new OfficePage(driverManager);
        }
    }
}