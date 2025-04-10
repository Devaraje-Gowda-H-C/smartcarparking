using Devscarparking.Models;

namespace Devscarparking.Services
{
    public class ParkingManager
    {
        public ParkingLot ParkingLot { get; set; } = new ParkingLot();

        public void InitializeParking(Dictionary<string, int> levelSlotMap)
        {
            ParkingLot.Levels.Clear();

            foreach (var kvp in levelSlotMap)
            {
                var level = new Level { LevelName = kvp.Key };
                for (int i = 1; i <= kvp.Value; i++)
                {
                    level.Slots.Add(new ParkingSlot
                    {
                        SlotId = $"{kvp.Key}-S{i}",
                        IsOccupied = false
                    });
                }
                ParkingLot.Levels.Add(level);
            }
        }

        public ParkingSlot? CheckInVehicle(string vehicleNumber)
        {
            var slot = ParkingLot.GetNextAvailableSlot();
            if (slot != null)
            {
                slot.IsOccupied = true;
                slot.VehicleNumber = vehicleNumber;
                return slot;
            }
            return null;
        }

        public ParkingSlot? CheckOutVehicle(string vehicleNumber)
        {
            foreach (var level in ParkingLot.Levels)
            {
                foreach (var slot in level.Slots)
                {
                    if (slot.IsOccupied && slot.VehicleNumber == vehicleNumber)
                    {
                        slot.IsOccupied = false;
                        slot.VehicleNumber = null;
                        return slot;
                    }
                }
            }
            return null;
        }

        public ParkingSlot? SearchVehicle(string vehicleNumber)
        {
            foreach (var level in ParkingLot.Levels)
            {
                foreach (var slot in level.Slots)
                {
                    if (slot.IsOccupied && slot.VehicleNumber == vehicleNumber)
                    {
                        return slot;
                    }
                }
            }
            return null;
        }
    }
}
