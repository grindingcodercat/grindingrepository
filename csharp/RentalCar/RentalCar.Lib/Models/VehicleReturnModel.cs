using System;
using System.Collections.Generic;
using System.Text;

namespace RentalCar.Lib.Models
{
    public class VehicleReturnModel
    {
        public long BookingNumber { get; set; }
        public DateTimeOffset DateTimeOfReturn { get; set; }
        public double ReturnOdometerReading  { get; set; }
    }
}
