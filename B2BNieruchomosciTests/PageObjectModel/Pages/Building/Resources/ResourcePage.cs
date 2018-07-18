using OpenQA.Selenium.Support.PageObjects;
using PageObjectModel.PageElemets;
using TestResources;

namespace PageObjectModel.Pages.Building
{
    public class ResourcePage : BasePage
    {
        public ResourcePage(DriverManager manager) : base(manager)
        {
            Table = new Tables(manager);
            Button = new Buttons(manager);
        }
        public Tables Table { get; }
        public Buttons Button { get; }
    }
}