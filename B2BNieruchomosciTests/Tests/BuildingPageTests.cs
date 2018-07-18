using NUnit.Framework;
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
            BuildingPage buildingPage = homePage.GoTo<BuildingPage>(NavigationTo.NIERUCHOMOSCI);
            CreateBuildingForm createBuilding = buildingPage.GoTo<CreateBuildingForm>();
            BuildingPage buildingPageAfterAddNewBuilding = createBuilding.CreateNewBuilding(name, street, randomInt, city, "Aktywny");
            Assert.IsTrue(buildingPageAfterAddNewBuilding.Table.IsDataExistsInTable(name, street, city, "Aktywny"));
        }
        [Test]
        public void testest()
        {
            LoginPage loginPage = new LoginPage(manager);
            HomePage homePage = loginPage.SetCorrectLoginData(login, password);
            BuildingPage buildingPage = homePage.GoTo<BuildingPage>(NavigationTo.NIERUCHOMOSCI);
            CreateBuildingForm createBuilding = buildingPage.GoTo<CreateBuildingForm>();
        }
    }
}
