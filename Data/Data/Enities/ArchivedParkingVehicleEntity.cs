using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Data.Data.Enities
{
    [PrimaryKey(nameof(LicensePlate), nameof(DateTimeOfEntry))]
    public class ArchivedParkingVehicleEntity
    {
        public string LicensePlate { get; set; }
        public DateTime DateTimeOfEntry { get; set; }
        public DateTime DateTimeOfExit { get; set; }
        [Required]
        public byte CategoryId { get; set; }
        public CategoryEntity Category { get; set; }
        public byte? DiscountId { get; set; }
        public DiscountEntity? Discount { get; set; }
    }
}
