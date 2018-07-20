using PageObjectModel.PageElemets;
using TestResources;

namespace PageObjectModel.Pages.Building
{
    public class BuildingPage : BasePage
    {
        public BuildingPage(DriverManager manager) : base(manager)
        {
            Table = new Tables(manager);
            Button = new Buttons(manager);
        }
        public Tables Table { get; }
        public Buttons Button { get; }
    }
}
