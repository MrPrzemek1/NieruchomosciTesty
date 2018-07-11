using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace TestResources
{
    public class DriverManager
    {
        private const string _baseUrl = "http://roger:7071";

        public DriverTypeEnum Type { get; private set; }

        public DriverManager(DriverTypeEnum type)
        {
            Type = type;
            Driver = GetDriver(type);
        }
       
        public IWebDriver Driver { get; private set; }

        public string Title { get { return Driver.Title; } }

        public IWebDriver GetDriver(DriverTypeEnum driver)
        {
            switch (driver)
            {
                case DriverTypeEnum.Chrome:
                    var outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                    var relativePath = @"..\..\..\Tests\bin\debug";
                    var chromeDriverPath = Path.GetFullPath(Path.Combine(outPutDirectory, relativePath));
                    return new ChromeDriver(chromeDriverPath);
                case DriverTypeEnum.Firefox:
                    return new FirefoxDriver();
                default:
                    return new ChromeDriver();
            }
        }
        #region Wyszukiwanie i czekanie na elementy.
        public IWebElement FindWebElementAndWait(By by) => DriverHelper.FindWebElementAndWait(Driver, by);

        public IList<IWebElement> FindWebElementsAndWait(By by) => DriverHelper.FindWebElementsAndWait(Driver, by);
        #endregion

        #region Wyszukiwanie elementów bez czekania na nie
        public IWebElement FindWebElement(By by) => DriverHelper.FindWebElementWithoutWait(Driver, by);
       
        public IList<IWebElement> FindWebElements(By by) => DriverHelper.FindWebElementsWithoutWait(Driver, by);
        #endregion

        public void GoTo()
        {
            Driver.Navigate().GoToUrl(_baseUrl);
            MaximizeWindow();
        }
        
        public void MaximizeWindow() => Driver.Manage().Window.Maximize();

        public void Quit() => Driver.Quit();

        public void AcceptAlert() => Driver.SwitchTo().Alert().Accept();
    }
}
