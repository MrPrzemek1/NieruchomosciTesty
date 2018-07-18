using OpenQA.Selenium;
using System.Collections.Generic;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace TestResources
{
    public static class WebElementExtension
    {
        public static IList<IWebElement> FindWebElementsAndWait(this IWebElement element,IWebDriver driver, By by)
        {
            return DriverHelper.FindWebElementsAndWait(driver, element, by);
        }

        public static IWebElement FindWebElementAndWait(this IWebElement element, IWebDriver driver, By by)
        {
            return DriverHelper.FindWebElementAndWait(driver, element, by);
        }

        public static IWebElement FindWebElementAndWait(this IWebElement element, By by)
        {
            return DriverHelper.FindWebElementWithoutWait(element, by);
        }

        public static IList<IWebElement> FindWebElements(this IWebElement element, IWebDriver driver, By by)
        {
            return DriverHelper.FindWebElementsWithoutWait(element, by);
        }

        public static void ClickIfElementIsClickable(this IWebElement e, IWebDriver driver)
        {
            DriverHelper.WaitUntil(driver, ExpectedConditions.ElementToBeClickable(e)).Click();
        }
        public static void ClearAndSendKeys(this IWebElement e, string text)
        {
            e.Clear();
            e.SendKeys(text);
        }
    }
}
