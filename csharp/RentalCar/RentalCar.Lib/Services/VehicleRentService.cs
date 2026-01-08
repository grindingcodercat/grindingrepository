using RentalCar.Lib.Models;
using RentalCar.Lib.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentalCar.Lib.Services
{
    public class VehicleRentService
    {
        private IRentalRepository _rentalRepository;

        public VehicleRentService(IRentalRepository rentalRepository)
        {
            _rentalRepository = rentalRepository;
        }

        public bool RegisterPickup(VehiclePickupModel pickupModel)
        {
            _rentalRepository.RegisterCarPickUp(pickupModel);
        }


    }
}
