namespace Core.Models.Exceptions
{
    [Serializable]
    public class VehicleIsParkedException : Exception
    {
        public VehicleIsParkedException() { }

        public VehicleIsParkedException(string licensePlate)
            : base($"Vehicle whit plate '{licensePlate}' is already parked") { }
    }
}
