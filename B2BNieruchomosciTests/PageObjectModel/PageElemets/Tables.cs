using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
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

        public bool IsDataExistsInTable(params string[] szukaneWartosci)
        {
            WaitOnTableLoad();
            return AllRowsOnTable.Any(e => szukaneWartosci.All(sw => e.Text.Contains(sw)));
        }

        public int RandomElement()
        {
            Random random = new Random();
            int element = random.Next(1, AllRowsOnTable.Count);
            return element;
        }

        public string GetRandomExistingEmail()
        {
            WaitOnTableLoad();
            return AllCellsOnTable.Where(e => e.Text.Contains("@")).ElementAt(RandomElement()).Text;
        }
    }
}
