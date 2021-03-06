﻿using TestResources;
using PageObjectModel.PageElemets;
using System;

namespace PageObjectModel
{
    public class HomePage : BasePage
    {
        public HomePage(DriverManager manager) : base(manager)
        {
            Header = new Headers(manager);
            Table = new Tables(manager);
            NavigationBar = new NavigationBar(manager);
        }
        public Headers Header { get; }
        public Tables Table { get; }
        private NavigationBar NavigationBar { get; }

        public T GoTo<T>(NavigationTo page) where T:class
        {
            NavigationBar.ChooseNavigationElement(page);
            return (T)Activator.CreateInstance(typeof(T),driverManager);
        }
    }
}