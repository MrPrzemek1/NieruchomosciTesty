using PageObjectModel.PageElemets;
using TestResources;

namespace PageObjectModel.Pages.Building
{
    public class EditOfficeForm:BasePage
    {
        public EditOfficeForm(DriverManager manager) : base(manager)
        {
        }

        public FormsFields Field { get; }
        public Buttons Button { get; }
        public ErrorsFields Error { get; }

        public OfficePage EditOfficeData(string name, int price, int area)
        {
            Field.Name.Clear();
            Field.Name.SendKeys(name);
            Field.Price.Clear();
            Field.Price.SendKeys(price.ToString());
            Field.Area.Clear();
            Field.Area.SendKeys(area.ToString());
            Button.Submit.Click();
            return new OfficePage(driverManager);
        }
    }
}