using Data.Data.Enities;
using Microsoft.EntityFrameworkCore;

namespace Data.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<ParkedVehicleEnity> ParkedVehicles { get; set; }
        public DbSet<ArchivedParkingVehicleEntity> ArchivedParkingVehicleEntities { get; set; }
        public DbSet<CategoryEntity> Categories { get; set; }
        public DbSet<DiscountEntity> Discounts { get; set; }
    }
}
