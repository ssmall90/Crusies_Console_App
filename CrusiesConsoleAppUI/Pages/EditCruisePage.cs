﻿using CrusiesConsoleAppUI.Models;
using CrusiesConsoleAppUI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrusiesConsoleAppUI.Pages
{
    public class EditCruisePage : IBasePage
    {
        IUserModel _admin;
        IBasePage _page;
        IPageStore _pageStore;
        CruiseModel _cruise;

        public EditCruisePage(IUserModel admin,IBasePage page, CruiseModel cruise, IPageStore pageStore)
        {
            _admin = admin;
            _cruise = cruise;
            _page = page;
            _pageStore = pageStore;
        }
        public void DisplayContent()
        {


            Console.Clear();
            HelperMethods.HelperMethods.DisplayPageHeader($"{_cruise}");
            Console.WriteLine(_cruise.CruiseName); 
            Console.WriteLine(_cruise.CruiseIdentifier);
            HelperMethods.HelperMethods.DisplayList(_cruise.Ports, "Ports");
            HelperMethods.HelperMethods.DisplayList(_cruise.Passengers, "Passengers");
            HelperMethods.HelperMethods.DisplayEditingOptions("editCruisePage");

            switch (HelperMethods.HelperMethods.GetItemInRange(1, 3))
            {
                case 1:
                    _pageStore.CurrentPage = this;
                    _page = PageFactory.CreateEditPortsPage(_admin, _page, _cruise, _pageStore);
                    _page.DisplayContent();
                     break;

                    
            }



            Console.ReadLine();
        }
    }
}
