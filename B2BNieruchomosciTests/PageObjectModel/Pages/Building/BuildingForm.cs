using OpenQA.Selenium.Support.UI;
using TestResources;

namespace PageObjectModel.Pages.Building
{
    public class BuildingForm : BaseForm
    {
        public BuildingForm(DriverManager manager) : base(manager) { }

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
        public void FillInTeFormFields(string name, string street, int? postCode, string city, string status)
        {
            Field.Name.SendKeys(name);
            Field.Street.SendKeys(street);
            Field.PostCode.SendKeys(postCode.ToString());
            Field.City.SendKeys(city);
            SelectStatus(status);
        }

        public BuildingPage EditBuildingData(string name, int? postCode, string city, string street)
        {
            Field.Name.ClearAndSendKeys(name);
            Field.PostCode.ClearAndSendKeys(postCode.ToString());
            Field.City.ClearAndSendKeys(city);
            Field.Street.ClearAndSendKeys(street);
            return SubmitBuildingForm();
        }
        public BuildingForm SubmitIncorrectForm()
        {
            Button.Submit.ClickIfElementIsClickable(driverManager.Driver);
            return new BuildingForm(driverManager);
        }

        public BuildingPage SubmitBuildingForm()
        {
            Button.Submit.ClickIfElementIsClickable(driverManager.Driver);
            WaitOnTableLoad();
            return new BuildingPage(driverManager);
        }

        public void SelectStatus(string status = "Aktywny")
        {
            SelectElement selectStatus = new SelectElement(Field.Status);
            selectStatus.SelectByText(status);
        }
    }
}
