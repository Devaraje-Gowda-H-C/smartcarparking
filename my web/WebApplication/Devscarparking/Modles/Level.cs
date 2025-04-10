namespace Devscarparking.Models
{
    public class Level
    {
        public string LevelName { get; set; } = "";
        public List<ParkingSlot> Slots { get; set; } = new List<ParkingSlot>();
    }
}
