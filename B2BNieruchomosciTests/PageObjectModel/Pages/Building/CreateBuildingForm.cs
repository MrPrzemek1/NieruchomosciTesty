using OpenQA.Selenium.Support.UI;
using PageObjectModel.PageElemets;
using SeleniumExtras.PageObjects;
using TestResources;

namespace PageObjectModel.Pages.Building
{
    public class CreateBuildingForm : BasePage
    {
        public CreateBuildingForm(DriverManager manager) : base(manager)
        {
            Button = new Buttons(manager);
            Field = new FormsFields(manager);
            Error = new ErrorsFields(manager);
            PageFactory.InitElements(manager.Driver, this);
        }

        public Buttons Button { get; }
        public FormsFields Field { get; }
        public ErrorsFields Error { get; }

        public BuildingPage CreateNewBuilding(string name, string street, int postCode, string city, string status)
        {
            SelectElement selectStatus = new SelectElement(Field.Status);
            Field.Name.SendKeys(name);
            Field.Street.SendKeys(street);
            Field.PostCode.SendKeys(postCode.ToString());
            Field.City.SendKeys(city);
            selectStatus.SelectByText(status);
            Button.Submit.ClickIfElementIsClickable(driverManager.Driver);
            return new BuildingPage(driverManager);
        }
    }
}