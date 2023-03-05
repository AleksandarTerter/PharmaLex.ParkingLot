using Data.Data.Enities;

namespace Core.Services.Helpers
{
    public static class ChargesHelper
    {
        public static (decimal charges, decimal discount) GetChargeAndDiscount(decimal dailyCharges, decimal overnightCharges, int dailyStayInHours, int overnightStayInHours, DiscountEntity? discountType)
        {
            var charges = dailyStayInHours * dailyCharges + overnightStayInHours * overnightCharges;
            var discount = CalculateDiscount(charges, discountType);

            return (charges, discount);
        }

        private static decimal CalculateDiscount(decimal accumulatedCharge, DiscountEntity? discount)
        {
            return accumulatedCharge * (discount?.Percentage ?? 0) / 100;
        }
    }
}
