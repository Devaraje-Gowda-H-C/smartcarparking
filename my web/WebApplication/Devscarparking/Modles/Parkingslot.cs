namespace Devscarparking.Models
{
    public class ParkingSlot
    {
        public string SlotId { get; set; } = "";
        public bool IsOccupied { get; set; } = false;
        public string? VehicleNumber { get; set; }
    }
}
