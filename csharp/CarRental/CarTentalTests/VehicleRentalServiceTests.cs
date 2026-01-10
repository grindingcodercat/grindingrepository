using CarRentalWebApi.Models;
using CarRentalWebApi.Models.Domain;
using CarRentalWebApi.Models.DTO;
using CarRentalWebApi.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarTentalTests
{
    /// <summary>
    /// All possible unit tests have not been implemented. 
    /// Only the important happy cases.
    /// </summary>
    public class VehicleRentalServiceTests
    {
        public const double BASE_DAY_RENTAL = 1.5;
        public const double BASE_KM_PRICE = 1.6;

        public readonly IVehicleRentalService _vehicleRentalService;

        public VehicleRentalServiceTests()
        {
            ServiceCollection services = new ServiceCollection();
            services.AddSingleton<IRentalRepository, TestRentalRepository>();
            services.AddTransient<IVehicleRentalService, VehicleRentalService>();
            var provider = services.BuildServiceProvider();
            _vehicleRentalService = provider.GetRequiredService<IVehicleRentalService>();
        }

        [Fact]
        public void TestSmallCarPriceCalculator()
        {
            double numberOfDays = 2.0;

            double price = _vehicleRentalService.CalculateSmallCarPrice(BASE_DAY_RENTAL, numberOfDays);

            Assert.Equal(3,0, price);
        }

        [Fact]
        public void TestCombiPriceCalculator() 
        {
            double numberOfDays = 3.0;
            double numberOfKm = 10;

            double price = _vehicleRentalService.CalculateCombiPrice(BASE_DAY_RENTAL, numberOfDays, BASE_KM_PRICE, numberOfKm);

            Assert.Equal(21.85, price);
        }

        [Fact]
        public void TestTruckPriceCalculator()
        {
            double numberOfDays = 4.0;
            double numberOfKm = 11;

            double price = _vehicleRentalService.CalculateTruckPrice(BASE_DAY_RENTAL, numberOfDays, BASE_KM_PRICE, numberOfKm);

            // Assert equal within two decimal places, because we are calculating currency
            Assert.Equal(35.4, price, 2);
        }

        [Fact]
        public void TestCalculatePriceRentalLogicForSmallCar()
        {
            VehiclePickUpDto vehiclePickup = new VehiclePickUpDto
            {
                CarRegistrationNumber = "ABC123",
                CustomerSocialSecurityNumber = "19900101-1234",
                VehicleType = VehicleType.SmallCar,
                PickUpDateTime = new DateTimeOffset(new DateTime(2025, 01, 01)),
                PickUpOdometerReading = 1000,
            };

            long rentalBookingNumber = _vehicleRentalService.RegisterPickup(vehiclePickup);

            VehicleReturnDto vehicleReturn = new VehicleReturnDto
            {
                RentalBookingNumber = rentalBookingNumber,
                DateTimeOfReturn = new DateTimeOffset(new DateTime(2025, 01, 10)),
                ReturnOdometerReading = 1100
            };

            _vehicleRentalService.RegisterReturn(vehicleReturn);

            RentalReceiptDto result = _vehicleRentalService.CalculateRentalPrice(rentalBookingNumber, BASE_DAY_RENTAL, BASE_KM_PRICE);

            Assert.Equal(13.5, result.RentalPrice);
        }

        [Fact]
        public void TestCalculatePriceRentalLogicForCombiCar()
        {
            VehiclePickUpDto vehiclePickup = new VehiclePickUpDto
            {
                CarRegistrationNumber = "ABC125",
                CustomerSocialSecurityNumber = "19900105-2345",
                VehicleType = VehicleType.Combi,
                PickUpDateTime = new DateTimeOffset(new DateTime(2025, 02, 01)),
                PickUpOdometerReading = 1000,
            };

            long rentalBookingNumber = _vehicleRentalService.RegisterPickup(vehiclePickup);

            VehicleReturnDto vehicleReturn = new VehicleReturnDto
            {
                RentalBookingNumber = rentalBookingNumber,
                DateTimeOfReturn = new DateTimeOffset(new DateTime(2025, 02, 10)),
                ReturnOdometerReading = 1200
            };

            _vehicleRentalService.RegisterReturn(vehicleReturn);

            RentalReceiptDto result = _vehicleRentalService.CalculateRentalPrice(rentalBookingNumber, BASE_DAY_RENTAL, BASE_KM_PRICE);

            Assert.Equal(337.55, result.RentalPrice);
        }

        [Fact]
        public void TestCalculatePriceRentalLogicForTruck()
        {
            VehiclePickUpDto vehiclePickup = new VehiclePickUpDto
            {
                CarRegistrationNumber = "ABC125",
                CustomerSocialSecurityNumber = "19900105-2345",
                VehicleType = VehicleType.Truck,
                PickUpDateTime = new DateTimeOffset(new DateTime(2025, 03, 01)),
                PickUpOdometerReading = 1000,
            };

            long rentalBookingNumber = _vehicleRentalService.RegisterPickup(vehiclePickup);

            VehicleReturnDto vehicleReturn = new VehicleReturnDto
            {
                RentalBookingNumber = rentalBookingNumber,
                DateTimeOfReturn = new DateTimeOffset(new DateTime(2025, 03, 10)),
                ReturnOdometerReading = 1250
            };

            _vehicleRentalService.RegisterReturn(vehicleReturn);

            RentalReceiptDto result = _vehicleRentalService.CalculateRentalPrice(rentalBookingNumber, BASE_DAY_RENTAL, BASE_KM_PRICE);

            Assert.Equal(620.25, result.RentalPrice);
        }
    }
}
