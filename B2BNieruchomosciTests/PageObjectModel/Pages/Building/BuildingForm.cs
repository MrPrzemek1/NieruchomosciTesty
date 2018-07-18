using OpenQA.Selenium.Support.UI;
using PageObjectModel.PageElemets;
using TestResources;

namespace PageObjectModel.Pages.Building
{
    public class BuildingForm : BasePage
    {
        public BuildingForm(DriverManager manager) : base(manager)
        {
            Button = new Buttons(manager);
            Field = new FormsFields(manager);
            Error = new ErrorsFields(manager);
        }

        public Buttons Button { get; }
        public FormsFields Field { get; }
        public ErrorsFields Error { get; }

        public OfficePage GoToOfficePage()
        {
            Button.Office.Click();
            return new OfficePage(driverManager);
        }
        public ResourcePage GoToResourcePage()
        {
            Button.Office.Click();
            return new ResourcePage(driverManager);
        }
        public BuildingPage CreateNewBuilding(string name, string street, int postCode, string city, string status)
        {
            SelectElement selectStatus = new SelectElement(Field.Status);
            Field.Name.SendKeys(name);
            Field.Street.SendKeys(street);
            Field.PostCode.SendKeys(postCode.ToString());
            Field.City.SendKeys(city);
            selectStatus.SelectByText(status);
            Button.Submit.ClickIfElementIsClickable(driverManager.Driver);
            WaitOnTableLoad();
            return new BuildingPage(driverManager);
        }

        public BuildingPage EditBuildingData(string name,int postCode, string city, string street)
        {
            Field.Name.ClearAndSendKeys(name);
            Field.PostCode.ClearAndSendKeys(postCode.ToString());
            Field.City.ClearAndSendKeys(city);
            Field.Street.ClearAndSendKeys(street);
            Button.Submit.Click();
            WaitOnTableLoad();
            return new BuildingPage(driverManager);
        }

    }
}
