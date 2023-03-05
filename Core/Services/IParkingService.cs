using Core.Models;

namespace Core.Services
{
    public interface IParkingService
    {
        int GetAvailableSpaces();
        IEnumerable<ParkedInfoDto> GetInfoAllParked();
        (decimal charges, decimal discount) GetCurrentAccumulatedCharge(string licensePlate);
        void Park(ParkNewVehicleDto vehicle);
        decimal Exit(string licensePlate);
    }
}
