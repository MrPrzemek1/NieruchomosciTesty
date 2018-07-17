using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using TestResources;

namespace PageObjectModel.PageElemets
{
    public class Tables : BasePage
    {
        public Tables(DriverManager manager) : base(manager)
        {
            PageFactory.InitElements(manager.Driver,this);
        }

        [FindsBy(How = How.ClassName, Using = PageElementsLocators.BaseTableClass)]
        private IWebElement Table;

        public IList<IWebElement> AllRowsOnTable => Table.FindElements(By.TagName("tr"));

        public IList<IWebElement> AllCellsOnTable => Table.FindElements(By.TagName("td"));

        public bool TableContainsData(string name, string lastName, string email)
        {
            DriverHelper.WaitUntil(driverManager.Driver, ExpectedConditions.ElementIsVisible(By.TagName("tr")));
            return AllRowsOnTable.Any(e => e.Text.Contains(name) && e.Text.Contains(lastName) && e.Text.Contains(email));
        }

        public int RandomElement()
        {
            Random random = new Random();
            Console.WriteLine("Wielkosc kolekcji to: {0}", AllRowsOnTable.Count);
            int element = random.Next(1, AllRowsOnTable.Count);
            Console.WriteLine("Wylosowany element to {0}", element);
            return element;
        }
    }
}
