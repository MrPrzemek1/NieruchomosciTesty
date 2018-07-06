using B2BNieruchomosciTests;

namespace PageObjectModel
{
    public class BasePage
    {
        public DriverManager driverManager;
        public BasePage(DriverManager manager)
        {
            driverManager = manager;
        }
    }
}
