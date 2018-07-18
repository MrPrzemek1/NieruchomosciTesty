using OpenQA.Selenium.Support.UI;
using PageObjectModel.PageElemets;
using TestResources;

namespace PageObjectModel.Pages.Building.Resources
{
    class ResourceForm : BasePage
    {
        public ResourceForm(DriverManager manager) : base(manager)
        {
            Field = new FormsFields(manager);
            Button = new Buttons(manager);
            Errors = new ErrorsFields(manager);
        }
        public FormsFields Field { get; }
        public Buttons Button { get; }
        public ErrorsFields Errors { get; }

        public ResourcePage AddNewResource(string name, int price)
        {
            SelectElement selectElement = new SelectElement(Field.Status);
            Field.Name.SendKeys(name);
            Field.Price.SendKeys(price.ToString());
            selectElement.SelectByText("Aktywny");
            WaitOnTableLoad();
            return new ResourcePage(driverManager);
        }
    }
}
