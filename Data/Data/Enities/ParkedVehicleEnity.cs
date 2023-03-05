using System.ComponentModel.DataAnnotations;

namespace Data.Data.Enities
{
    public class ParkedVehicleEnity
    {
        [Key]
        public string LicensePlate { get; set; }
        [Required]
        public byte CategoryId { get; set; }
        public CategoryEntity Category { get; set; }
        [Required]
        public DateTime DateTimeOfEntry { get; set; } = DateTime.Now;
        public byte? DiscountId { get; set; }
        public DiscountEntity? Discount { get; set; }
    }
}
