using Core.Models;
using Core.Services.Helpers;
using Core.Shared;
using Data;
using Data.Data.Enities;

namespace Core.Services
{
    public class ParkingService : IParkingService
    {
        private readonly int ParkingCapacity = 200;
        private readonly TimeSpan DailyHourStart = new(8, 00, 00);
        private readonly TimeSpan NightHourStart = new(18, 00, 00);
        protected readonly IUnitOfWork unitOfWork;

        public ParkingService(IUnitOfWork unitOfWork) => this.unitOfWork = unitOfWork;

        public Result<decimal> Exit(string licensePlate)
        {
            ParkedVehicleEnity? parked = GetParked(licensePlate);
            if (parked == null)
                return Result<decimal>.Failure(DomainErrors.VehicleIsNotParked);

            unitOfWork.ParkedVehicleRepository.Delete(licensePlate);
            unitOfWork.ArchivedParkingVehicleRepository.Insert(new ArchivedParkingVehicleEntity()
            {
                LicensePlate = parked.LicensePlate,
                DateTimeOfEntry = parked.DateTimeOfEntry,
                DateTimeOfExit = DateTime.Now,
                CategoryId = parked.CategoryId,
                DiscountId = parked.DiscountId,
            });
            unitOfWork.Save();
            var parkedInfo = GetParkedInfo(parked);

            return parkedInfo.CurrentAccumulatedCharge - parkedInfo.CalculatedDiscount;
        }

        public int GetAvailableSpaces()
        {
            var usedSpace = unitOfWork.ParkedVehicleRepository.Get(includeProperties: "Category").Sum(p => p.Category.NeededSlots);

            return ParkingCapacity - usedSpace;
        }

        public Result<(decimal charges, decimal discount)> GetCurrentAccumulatedCharge(string licensePlate)
        {
            ParkedVehicleEnity? parked = GetParked(licensePlate);
            if (parked == null)
                return Result<(decimal charges, decimal discount)>.Failure(DomainErrors.VehicleIsNotParked);

            var parkedInfo = GetParkedInfo(parked);
            return (parkedInfo.CurrentAccumulatedCharge, parkedInfo.CalculatedDiscount);
        }

        public Result Park(ParkNewVehicleDto vehicle)
        {
            if (vehicle.Discount != null && unitOfWork.DiscountRepository.GetByID((byte)vehicle.Discount) == null)
                return Result.Failure(DomainErrors.InvalidDiscount);

            if (unitOfWork.ParkedVehicleRepository.GetByID(vehicle.LicensePlate) != null)
                return Result.Failure(DomainErrors.VehicleIsNotParked);

            var category = unitOfWork.CategoryRepository.GetByID(vehicle.Category);
            if (category == null)
                return Result.Failure(DomainErrors.InvalidCategoy);

            if (!CanPark(category))
                return Result.Failure(DomainErrors.NotEnoughtSpace);

            unitOfWork.ParkedVehicleRepository.Insert(new ParkedVehicleEnity()
            {
                LicensePlate = vehicle.LicensePlate,
                CategoryId = vehicle.Category,
                DiscountId = vehicle.Discount
            });
            unitOfWork.Save();

            return Result.Success();
        }

        public IEnumerable<ParkedInfoDto> GetInfoAllParked()
        {
            return unitOfWork.ParkedVehicleRepository.Get(includeProperties: "Category,Discount")
                .Select(GetParkedInfo);
        }

        private bool CanPark(CategoryEntity category)
        {
            return GetAvailableSpaces() - category.NeededSlots >= 0;
        }

        private ParkedVehicleEnity? GetParked(string licensePlate)
        {
            return unitOfWork.ParkedVehicleRepository
                .Get(filter: p => p.LicensePlate == licensePlate, includeProperties: "Category,Discount")
                .FirstOrDefault();
        }

        private ParkedInfoDto GetParkedInfo(ParkedVehicleEnity parked)
        {
            (int dailyStayInHours, int overnightStayInHours) = ParkingTimeHelper.GetDailyAndOvernightTimesSpans(parked.DateTimeOfEntry, DailyHourStart, NightHourStart);
            (decimal charges, decimal discount) = ChargesHelper.GetChargeAndDiscount(parked.Category.DailyChargePerHour, parked.Category.OvernightChargePerHour, dailyStayInHours, overnightStayInHours, parked.Discount);
            return new ParkedInfoDto()
            {
                LicensePlate = parked.LicensePlate,
                DateTimeOfEntry = parked.DateTimeOfEntry,
                CurrentAccumulatedCharge = charges,
                CalculatedDiscount = discount
            };
        }
    }
}
