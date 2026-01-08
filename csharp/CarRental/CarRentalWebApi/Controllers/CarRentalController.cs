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

            RentalReceiptDto price = _vehicleRentalService.CalculateRentalPrice(vehicleReturn.RentalBookingNumber, 1.5, 1.6);

            return Ok(price);
        }

        // GET: api/<CarRentalController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<CarRentalController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CarRentalController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CarRentalController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CarRentalController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
