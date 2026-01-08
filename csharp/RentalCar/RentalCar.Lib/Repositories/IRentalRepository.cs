using RentalCar.Lib.Models;

namespace RentalCar.Lib.Repositories
{
    public interface IRentalRepository
    {
        VehiclePickupModel GetVehiclePickupData(long bookingNumber);
        void RegisterCarPickUp(VehiclePickupModel model);
        void RegisterCarReturn(VehicleReturnModel model);
    }
}