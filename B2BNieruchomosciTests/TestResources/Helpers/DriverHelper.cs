using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace TestResources
{
    public static class DriverHelper
    {
        private const int TIME = 10000;
        private const int POLLING = 50;
        /// <summary>
        /// Metoda wyszukująca na stronie listy IWebElementów z możliwościa ustawienia czasu oczekiwania na ich pojawienie się.
        /// </summary>
        /// <param name="driver">sterownik przeglądarki</param>
        /// <param name="by">lokator szukanego elementu</param>
        /// <param name="milliseconds">czas oczekiwania na pojawienie sie elementu</param>
        /// <returns></returns>
        public static IList<IWebElement> FindWebElementsAndWait(IWebDriver driver, By by, int milliseconds = TIME)
        {
            return Wait(driver, by, milliseconds);
        }
        public static IWebElement FindWebElementAndWait(IWebDriver driver, By by)
        {
            var find = FindWebElementsAndWait(driver, by);
            if (find == null)
            {
                return null;
            }
            return find.FirstOrDefault();
        }
        /// <summary>
        /// Metoda wyszukująca listy IWebElementów w kontekście całej strony bez oczekiwania.
        /// </summary>
        /// <param name="driver">Sterownik przeglądarki</param>
        /// <param name="by">lokator szukanego elementu</param>
        /// <returns></returns>
        public static IList<IWebElement> FindWebElementsWithoutWait(IWebDriver driver, By by)
        {
            try
            {
                if (true)
                {
                    return driver.FindElements(by);
                }                           
            }
            catch
            {
                return null;
            }
        }
        public static IWebElement FindWebElementWithoutWait(IWebDriver driver, By by)
        {
            var find = FindWebElementsWithoutWait(driver, by);
            if (find == null)
            {
                return null;
            }
            return find.FirstOrDefault();
        }
        /// <summary>
        /// Metoda która wyszukuje listę IWebElementów w kontekście innego elementu na stronie z oczekiewaniem na jego pojawienie sie
        /// </summary>
        /// <param name="Driver">Sterownik przeglądarki</param>
        /// <param name="element">element w kontekscie ktorego szukamy</param>
        /// <param name="by">lokator szukanego elementu</param>
        /// <param name="milliseconds">czas oczekiwania na pojawienie się elementu</param>
        /// <returns></returns>
        public static IList<IWebElement> FindWebElementsAndWait(IWebDriver Driver, IWebElement element, By by, int milliseconds = TIME)
        {
            try
            {
                Wait(Driver, by, milliseconds);
                return element.FindElements(by);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static IWebElement FindWebElementAndWait(IWebDriver driver, IWebElement element, By by, int millisecond = TIME)
        {
            var find = FindWebElementsAndWait(driver, element, by, millisecond);
            if (find == null)
            {
                return null;
            }
            return find.FirstOrDefault();
        }
        /// <summary>
        /// Metoda która szuka listy IWebElementów w kontekcie IWebElementu bez czekania na jego pojawienie się.
        /// </summary>
        /// <param name="element">element w kontekscie ktorego szukamy</param>
        /// <param name="by">loktor elementu ktorego szukamy</param>
        /// <returns></returns>
        public static IList<IWebElement> FindWebElementsWithoutWait(IWebElement element, By by)
        {
            try
            {
                return element.FindElements(by);
            }
            catch
            {
                return null;
            }
        }
        public static IWebElement FindWebElementWithoutWait(IWebElement element, By by)
        {
            var find = FindWebElementsWithoutWait(element, by);
            if (find == null)
            {
                return null;
            }
            return find.FirstOrDefault();
        }
        /// <summary>
        /// Metoda czekająca aż dana lista elementów na stronie pojawi się i zwracająca listę tych elementów.
        /// </summary>
        /// <param name="driver">sterownik przeglądarki</param>
        /// <param name="by">lokator szukanego elementu</param>
        /// <param name="millisecond">czas oczekiwania na pojawienie sie elementu</param>
        /// <returns>Liste IWebElementów</returns>
        public static IList<IWebElement> Wait(IWebDriver driver, By by, int millisecond = TIME)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(millisecond));
            wait.PollingInterval = TimeSpan.FromMilliseconds(POLLING);
            try
            {
                return wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(by));
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static TResult WaitUntil<TResult>(IWebDriver driver, Func<IWebDriver, TResult> condition, int millisecond = TIME) where TResult : class
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(millisecond));
            wait.PollingInterval = TimeSpan.FromMilliseconds(POLLING);
            try
            {
                return wait.Until(condition);
            }
            catch (Exception)
            {
                return null;
            }
        }
        public static bool WaitUntil(IWebDriver driver, Func<IWebDriver, bool> condition, int millisecond = TIME)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(millisecond));
            wait.PollingInterval = TimeSpan.FromMilliseconds(POLLING);
            try
            {
                return wait.Until(condition);
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}


