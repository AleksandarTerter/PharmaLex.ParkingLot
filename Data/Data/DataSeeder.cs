using Data.Data.Enities;

namespace Data.Data
{
    public class DataSeeder
    {
        public static void SeedCategories(DataContext context)
        {
            if (!context.Categories.Any())
            {
                var countries = new List<CategoryEntity> {
                    new() {Id = 1, Name = "A", Description = "cars/motorcycles", NeededSlots = 1, DailyChargePerHour = 3, OvernightChargePerHour = 2},
                    new() {Id = 2, Name = "B", Description = "vans", NeededSlots = 2, DailyChargePerHour = 6, OvernightChargePerHour = 4},
                    new() {Id = 3, Name = "C", Description = "bus/trucks", NeededSlots = 4, DailyChargePerHour = 12, OvernightChargePerHour = 8},
                };

                context.AddRange(countries);
                context.SaveChanges();
            }
        }

        public static void SeedDiscounts(DataContext context)
        {
            if (!context.Discounts.Any())
            {
                var countries = new List<DiscountEntity> {
                    new() {Id = 1, Name = "Silver", Percentage = 10 },
                    new() {Id = 2, Name = "Gold", Percentage = 15 },
                    new() {Id = 3, Name = "Platinum", Percentage = 20 },
                };

                context.AddRange(countries);
                context.SaveChanges();
            }
        }
    }
}
