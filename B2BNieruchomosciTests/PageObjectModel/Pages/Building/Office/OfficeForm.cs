﻿using OpenQA.Selenium.Support.UI;
using PageObjectModel.PageElemets;
using TestResources;

namespace PageObjectModel.Pages.Building
{
    public class OfficeForm : BaseForm
    {
        public OfficeForm(DriverManager manager) : base(manager) { }

        public OfficePage AddNewOffice(string officeName, int officePrice, int officeArea)
        {
            SelectElement selectElement = new SelectElement(Field.Status);
            Field.Name.SendKeys(officeName);
            Field.Price.SendKeys(officePrice.ToString());
            Field.Area.SendKeys(officeArea.ToString());
            selectElement.SelectByText("Aktywny");
            Button.Submit.Click();
            WaitOnTableLoad();
            return new OfficePage(driverManager);
        }

        public OfficePage EditOfficeData(string name, int price, int area)
        {
            Field.Name.Clear();
            Field.Name.SendKeys(name);
            Field.Price.Clear();
            Field.Price.SendKeys(price.ToString());
            Field.Area.Clear();
            Field.Area.SendKeys(area.ToString());
            Button.Submit.Click();
            WaitOnTableLoad();
            return new OfficePage(driverManager);
        }
    }
}