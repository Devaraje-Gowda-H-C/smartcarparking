namespace Devscarparking.Models
{
    public class ParkingLot
    {
        public List<Level> Levels { get; set; } = new List<Level>();

        public ParkingSlot? GetNextAvailableSlot()
        {
            foreach (var level in Levels)
            {
                foreach (var slot in level.Slots)
                {
                    if (!slot.IsOccupied)
                        return slot;
                }
            }
            return null;
        }
    }
}
