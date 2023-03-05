using System.ComponentModel.DataAnnotations;

namespace Data.Data.Enities
{
    public class CategoryEntity
    {
        public byte Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public byte NeededSlots { get; set; }
        [Required]
        public decimal DailyChargePerHour { get; set; }
        [Required]
        public decimal OvernightChargePerHour { get; set; }
    }
}
