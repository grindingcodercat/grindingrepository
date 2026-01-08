using CarRentalWebApi.Models.Domain;

namespace CarRentalWebApi.Services
{
    public interface IRentalRepository
    {
        VehiclePickUpDomain GetVehiclePickupData(long rentalBookingNumber);
        public VehicleReturnDomain GetVehicleReturnData(long rentalBookingNumber);
        VehiclePickUpDomain RegisterCarPickUp(VehiclePickUpDomain model);
        VehicleReturnDomain RegisterCarReturn(VehicleReturnDomain model);
    }
}
