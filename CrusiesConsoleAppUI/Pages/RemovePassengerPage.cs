﻿using CruisesAppDataAccess;
using CrusiesConsoleAppUI.Factory;
using CrusiesConsoleAppUI.Models;
using CrusiesConsoleAppUI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrusiesConsoleAppUI.Pages
{
    public class RemovePassengerPage : IBasePage
    {
        IUserModel _admin;
        IDataManager _dataManager;
        IBasePage _page;
        IPageStore _pageStore;
        CruiseModel _cruise;

        public RemovePassengerPage(IUserModel admin, IBasePage page, CruiseModel cruise, IPageStore pageStore, IDataManager dataManager)
        {
            _admin = admin;
            _dataManager = dataManager;
            _page = page;
            _pageStore = pageStore;
            _cruise = cruise;

        }
        public void DisplayContent()
        {
            Console.Clear();
            HelperMethods.HelperMethods.DisplayPageHeader($"Remove Passenger");
            HelperMethods.HelperMethods.DisplayList(_cruise.Passengers, "Passenger");
            if(_cruise.Passengers.Count > 0)
            {
                int selectedPassenger = HelperMethods.HelperMethods.GetItemInRange(1, _cruise.Passengers.Count, "Which Passenger Would You Like To Delete");
                HelperMethods.HelperMethods.DisplayEditingOptions("confirmOrCancel");

                switch (HelperMethods.HelperMethods.GetItemInRange(1, 2, $"Are You Sure You Want To Remove {_cruise.Passengers[selectedPassenger - 1]}"))
                {
                    case 1:
                        _dataManager.RemovePassengerFromCruise(FilePathConstants.ConstructPath(), _cruise.CruiseIdentifier, _cruise.Passengers[selectedPassenger - 1].PassportNumber);
                        _cruise.RemovePassenger(_cruise.Passengers[selectedPassenger - 1]);
                        HelperMethods.HelperMethods.ReturnToMainMenu("The Selected Passenger Has Been Removed From The Cruise");
                        _page = _pageStore.CurrentPage;
                        _page.DisplayContent();
                        break;

                    case 2:
                        HelperMethods.HelperMethods.ReturnToMainMenu("The Selected Passenger Has Not Been Removed From The Cruise");
                        _page = PageFactory.CreateHomePage(_admin, _page, _pageStore, _dataManager);
                        _page.DisplayContent();
                        break;
                }
            }
            else
            {
                HelperMethods.HelperMethods.ReturnToMainMenu("The Selected Cruise Does Not Have Any Passengers");
                _page = _pageStore.CurrentPage;
                _page.DisplayContent();
            }
           

        }
    }
}
