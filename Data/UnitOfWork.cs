using Data.Data;
using Data.Data.Enities;

namespace Data
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private readonly DataContext context;
        private GenericRepository<CategoryEntity>? categoryRepository;
        private GenericRepository<DiscountEntity>? discountRepository;
        private GenericRepository<ParkedVehicleEnity>? parkedVehicleRepository;
        private GenericRepository<ArchivedParkingVehicleEntity>? archivedParkingVehicleRepository;

        public UnitOfWork(DataContext context)
        {
            this.context = context;
        }

        public GenericRepository<CategoryEntity> CategoryRepository
        {
            get
            {
                categoryRepository ??= new GenericRepository<CategoryEntity>(context);
                return categoryRepository;
            }
        }

        public GenericRepository<DiscountEntity> DiscountRepository
        {
            get
            {
                discountRepository ??= new GenericRepository<DiscountEntity>(context);
                return discountRepository;
            }
        }

        public GenericRepository<ParkedVehicleEnity> ParkedVehicleRepository
        {
            get
            {
                parkedVehicleRepository ??= new GenericRepository<ParkedVehicleEnity>(context);
                return parkedVehicleRepository;
            }
        }

        public GenericRepository<ArchivedParkingVehicleEntity> ArchivedParkingVehicleRepository
        {
            get
            {
                archivedParkingVehicleRepository ??= new GenericRepository<ArchivedParkingVehicleEntity>(context);
                return archivedParkingVehicleRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
