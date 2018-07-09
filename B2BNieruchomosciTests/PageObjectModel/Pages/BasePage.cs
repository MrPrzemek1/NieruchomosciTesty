using OpenQA.Selenium.Support.UI;
using System;
using TestResources;

namespace PageObjectModel
{
    public class BasePage
    {
        public DriverManager driverManager;
        protected WebDriverWait wait;

        public BasePage(DriverManager manager)
        {
            driverManager = manager;
            wait = new WebDriverWait(manager.Driver, TimeSpan.FromSeconds(10));
            wait.PollingInterval = TimeSpan.FromMilliseconds(100);
        }
    }
}
