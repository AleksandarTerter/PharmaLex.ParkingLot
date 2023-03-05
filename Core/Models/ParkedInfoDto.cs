namespace Core.Models
{
    public class ParkedInfoDto
    {
        public string LicensePlate { get; set; }
        public DateTime DateTimeOfEntry { get; set; }
        public decimal CurrentAccumulatedCharge { get; set; }
        public decimal CalculatedDiscount { get; set; }
    }
}