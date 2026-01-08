namespace CarRentalWebApi.Models
{
    public class VehicleReturnDto
    {
        public long RentalBookingNumber { get; set; }
        public DateTimeOffset DateTimeOfReturn { get; set; }
        public double ReturnOdometerReading { get; set; }
    }
}
