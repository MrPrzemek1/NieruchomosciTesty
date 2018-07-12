using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;
using System;
using TestResources;
using OpenQA.Selenium.Support.UI;

namespace PageObjectModel
{
    public class BasePage
    {
        public DriverManager driverManager;
        protected WebDriverWait wait;

        public BasePage(DriverManager manager)
        {
            driverManager = manager;
            wait = new WebDriverWait(manager.Driver, TimeSpan.FromSeconds(20));
            wait.PollingInterval = TimeSpan.FromMilliseconds(100);
            PageFactory.InitElements(manager.Driver,this);
        }
        protected void WaitOnTableLoad()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName(PageElementsLocators.BaseTableClass)));
        }
    }
}
