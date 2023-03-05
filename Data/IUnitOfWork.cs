using Data.Data.Enities;

namespace Data
{
    public interface IUnitOfWork
    {
        GenericRepository<ArchivedParkingVehicleEntity> ArchivedParkingVehicleRepository { get; }
        GenericRepository<CategoryEntity> CategoryRepository { get; }
        GenericRepository<DiscountEntity> DiscountRepository { get; }
        GenericRepository<ParkedVehicleEnity> ParkedVehicleRepository { get; }

        void Dispose();
        void Save();
    }
}