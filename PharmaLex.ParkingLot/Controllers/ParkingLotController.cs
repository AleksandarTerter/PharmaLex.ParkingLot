using Core.Models;
using Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace ParkingLotService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ParkingLotController : ControllerBase
    {
        private readonly ILogger<ParkingLotController> _logger;
        private readonly IParkingService _parkingService;

        public ParkingLotController(ILogger<ParkingLotController> logger, IParkingService parkingService)
        {
            _logger = logger;
            _parkingService = parkingService;
        }

        [HttpGet(nameof(GetAvailableSpaces))]
        public IActionResult GetAvailableSpaces()
        {
            return Ok(_parkingService.GetAvailableSpaces());
        }

        [HttpGet(nameof(GetInfoAllParked))]
        public IActionResult GetInfoAllParked()
        {
            return Ok(_parkingService.GetInfoAllParked());
        }

        [HttpGet(nameof(GetCurrentAccumulatedCharge))]
        public IActionResult GetCurrentAccumulatedCharge(string licensePlate)
        {
            var result = _parkingService.GetCurrentAccumulatedCharge(licensePlate);
            return result.IsSuccess
                ? Ok(result.Value.charges - result.Value.discount)
                : BadRequest(result.Error);
        }

        [HttpPost(nameof(Park))]
        public IActionResult Park([FromBody] ParkNewVehicleDto vehicle)
        {
            var result = _parkingService.Park(vehicle);
            return result.IsSuccess ? Ok() : BadRequest(result.Error);
        }

        [HttpPost(nameof(Exit))]
        public IActionResult Exit([FromBody] string licensePlate)
        {
            var result = _parkingService.Exit(licensePlate);
            return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
        }
    }
}
