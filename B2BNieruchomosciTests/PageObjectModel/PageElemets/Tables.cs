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

        public bool IsDataExistsInTableRows(params string[] szukaneWartosci)
        {
            WaitOnTableLoad();
            return AllRowsOnTable.Any(e => szukaneWartosci.All(sw => e.Text.Contains(sw)));
        }
        public bool IsDataExistsInTableCells(params string[] szukaneWartosci)
        {
            WaitOnTableLoad();
            return AllCellsOnTable.Any(e => szukaneWartosci.All(sw => e.Text.Contains(sw)));
        }
        public int RandomElement()
        {
            Console.WriteLine("Ilość wierszy: {0}",AllRowsOnTable.Count);
            Random random = new Random();
            var list = AllRowsOnTable.Where(e => !String.IsNullOrEmpty(e.Text));
            int element = random.Next(1, list.Count());
            Console.WriteLine("Wybrany element: {0}", element);
            return element;
        }

        public string GetRandomExistingEmail()
        {
            WaitOnTableLoad();
            return AllCellsOnTable.Where(e => e.Text.Contains("@")).ElementAt(RandomElement()).Text;
        }
    }
}
