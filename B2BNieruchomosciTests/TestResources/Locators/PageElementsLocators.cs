using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestResources
{
    public static class PageElementsLocators
    {
        //Strona logowania
        public const string EmailId = "Email";
        public const string LoginPasswordId = "Password";
        public const string LoginButtonXpath = "//input[@class='btn btn-primary']";
        public const string ForgotPasswordLink = "Nie pamiętasz hasła ?";
        //Strona główna
        public const string HeaderClass = "mt-4";
        public const string NavigationBarClass = "nav-link";
        //Zakładka Administratorzy
        public const string AddButtonXpath = "//a[@class='btn btn-secondary']";
        public const string ConfirmButtonXpath = "//input[@class='btn btn-primary']";
        public const string NameId = "FirstName";
        public const string LastNameId = "LastName";
        public const string UsersTableId = "users-grid";
        //Edycja użytkownika
        public const string ReserPasswordButtonId = "reset-password-btn";
        public const string BlockUserButtonId = "lock-in-btn";
        public const string UnblockUserButtonId = "lock-out-btn";
        public const string UserRoleButtonXpath = "//a[@class='btn btn-secondary']";
        //Strona z przypomnieniem hasła
        public const string CorrectPasswordResetClass = "lead";
        //Pola z komunikatami walidacji
        public const string WorngDataOrPasswordErrorFieldXpath = "//div[@class='validation-summary-errors text-danger']/ul/li";
        public const string EmptyPasswordErrorFieldXpath = "//span[@data-valmsg-for='Password']";
        public const string EmptyEmailErrorFieldXpath = "//span[@data-valmsg-for='Email']";
        public const string ExistingEmailErrorFieldXpath = "//div[@class='validation-summary-errors text-danger']/ul/li";
        public const string EmptyNameErrorXpath = "//span[@data-valmsg-for='FirstName']";
        public const string EmptyLastNameErrorXpath = "//span[@data-valmsg-for='LastName']";

    }
}
