namespace CarRentalWebApi.Models.Domain
{
    public class VehicleReturnDomain
    {
        public long RentalBookingNumber { get; set; }
        public DateTimeOffset DateTimeOfReturn { get; set; }
        public double ReturnOdometerReading { get; set; }
    }
}
