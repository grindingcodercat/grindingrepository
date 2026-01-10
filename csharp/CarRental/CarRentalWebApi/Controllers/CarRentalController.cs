using CarRentalWebApi.Models;
using CarRentalWebApi.Models.DTO;
using CarRentalWebApi.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarRentalWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarRentalController : ControllerBase
    {
        private readonly IVehicleRentalService _vehicleRentalService;

        public CarRentalController(IVehicleRentalService vehicleRentalService)
        {
            _vehicleRentalService = vehicleRentalService;
        }

        [HttpPost("pickup")]
        public ActionResult<long> PickUpCar(VehiclePickUpDto vehiclePickup)
        {
            long rentalRegistrationNumber = _vehicleRentalService.RegisterPickup(vehiclePickup);
            return rentalRegistrationNumber;
        }

        [HttpPost("return")]
        public ActionResult<RentalReceiptDto> ReturnCar(VehicleReturnDto vehicleReturn)
        {
            bool result = _vehicleRentalService.RegisterReturn(vehicleReturn);

            if (!result)
            {
                return BadRequest();
            }

            // For the purpose of this demo, we will use hard coded values.
            // In a real production system these values will probably be retrieved
            // elsewhere from a database.
            double baseDayRental = 1.5;
            double baseKmPrice = 1.6;

            RentalReceiptDto price = _vehicleRentalService.CalculateRentalPrice(vehicleReturn.RentalBookingNumber, baseDayRental, baseKmPrice);

            return Ok(price);
        }
    }
}
