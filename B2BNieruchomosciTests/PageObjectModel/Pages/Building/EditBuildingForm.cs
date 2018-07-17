using PageObjectModel.PageElemets;
using SeleniumExtras.PageObjects;
using TestResources;

namespace PageObjectModel.Pages.Building
{
    public class EditBuildingForm : BasePage
    {
        public EditBuildingForm(DriverManager manager) : base(manager)
        {
            Button = new Buttons(manager);
            Field = new FormsFields(manager);
            OfficePage = new OfficePage(manager);
            ResourcePage = new ResourcePage(manager);
            PageFactory.InitElements(manager.Driver,this);
        }

        public OfficePage OfficePage { get; }
        public ResourcePage ResourcePage { get; }
        public Buttons Button { get; }
        public FormsFields Field { get; }

        public OfficePage GoToOfficePage()
        {
            Button.Office.Click();
            return new OfficePage(driverManager);
        }

    }
}
