using OpenQA.Selenium.Support.UI;
using PageObjectModel.PageElemets;
using System;
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

        protected void SelectStatus(string status = "Aktywny")
        {
            SelectElement selectStatus = new SelectElement(Field.Status);
            selectStatus.SelectByText(status);
        }

        public T SubmitForm<T>()
        {
            Button.Submit.ClickIfElementIsClickable(driverManager.Driver);
            WaitOnTableLoad();
            return (T)Activator.CreateInstance(typeof(T), driverManager);
        }
    }
}
