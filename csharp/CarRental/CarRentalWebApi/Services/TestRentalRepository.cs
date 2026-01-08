using CarRentalWebApi.Models.Domain;

namespace CarRentalWebApi.Services
{
    public class TestRentalRepository : IRentalRepository
    {
        // This is to simulate auto assigned booking numbers coming from a database
        private static long _vehicleRegistrationId = 1;
        private static long _vehicleReturnId = 1;

        /// <summary>
        /// Data structures to store data for this exercise.
        /// In a true production system this data would probably have been persisted 
        /// into a database.
        /// </summary>
        private List<VehiclePickUpDomain> _vehiclePickups = new List<VehiclePickUpDomain>();
        private List<VehicleReturnDomain> _vehicleReturns = new List<VehicleReturnDomain>();

        /// <summary>
        /// Registers a vehicle pickup. 
        /// This method assumes that model validation has already occured
        /// </summary>
        /// <param name="model"></param>
        public VehiclePickUpDomain RegisterCarPickUp(VehiclePickUpDomain model)
        {
            model.RentalBookingNumber = _vehicleRegistrationId++;
            _vehiclePickups.Add(model);
            return model;
        }

        /// <summary>
        /// Registers a vehicle return.
        /// This method assumes that model validation has already occured
        /// </summary>
        /// <param name="model"></param>
        public VehicleReturnDomain RegisterCarReturn(VehicleReturnDomain model)
        {
            _vehicleReturns.Add(model);
            return model;
        }

        public VehiclePickUpDomain GetVehiclePickupData(long rentalBookingNumber)
        {
            VehiclePickUpDomain result = _vehiclePickups.FirstOrDefault(p => p.RentalBookingNumber == rentalBookingNumber);
            return result;
        }

        public VehicleReturnDomain GetVehicleReturnData(long rentalBookingNumber) 
        {
            VehicleReturnDomain result = _vehicleReturns.FirstOrDefault(r => r.RentalBookingNumber == rentalBookingNumber);
            return result;
        }

    }
}
