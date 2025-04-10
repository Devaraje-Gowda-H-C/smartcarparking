using Devscarparking.Models;
using Devscarparking.Services;
using Microsoft.AspNetCore.Mvc;

namespace Devscarparking.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VehicleController : ControllerBase
    {
        private readonly ParkingManager _parkingManager;

        public VehicleController(ParkingManager parkingManager)
        {
            _parkingManager = parkingManager;
        }

        [HttpPost("checkin")]
        public ActionResult<ParkingSlot> CheckIn([FromQuery] string vehicleNumber)
        {
            var slot = _parkingManager.CheckInVehicle(vehicleNumber);
            if (slot == null)
                return NotFound("Parking is full.");
            return Ok(slot);
        }

        [HttpPost("checkout")]
        public ActionResult<ParkingSlot> CheckOut([FromQuery] string vehicleNumber)
        {
            var slot = _parkingManager.CheckOutVehicle(vehicleNumber);
            if (slot == null)
                return NotFound("Vehicle not found.");
            return Ok(slot);
        }

        [HttpGet("search")]
        public ActionResult<ParkingSlot> Search([FromQuery] string vehicleNumber)
        {
            var slot = _parkingManager.SearchVehicle(vehicleNumber);
            if (slot == null)
                return NotFound("Vehicle not found.");
            return Ok(slot);
        }
    }
}
