using NUnit.Framework;
using PageObjectModel;
using PageObjectModel.Pages.Building;
using System;
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
            officeForm.FillInTheOfficeForm(name, randomInt, randomArea);
            OfficePage officePageAfterAddNewOffice = officeForm.SubmitForm<OfficePage>();

            Assert.IsTrue(officePageAfterAddNewOffice.Table.IsDataExistsInTableRows(name, ConvertInt(randomInt), ConvertInt(randomArea)));
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

        private string ConvertInt(int? text)
        {
            return text.ToString().Insert(2, " ") + ",00";
        }
    }
}
