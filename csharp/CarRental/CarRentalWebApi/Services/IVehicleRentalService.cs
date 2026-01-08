using CarRentalWebApi.Models;
using CarRentalWebApi.Models.DTO;

namespace CarRentalWebApi.Services
{
    public interface IVehicleRentalService
    {
        static abstract double CalculateCombiPrice(double baseDayRental, double numberOfDays, double baseKmPrice, double numberOfKm);
        static abstract double CalculateSmallCarPrice(double baseDayRental, double numberOfDays);
        static abstract double CalculateTruckPrice(double baseDayRental, double numberOfDays, double baseKmPrice, double numberOfKm);
        RentalReceiptDto CalculateRentalPrice(long rentalBookingNumber, double baseDayRental, double baseKmPrice);
        long RegisterPickup(VehiclePickUpDto vehiclePickUpDto);
        bool RegisterReturn(VehicleReturnDto vehicleReturnDto);
    }
}