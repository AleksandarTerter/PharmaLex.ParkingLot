using Data.Data.Enities;

namespace Core.Models.Exceptions
{
    [Serializable]
    public class NotEnoughtSpaceForVehicleException : Exception
    {
        public NotEnoughtSpaceForVehicleException() { }

        public NotEnoughtSpaceForVehicleException(CategoryEntity category)
            : base($"Not enought space for vehicle category '{category}'") { }
    }
}
