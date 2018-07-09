using TestResources;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;


namespace PageObjectModel.PageElemets
{
    public class NavigationBar : BasePage
    {
        public NavigationBar(DriverManager manager) : base(manager) { }

        private IList<IWebElement> NavigationItem => driverManager.FindWebElementsAndWait(By.ClassName(PageElementsLocators.NavigationBarClass));

        private Dictionary<NavigationTo, string> NavigationDictionary = new Dictionary<NavigationTo, string>()
        {
            {NavigationTo.ADMIN,"/User/List"},
            {NavigationTo.NIERUCHOMOSCI,"/Building/List"},
            {NavigationTo.NAJEMCY,"/Tenant/List"},
            {NavigationTo.WYNAJEM,"/Rent/Office/List"},
            {NavigationTo.REZERWACJA,"/Rent/Resource/List"},
            {NavigationTo.FAKTURY,"/Invoice/List"},
            {NavigationTo.LOGIN,"/Account/Manage"},
            {NavigationTo.LOGOUT,"javascript:logout()"},
        };
        
        public void ChooseNavigationElement(NavigationTo item)
        {
            NavigationItem.Where(e => e.GetAttribute("href").Contains(NavigationDictionary[item])).First().Click();
        }
        public void GoToUserPage() => ChooseNavigationElement(NavigationTo.ADMIN);
        public void GoToBuildingPage() => ChooseNavigationElement(NavigationTo.NIERUCHOMOSCI);
        public void GoToTenantPage() => ChooseNavigationElement(NavigationTo.NAJEMCY);
        public void GoToRentOfficePage() => ChooseNavigationElement(NavigationTo.WYNAJEM);
        public void GoToInvoicePage() => ChooseNavigationElement(NavigationTo.REZERWACJA);
        public void GoToAccountManagePage() => ChooseNavigationElement(NavigationTo.LOGIN);
        public void Logout() => ChooseNavigationElement(NavigationTo.LOGOUT);
    }
}
