using NUnit.Framework;
using PageObjectModel;
using PageObjectModel.Pages.Building;
using TestResources;

namespace Tests
{
    class OfficePageTests : BaseTest
    {
        public OfficePageTests() { }

        public OfficePageTests(DriverManager manager) : base(manager) { }

        [Test]
        public void AddNewOffice()
        {

            OfficePage officePage = GoToOfficePage();
            OfficeForm officeForm = officePage.GoTo<OfficeForm>();
            officeForm.FillInTheOfficeForm(name, randomInt, randomInt);
            OfficePage officePageAfterAddNewOffice = officeForm.SubmitForm<OfficePage>();
            Assert.IsTrue(officePageAfterAddNewOffice.Table.IsDataExistsInTable(name, randomInt.ToString().Replace(" ","")+",00"));
        }

        private OfficePage GoToOfficePage()
        {
            LoginPage loginPage = new LoginPage(manager);
            HomePage homePage = loginPage.SetCorrectLoginData(login, password);
            BuildingPage buildingPage = homePage.GoTo<BuildingPage>(NavigationTo.NIERUCHOMOSCI);
            BuildingForm buildingForm = buildingPage.GoToEditBuilding();
            OfficePage officePage = buildingForm.GoTo<OfficePage>();

            return new OfficePage(manager);
        }

    }
}
