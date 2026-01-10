using CarRentalWebApi.Models;
using CarRentalWebApi.Models.DTO;

namespace CarRentalWebApi.Services
{
    public interface IVehicleRentalService
    {
        double CalculateCombiPrice(double baseDayRental, double numberOfDays, double baseKmPrice, double numberOfKm);
        double CalculateSmallCarPrice(double baseDayRental, double numberOfDays);
        double CalculateTruckPrice(double baseDayRental, double numberOfDays, double baseKmPrice, double numberOfKm);
        RentalReceiptDto CalculateRentalPrice(long rentalBookingNumber, double baseDayRental, double baseKmPrice);
        long RegisterPickup(VehiclePickUpDto vehiclePickUpDto);
        bool RegisterReturn(VehicleReturnDto vehicleReturnDto);
    }
}