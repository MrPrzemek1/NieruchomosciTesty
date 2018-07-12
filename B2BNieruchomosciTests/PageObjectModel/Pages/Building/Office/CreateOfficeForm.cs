using OpenQA.Selenium;
using PageObjectModel.PageElemets;
using SeleniumExtras.PageObjects;
using TestResources;

namespace PageObjectModel.Pages.Building
{
    public class CreateOfficeForm : BasePage
    {
        public CreateOfficeForm(DriverManager manager) : base(manager)
        {
            Field = new FormsFields(manager);
            Button = new Buttons(manager);
            Error = new ErrorsFields(manager);
            PageFactory.InitElements(manager.Driver, this);
        }
        public FormsFields Field { get; }
        public Buttons Button { get; }
        public ErrorsFields Error { get; }

    }
}