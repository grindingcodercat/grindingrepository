using System;
using System.Collections.Generic;
using System.Text;

namespace RentalCar.Lib.Models
{
    public class Vehicle
    {
        public int Id { get; set; }

        public string RegistrationNumber { get; set; }

        public string Brand { get; set; }

        public string Model { get; set; }

        public string FriendlyName { get; set; }

        public DateTime DateAcquired { get; set; }

        public double OdometerReading { get; set; }
    }
}
