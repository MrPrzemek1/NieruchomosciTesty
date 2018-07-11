using NUnit.Framework;
using OpenQA.Selenium;
using PageObjectModel;
using PageObjectModel.Pages.Building;
using TestResources;

namespace Tests
{
    public class BuildingPageTests : BaseTest
    {
        public BuildingPageTests() { }

        public BuildingPageTests(DriverManager manager) : base(manager) { }

        [Test]
        public void AddNewBuilding()
        {
            LoginPage loginPage = new LoginPage(manager);
            HomePage homePage = loginPage.SetCorrectLoginData(login, password);
            BuildingListPage buildingPage = homePage.GoTo<BuildingListPage>(NavigationTo.NIERUCHOMOSCI, By.Id("buildings-grid"));
            CreateBuilding createBuilding = buildingPage.GoToCreateBuildingForm();
            BuildingListPage buildingPageAfterAddNewBuilding = createBuilding.CreateNewBuilding(name, street, postCode, city, "Aktywny");
            Assert.IsTrue(buildingPageAfterAddNewBuilding.IsCreationOfBuildingSuccesful(name, street, city, "Aktywny"));
        }
    }
}
