using Core.Models;
using Core.Models.Exceptions;
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
            try
            {
                var availableSpaces = _parkingService.GetAvailableSpaces();
                return Ok(availableSpaces);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet(nameof(GetInfoAllParked))]
        public IActionResult GetInfoAllParked()
        {
            try
            {
                var allParkedInfo = _parkingService.GetInfoAllParked();
                return Ok(allParkedInfo);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet(nameof(GetCurrentAccumulatedCharge))]
        public IActionResult GetCurrentAccumulatedCharge(string licensePlate)
        {
            try
            {
                (decimal charges, decimal discount) = _parkingService.GetCurrentAccumulatedCharge(licensePlate);

                return Ok(charges - discount);
            }
            catch (Exception ex) when (ex is VehicleIsNotParkedException)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost(nameof(Park))]
        public IActionResult Park([FromBody] ParkNewVehicleDto vehicle)
        {
            try
            {
                _parkingService.Park(vehicle);
                return Ok();
            }
            catch (Exception ex) when (ex is VehicleIsParkedException || ex is NotEnoughtSpaceForVehicleException)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost(nameof(Exit))]
        public IActionResult Exit([FromBody] string licensePlate)
        {
            try
            {
                var charges = _parkingService.Exit(licensePlate);
                return Ok(charges);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
