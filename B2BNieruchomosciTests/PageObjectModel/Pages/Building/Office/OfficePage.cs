using OpenQA.Selenium;
using PageObjectModel.PageElemets;
using SeleniumExtras.WaitHelpers;
using System.Linq;
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
    }
}