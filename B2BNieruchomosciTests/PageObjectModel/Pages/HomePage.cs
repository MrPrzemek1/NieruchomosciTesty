using TestResources;
using PageObjectModel.PageElemets;
using SeleniumExtras.PageObjects;
using System;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium;
using System.Linq;

namespace PageObjectModel
{
    public class HomePage : BasePage
    {
        public HomePage(DriverManager manager) : base(manager)
        {
            Header = new Headers(manager);
            Table = new Tables(manager);
            NavigationBar = new NavigationBar(manager);
            PageFactory.InitElements(manager.Driver, this);
        }
        public Headers Header { get; }
        public Tables Table { get; }
        private NavigationBar NavigationBar { get; }

        public T GoTo<T>(NavigationTo page, By by) where T:class
        {
            NavigationBar.ChooseNavigationElement(page);
            return (T)Activator.CreateInstance(typeof(T),driverManager);
        }
    }
}