﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestResources
{
    public static class PageElementsLocators
    {
        //Strona logowania
        public const string Email = "Email";
        public const string LoginPassword = "Password";
        public const string LoginButton = "//input[@class='btn btn-primary']";
        public const string ForgotPasswordLink = "Nie pamiętasz hasła ?";
        //Strona główna
        public const string Header = "mt-4";
        public const string NavigationBar = "nav-link";

        //Zakładka Administratorzy
        public const string AddButton = "//a[@class='btn btn-secondary']";
        public const string ConfirmButton = "//input[@class='btn btn-primary']";
        public const string Name = "FirstName";
        public const string LastName = "LastName";
        public const string UsersTable = "users-grid";
        //Strona z przypomnieniem hasła
        public const string CorrectPasswordReset = "lead";
        //Pola z komunikatami walidacji
        public const string WorngDataOrPasswordErrorField = "//div[@class='validation-summary-errors text-danger']/ul/li";
        public const string EmptyPasswordErrorField = "//span[@data-valmsg-for='Password']";
        public const string EmptyEmailErrorField = "//span[@data-valmsg-for='Email']";
    }
}