using System;
using System.Collections.Generic;
using System.Text;

namespace RentalCar.Lib.Models
{
    public class VehiclePickupModel
    {
        public long BookingNumber { get; set; }
        public string CarRegistrationNumber { get; set; }
        public string CustomerSocialSecurityNumber { get; set; }
        public VehicleType VehicleType { get; set; }
        public DateTimeOffset DateTimeOfPickUp { get; set; }
        public double CheckOutOdometerReading { get; set; }
    }
}
