namespace CarRentalWebApi.Models.Domain
{
    public class VehiclePickUpDomain
    {
        public long RentalBookingNumber { get; set; }
        public string CarRegistrationNumber { get; set; }
        public string CustomerSocialSecurityNumber { get; set; }
        public VehicleType VehicleType { get; set; }
        public DateTimeOffset PickUpDateTime { get; set; }
        public double PickUpOdometerReading { get; set; }
    }
}
