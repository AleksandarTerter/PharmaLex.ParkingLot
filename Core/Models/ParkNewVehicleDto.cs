namespace Core.Models;

public class ParkNewVehicleDto
{
    public string LicensePlate { get; set; }
    public byte Category { get; set; }
    public byte? Discount { get; set; }
}