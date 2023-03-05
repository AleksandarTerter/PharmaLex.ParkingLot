namespace Core.Models.Exceptions
{
    [Serializable]
    public class VehicleIsNotParkedException : Exception
    {
        public VehicleIsNotParkedException() { }

        public VehicleIsNotParkedException(string licensePlate)
            : base($"Vehicle whit plate '{licensePlate}' is not parked") { }
    }
}
