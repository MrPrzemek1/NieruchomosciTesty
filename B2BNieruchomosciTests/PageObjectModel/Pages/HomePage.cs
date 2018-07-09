﻿using TestResources;
using PageObjectModel.PageElemets;
using SeleniumExtras.PageObjects;
using System;

namespace PageObjectModel
{
    public class HomePage : BasePage
    {
        public HomePage(DriverManager manager) : base(manager)
        {
            Header = new Headers(manager);
            NavigationBar = new NavigationBar(manager);
            PageFactory.InitElements(manager.Driver, this);
        }
        public Headers Header { get; set; }
        private NavigationBar NavigationBar { get; set; }

        public T GoTo<T>(NavigationTo page) where T:class
        {
            NavigationBar.ChooseNavigationElement(page);
            return (T)Activator.CreateInstance(typeof(T),driverManager);
        }
    }
}