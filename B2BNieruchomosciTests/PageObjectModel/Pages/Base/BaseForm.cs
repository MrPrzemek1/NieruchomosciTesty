using PageObjectModel.PageElemets;
using TestResources;

namespace PageObjectModel.Pages
{
    public class BaseForm : BasePage
    {
        public BaseForm(DriverManager manager) : base(manager)
        {
            Button = new Buttons(manager);
            Field = new FormsFields(manager);
            Error = new ErrorsFields(manager);
            Header = new Headers(manager);
        }
        public Headers Header { get; }
        public Buttons Button { get; }
        public FormsFields Field { get; }
        public ErrorsFields Error { get; }
    }
}
