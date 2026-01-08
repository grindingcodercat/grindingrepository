using RentalCar.Lib.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentalCar.Lib.Repositories
{
    public class TestRentalRepository : IRentalRepository
    {
        private static long _vehicleRegistrationId = 1;
        private static long _vehicleReturnId = 1;

        /// <summary>
        /// Data structures to store data for this exercise.
        /// In a true production system this data would probably have been persisted 
        /// into a database.
        /// </summary>
        private List<VehiclePickupModel> _vehiclePickups = new List<VehiclePickupModel>();
        private List<VehicleReturnModel> _vehicleReturns = new List<VehicleReturnModel>();

        /// <summary>
        /// Registers a vehicle pickup. 
        /// This method assumes that model validation has already occured
        /// </summary>
        /// <param name="model"></param>
        public void RegisterCarPickUp(VehiclePickupModel model)
        {
            model.BookingNumber = _vehicleRegistrationId++;
            _vehiclePickups.Add(model);
        }

        /// <summary>
        /// Registers a vehicle return.
        /// This method assumes that model validation has already occured
        /// </summary>
        /// <param name="model"></param>
        public void RegisterCarReturn(VehicleReturnModel model)
        {
            _vehicleReturns.Add(model);
        }

        public VehiclePickupModel GetVehiclePickupData(long bookingNumber)
        {
            VehiclePickupModel result = _vehiclePickups.FirstOrDefault(p => p.BookingNumber == bookingNumber);
            return result;
        }
    }
}
