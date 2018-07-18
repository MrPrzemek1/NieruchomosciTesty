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
