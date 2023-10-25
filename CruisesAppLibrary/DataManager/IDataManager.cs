﻿using CrusiesConsoleAppUI.Models;

namespace CrusiesConsoleAppUI.Services
{
    public interface IDataManager
    {
        void AddPortToCruise(string filePath, CruiseModel cruise, PortModel port);
        void AppendCruiseToXml(string filePath, CruiseModel cruise);
        List<CruiseModel> DeserializeCruiseFromXml(string filePath);
        PassengerModel DeserializePassengerFromXml(string filePath);
        PortModel DeserializePortFromXml(string filePath);
        TripModel DeserializeTripFromXml(string filePath);
    }
}