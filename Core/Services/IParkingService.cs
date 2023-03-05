using Core.Models;
using Core.Shared;

namespace Core.Services
{
    public interface IParkingService
    {
        int GetAvailableSpaces();
        IEnumerable<ParkedInfoDto> GetInfoAllParked();
        Result<(decimal charges, decimal discount)> GetCurrentAccumulatedCharge(string licensePlate);
        Result Park(ParkNewVehicleDto vehicle);
        Result<decimal> Exit(string licensePlate);
    }
}
