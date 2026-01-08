using CarRentalWebApi.Models;
using CarRentalWebApi.Models.Domain;
using CarRentalWebApi.Models.DTO;

namespace CarRentalWebApi.Services
{
    public class VehicleRentalService : IVehicleRentalService
    {
        private IRentalRepository _rentalRepository;

        public VehicleRentalService(IRentalRepository rentalRepository)
        {
            _rentalRepository = rentalRepository;
        }

        public long RegisterPickup(VehiclePickUpDto vehiclePickUpDto)
        {
            VehiclePickUpDomain pickUpDomain = new VehiclePickUpDomain
            {
                CarRegistrationNumber = vehiclePickUpDto.CarRegistrationNumber,
                CustomerSocialSecurityNumber = vehiclePickUpDto.CustomerSocialSecurityNumber,
                VehicleType = vehiclePickUpDto.VehicleType,
                PickUpDateTime = vehiclePickUpDto.PickUpDateTime,
                PickUpOdometerReading = vehiclePickUpDto.PickUpOdometerReading,
            };

            VehiclePickUpDomain result = _rentalRepository.RegisterCarPickUp(pickUpDomain);
            return result.RentalBookingNumber;
        }

        public bool RegisterReturn(VehicleReturnDto vehicleReturnDto)
        {
            VehicleReturnDomain returnDomain = new VehicleReturnDomain
            {
                RentalBookingNumber = vehicleReturnDto.RentalBookingNumber,
                DateTimeOfReturn = vehicleReturnDto.DateTimeOfReturn,
                ReturnOdometerReading = vehicleReturnDto.ReturnOdometerReading
            };

            VehicleReturnDomain result = _rentalRepository.RegisterCarReturn(returnDomain);

            if (result == null)
            {
                return false;
            }

            return true;
        }

        public RentalReceiptDto CalculateRentalPrice(long rentalBookingNumber, double baseDayRental, double baseKmPrice)
        {
            VehiclePickUpDomain pickUpData = _rentalRepository.GetVehiclePickupData(rentalBookingNumber);
            VehicleReturnDomain returnData = _rentalRepository.GetVehicleReturnData(rentalBookingNumber);

            double numberOfKm = returnData.ReturnOdometerReading - pickUpData.PickUpOdometerReading;

            double numberOfDays = (returnData.DateTimeOfReturn - pickUpData.PickUpDateTime).TotalDays;

            double price = 0;

            price = pickUpData.VehicleType switch
            {
                VehicleType.SmallCar => CalculateSmallCarPrice(baseDayRental, numberOfDays),
                VehicleType.Combi => CalculateCombiPrice(baseDayRental, numberOfDays, baseKmPrice, numberOfKm),
                VehicleType.Truck => CalculateTruckPrice(baseDayRental, numberOfDays, baseKmPrice, numberOfKm),
                _ => 0,
            };
            RentalReceiptDto receipt = new RentalReceiptDto
            {
                RentalPrice = price,
            };

            return receipt;

        }

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
