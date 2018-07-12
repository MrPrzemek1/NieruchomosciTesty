using PageObjectModel.PageElemets;
using TestResources;

namespace PageObjectModel.Pages.Building
{
    public class OfficePage : BasePage
    {
        public OfficePage(DriverManager manager) : base(manager)
        {
            Button = new Buttons(manager);
            Table = new Tables(manager);
        }

        public Buttons Button { get; }
        public Tables Table { get; }

        public CreateOfficeForm GoToCreateOfficeForm()
        {
            Button.Add.ClickIfElementIsClickable(driverManager.Driver);
            return new CreateOfficeForm(driverManager);
        }
    }
}