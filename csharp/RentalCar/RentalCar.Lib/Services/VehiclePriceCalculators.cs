using System;
using System.Collections.Generic;
using System.Text;

namespace RentalCar.Lib.Services
{
    public static class VehiclePriceCalculators
    {
        public static double CalculateSmallCarPrice(double baseDayRental, double numberOfDays)
        {
            double price = baseDayRental * numberOfDays;
            return price;
        }

        public static double CalculateCombiPrice(double baseDayRental, double numberOfDays, double baseKmPrice, double numberOfKm)
        {
            double price = baseDayRental * numberOfDays * 1.3 + baseKmPrice * numberOfKm;
            return price;
        }

        public static double CalculateTruckPrice(double baseDayRental, double numberOfDays, double baseKmPrice, double numberOfKm)
        {
            double price = baseDayRental * numberOfDays * 1.5 + baseKmPrice * numberOfKm * 1.5;
            return price;
        }
    }
}
