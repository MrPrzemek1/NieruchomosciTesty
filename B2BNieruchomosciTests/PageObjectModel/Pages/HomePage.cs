using TestResources;
using PageObjectModel.PageElemets;
using SeleniumExtras.PageObjects;
using System;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium;

namespace PageObjectModel
{
    public class HomePage : BasePage
    {
        public HomePage(DriverManager manager) : base(manager)
        {
            Header = new Headers(manager);
            NavigationBar = new NavigationBar(manager);
            PageFactory.InitElements(manager.Driver, this);
        }
        public Headers Header { get; set; }
        private NavigationBar NavigationBar { get; set; }

        public T GoTo<T>(NavigationTo page, By by) where T:class
        {
            NavigationBar.ChooseNavigationElement(page);
            wait.Until(ExpectedConditions.ElementIsVisible(by));
            return (T)Activator.CreateInstance(typeof(T),driverManager);
        }
    }
}