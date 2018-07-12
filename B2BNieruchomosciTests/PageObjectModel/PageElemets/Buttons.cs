using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using TestResources;

namespace PageObjectModel.PageElemets
{
    public class Buttons : BasePage
    {
        public Buttons(DriverManager manager) : base(manager)
        {
            PageFactory.InitElements(manager.Driver,this);
        }
        [FindsBy(How = How.XPath, Using = PageElementsLocators.AddButtonXpath)]
        public IWebElement Add { get; private set; }

        [FindsBy(How = How.XPath, Using = PageElementsLocators.SubmitButtonXpath)]
        public IWebElement Submit { get; private set; }

        [FindsBy(How = How.Id, Using = PageElementsLocators.BlockUserButtonId)]
        public IWebElement BlockUser { get; private set; }

        [FindsBy(How = How.Id, Using = PageElementsLocators.UnblockUserButtonId)]
        public IWebElement UnBlockUser { get; private set; }

        [FindsBy(How = How.Id, Using = PageElementsLocators.ReserPasswordButtonId)]
        public IWebElement ResetPassword { get; private set; }

        [FindsBy(How = How.LinkText, Using = PageElementsLocators.ForgotPasswordLink)]
        public IWebElement ForgotPassword { get; private set; }

        public void GoTo(string text)
        {
            Submit.FindElement(By.LinkText(text)).Click();
        }
    }
}
