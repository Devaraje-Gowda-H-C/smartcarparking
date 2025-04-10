using Devscarparking.Models;
using Devscarparking.Services;
using Microsoft.AspNetCore.Mvc;

namespace Devscarparking.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ParkingController : ControllerBase
    {
        private readonly ParkingManager _parkingManager;

        public ParkingController(ParkingManager parkingManager)
        {
            _parkingManager = parkingManager;
        }

        [HttpPost("initialize")]
        public IActionResult InitializeParking([FromBody] Dictionary<string, int> levelSlotMap)
        {
            _parkingManager.InitializeParking(levelSlotMap);
            return Ok("Parking lot initialized successfully.");
        }

        [HttpGet("available")]
        public ActionResult<List<ParkingSlot>> GetAvailableSlots()
        {
            var slots = _parkingManager.ParkingLot.Levels
                .SelectMany(l => l.Slots)
                .Where(s => !s.IsOccupied)
                .ToList();

            return Ok(slots);
        }

        [HttpGet("searchSlot")]
        public ActionResult<ParkingSlot> SearchSlotById([FromQuery] string slotId)
        {
            foreach (var level in _parkingManager.ParkingLot.Levels)
            {
                var slot = level.Slots.FirstOrDefault(s => s.SlotId == slotId);
                if (slot != null)
                    return Ok(slot);
            }

            return NotFound("Slot not found.");
        }
    }
}
///parkingcontrroller