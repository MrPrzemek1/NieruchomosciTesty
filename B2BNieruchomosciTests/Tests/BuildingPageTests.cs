using NUnit.Framework;
using PageObjectModel;
using PageObjectModel.Pages.Building;
using System;
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
            BuildingPage buildingPage = GoToBuildingPage();
            BuildingForm createBuildingForm = buildingPage.GoTo<BuildingForm>();
            createBuildingForm.FillInTeFormFields(name, street, randomInt, city, "Aktywny");
            BuildingPage buildingPageAfterAddNewBuilding = createBuildingForm.SubmitBuildingForm();
            Assert.IsTrue(buildingPageAfterAddNewBuilding.Table.IsDataExistsInTable(name, street, city, "Aktywny"));
        }
        [Test]
        public void EditExsitingBuliding()
        {
            BuildingPage buildingPage = GoToBuildingPage();
            BuildingForm editBuildingForm = buildingPage.GoToEditBuilding();
            BuildingPage buildingPageAfterEdit = editBuildingForm.EditBuildingData(name,randomInt,city,street);
            Assert.IsTrue(buildingPageAfterEdit.Table.IsDataExistsInTable(name, street, city, "Aktywny"));
        }
        [Test]
        public void CreateBuildingWithEmptyName()
        {
            BuildingPage buildingPage = GoToBuildingPage();
            BuildingForm createBuildingForm = buildingPage.GoTo<BuildingForm>();
            createBuildingForm.FillInTeFormFields(string.Empty,street, randomInt, city, "Aktywny");
            BuildingForm formAfterSubmit = createBuildingForm.SubmitIncorrectForm();
            Assert.IsTrue(formAfterSubmit.Error.IsDisplayEmptyNameErrorField);
            Assert.AreEqual(formAfterSubmit.Error.EmptyNameErrorText, "Pole jest wymagane.");
        }
        [Test]
        public void CreateBuildingWithStreetName()
        {
            BuildingPage buildingPage = GoToBuildingPage();
            BuildingForm createBuildingForm = buildingPage.GoTo<BuildingForm>();
            createBuildingForm.FillInTeFormFields(name, string.Empty, randomInt, city, "Aktywny");
            BuildingForm formAfterSubmit = createBuildingForm.SubmitIncorrectForm();
            Assert.IsTrue(formAfterSubmit.Error.IsDisplayEmptyStreetErrorField);
            Assert.AreEqual(formAfterSubmit.Error.EmptyStreetErrorText, "Pole jest wymagane.");
        }
        [Test]
        public void CreateBuildingWithPostCodeEmpty()
        {
            BuildingPage buildingPage = GoToBuildingPage();
            BuildingForm createBuildingForm = buildingPage.GoTo<BuildingForm>();
            createBuildingForm.FillInTeFormFields(name, street,null, city, "Aktywny");
            BuildingForm formAfterSubmit = createBuildingForm.SubmitIncorrectForm();

            Assert.IsTrue(formAfterSubmit.Error.IsDisplayEmptyPostCodeErrorField);
            Assert.AreEqual(formAfterSubmit.Error.EmptyPostCodeErrorText, "Pole jest wymagane.");
        }
        [Test]
        public void CreateBuildingWithCityEmpty()
        {
            BuildingPage buildingPage = GoToBuildingPage();
            BuildingForm createBuildingForm = buildingPage.GoTo<BuildingForm>();
            createBuildingForm.FillInTeFormFields(name, street, randomInt, string.Empty, "Aktywny");
            BuildingForm formAfterSubmit = createBuildingForm.SubmitIncorrectForm();

            Assert.IsTrue(formAfterSubmit.Error.IsDisplayEmptyCityErrorField);
            Assert.AreEqual(formAfterSubmit.Error.EmptyCityErrorText, "Pole jest wymagane.");
        }
        [Test]
        public void CreateBuildingWithoutStatus()
        {
            BuildingPage buildingPage = GoToBuildingPage();
            BuildingForm createBuildingForm = buildingPage.GoTo<BuildingForm>();
            createBuildingForm.FillInTeFormFields(name, street, randomInt, city, "Wybierz");
            BuildingForm formAfterSubmit = createBuildingForm.SubmitIncorrectForm();
            Assert.IsTrue(formAfterSubmit.Error.IsDisplayUnselectedStatusErrorField);
            Assert.AreEqual(formAfterSubmit.Error.UnselectedStatusErrorText, "Pole jest wymagane.");
        }
        private BuildingPage GoToBuildingPage()
        {
            LoginPage loginPage = new LoginPage(manager);
            HomePage homePage = loginPage.SetCorrectLoginData(login, password);
            BuildingPage buildingPage = homePage.GoTo<BuildingPage>(NavigationTo.NIERUCHOMOSCI);
            return buildingPage;
        }
    }
}
