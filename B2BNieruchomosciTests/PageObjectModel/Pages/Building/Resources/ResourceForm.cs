using OpenQA.Selenium.Support.UI;
using TestResources;

namespace PageObjectModel.Pages.Building.Resources
{
    class ResourceForm : BaseForm
    {
        public ResourceForm(DriverManager manager) : base(manager) { }

        public ResourcePage AddNewResource(string name, int price)
        {
            SelectElement selectElement = new SelectElement(Field.Status);
            Field.Name.SendKeys(name);
            Field.Price.SendKeys(price.ToString());
            selectElement.SelectByText("Aktywny");
            return SubmitForm();
        }

        public ResourcePage EditResource(string name, int price)
        {
            Field.Name.ClearAndSendKeys(name);
            Field.Price.ClearAndSendKeys(price.ToString());
            return SubmitForm();
        }

        private ResourcePage SubmitForm()
        {
            Button.Submit.Click();
            WaitOnTableLoad();
            return new ResourcePage(driverManager);
        }
    }
}
