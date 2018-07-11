using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.Generic;
using TestResources;

namespace PageObjectModel
{
    public abstract class BaseGrid : BasePage
    {
        public BaseGrid(DriverManager manager) : base(manager)
        {
        }

        public abstract IWebElement Table { get; set; }

        public IList<IWebElement> AllRowsOnGrid => Table.FindElements(By.TagName("tr"));

        public IList<IWebElement> AllCellsOnGrid => Table.FindElements(By.TagName("td"));
    }
}
