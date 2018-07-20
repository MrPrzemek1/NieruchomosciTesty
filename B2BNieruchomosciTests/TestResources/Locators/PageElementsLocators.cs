namespace TestResources
{
    public static class PageElementsLocators
    {
        //Uniwersalne lokatory
        public const string BaseTableClass = "dx-scrollable-container";
        public const string HeaderClass = "mt-4";

        //Pola formularzy
        public const string NameId = "Name";
        public const string StreetId = "Street";
        public const string PostCodeId = "PostCode";
        public const string CityId = "City";
        public const string StatusId = "Status";
        public const string FirstNameId = "FirstName";
        public const string LastNameId = "LastName";
        public const string EmailId = "Email";
        public const string LoginPasswordId = "Password";
        public const string OfficePriceId = "Price";
        public const string OfficeAreaId = "Area";
        //Przyciski
        public const string AddButtonXpath = "//a[@class='btn btn-secondary']";
        public const string SubmitButtonXpath = "//input[@class='btn btn-primary']";
        public const string ForgotPasswordLink = "Nie pamiętasz hasła ?";
        public const string ReserPasswordButtonId = "reset-password-btn";
        public const string BlockUserButtonId = "lock-in-btn";
        public const string UnblockUserButtonId = "lock-out-btn";
        public const string GoToOfficeButton = "/Building/Office/List/e4a923adedc4a899";
        public const string GoToResourceButton = "/Building/Resource/List/e4a923adedc4a899";
        public const string GoToMediaButton = "/Building/Media/List/e4a923adedc4a899";

        //Strona główna
        public const string NavigationBarClass = "nav-link";

        //Zakładka Administratorzy
        public const string CorrectPasswordResetMessageXpath = "//span[@data-notify='message']";

        //Strona z przypomnieniem hasła
        public const string CorrectPasswordResetStatementClass = "lead";

        //Pola z komunikatami walidacji
        public const string WorngDataOrPasswordErrorFieldXpath = "//div[@class='validation-summary-errors text-danger']/ul/li";
        public const string EmptyPasswordErrorFieldXpath = "//span[@data-valmsg-for='Password']";
        public const string EmptyEmailErrorFieldXpath = "//span[@data-valmsg-for='Email']";
        public const string ExistingEmailErrorFieldXpath = "//div[@class='validation-summary-errors text-danger']/ul/li";
        public const string EmptyNameErrorXpath = "//span[@for='FirstName']";
        public const string EmptyLastNameErrorXpath = "//span[@for='LastName']";

    }
}
