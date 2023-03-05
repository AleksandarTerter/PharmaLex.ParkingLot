using System.ComponentModel.DataAnnotations;

namespace Data.Data.Enities
{
    public class DiscountEntity
    {
        public byte Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Percentage { get; set; }
    }
}
