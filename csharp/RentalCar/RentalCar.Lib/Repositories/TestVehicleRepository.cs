using RentalCar.Lib.Models;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace RentalCar.Lib.Repositories
{
    public class TestVehicleRepository
    {
        private List<Vehicle> _vehicles = new List<Vehicle>
        {
            new Vehicle
            {
                Id = 1,
                RegistrationNumber = "CDE90T",
                Brand = "Volvo",
                Model = "XC90",
                FriendlyName = "Red XC90",
                DateAcquired = DateTime.Now.AddYears(-5),
                OdometerReading = 15000,
            },
            new Vehicle {
                Id = 2,
                RegistrationNumber = "MNE401",
                Brand = "Volkswagen",
                Model = "Golf Sportswagen",
                FriendlyName = "Silver Golf Combi",
                DateAcquired = DateTime.Now.AddYears(-3),
                OdometerReading = 10000,
            },
            new Vehicle {
                Id = 3,
                RegistrationNumber = "SEC201",
                Brand = "Toyota",
                Model = "Corolla Touring Sports",
                FriendlyName = "Black Corolla Combi",
                DateAcquired = DateTime.Now.AddYears(-4),
                OdometerReading = 7000,
            }
        };

        /// <summary>
        /// This method checks if a vehicle exists. It is modeled this way
        /// because a lot of databases allow to check for the existance of 
        /// a row without retrieving all the data.
        /// </summary>
        /// <param name="vehicleReistrationNumber"></param>
        /// <returns></returns>
        public bool CheckIfVehicleExists(string vehicleReistrationNumber)
        {
            var result = _vehicles.Exists(v => v.RegistrationNumber == vehicleReistrationNumber);
            return result;
        }

        /// <summary>
        /// Gets a vehicle from a database.
        /// </summary>
        /// <param name="vehicleReregistrationNumber"></param>
        /// <returns>The vehicle if it exists, null otherwise</returns>
        public Vehicle GetVehicle(string vehicleReregistrationNumber)
        {
            Vehicle vehicle = _vehicles.FirstOrDefault(v => v.RegistrationNumber == vehicleReregistrationNumber);
            return vehicle;
        }
    }
}
