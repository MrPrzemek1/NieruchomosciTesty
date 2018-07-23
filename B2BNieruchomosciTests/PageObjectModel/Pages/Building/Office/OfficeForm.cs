using OpenQA.Selenium.Support.UI;
using TestResources;

namespace PageObjectModel.Pages.Building
{
    public class OfficeForm : BaseForm
    {
        public OfficeForm(DriverManager manager) : base(manager) { }

        public void FillInTheOfficeForm(string officeName, int? officePrice, int? officeArea)
        {
            Field.Name.SendKeys(officeName);
            Field.Price.SendKeys(officePrice.ToString());
            Field.Area.SendKeys(officeArea.ToString());
            SelectStatus();
        }

        public OfficePage EditOfficeData(string name, int price, int area)
        {
            Field.Name.ClearAndSendKeys(name);
            Field.Price.ClearAndSendKeys(price.ToString());
            Field.Area.ClearAndSendKeys(area.ToString());
            return SubmitForm<OfficePage>();
        }
    }
}