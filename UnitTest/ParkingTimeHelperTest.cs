using Core.Services.Helpers;

namespace UnitTest
{
    public class ParkingTimeHelperTest
    {
        private static readonly TimeSpan dailyHourStart = new(1, 00, 00);
        private static readonly TimeSpan overnightHourStart = new(2, 00, 00);

        [Fact]
        public void ParkBeforeDailyStart_LeaveBeforeDailyStart()
        {
            TimeSpan dailyStay = ParkingTimeHelper.GetDailyStay(
                new(2023, 3, 5, 0, 00, 00),
                new(2023, 3, 5, 1, 00, 00), dailyHourStart, overnightHourStart);

            Assert.Equal(new(0, 00, 00), dailyStay);
        }

        [Fact]
        public void ParkAfterDailyEnd_LeaveAfterDailyEnd()
        {
            TimeSpan dailyStay = ParkingTimeHelper.GetDailyStay(
                new(2023, 3, 5, 2, 00, 00),
                new(2023, 3, 5, 3, 00, 00), dailyHourStart, overnightHourStart);

            Assert.Equal(new(0, 00, 00), dailyStay);
        }

        [Fact]
        public void ParkBeforeDailyStart_LeaveAfterDailyEnd()
        {
            TimeSpan dailyStay = ParkingTimeHelper.GetDailyStay(
                new(2023, 3, 5, 0, 00, 00),
                new(2023, 3, 5, 3, 00, 00), dailyHourStart, overnightHourStart);

            Assert.Equal(dailyStay, new(1, 00, 00));
        }

        [Fact]
        public void ParkOnDailyStart_LeaveOnDailyEnd()
        {
            TimeSpan dailyStay = ParkingTimeHelper.GetDailyStay(
                new(2023, 3, 5, 1, 00, 00),
                new(2023, 3, 5, 2, 00, 00), dailyHourStart, overnightHourStart);

            Assert.Equal(dailyStay, new(1, 00, 00));
        }

        [Fact]
        public void ParkBeforeDailyStart_LeaveBeforeDailyEnd()
        {
            TimeSpan dailyStay = ParkingTimeHelper.GetDailyStay(
                new(2023, 3, 5, 0, 00, 00),
                new(2023, 3, 5, 1, 30, 00), dailyHourStart, overnightHourStart);

            Assert.Equal(dailyStay, new(0, 30, 00));
        }

        [Fact]
        public void ParkAfterDailyStart_LeaveAfterDailyEnd()
        {
            TimeSpan dailyStay = ParkingTimeHelper.GetDailyStay(
                new(2023, 3, 5, 1, 30, 00),
                new(2023, 3, 5, 3, 00, 00), dailyHourStart, overnightHourStart);

            Assert.Equal(dailyStay, new(0, 30, 00));
        }

        [Fact]
        public void ParkAfterDailyStart_LeaveBeforeDailyEnd()
        {
            TimeSpan dailyStay = ParkingTimeHelper.GetDailyStay(
                new(2023, 3, 5, 1, 30, 00),
                new(2023, 3, 5, 1, 35, 00), dailyHourStart, overnightHourStart);

            Assert.Equal(dailyStay, new(0, 05, 00));
        }

        [Fact]
        public void ParkBeforeDailyStart_LeaveNextDay_BeforeDailyStart()
        {
            TimeSpan dailyStay = ParkingTimeHelper.GetDailyStay(
                new(2023, 3, 5, 0, 00, 00),
                new(2023, 3, 6, 0, 00, 00), dailyHourStart, overnightHourStart);

            Assert.Equal(dailyStay, new(1, 00, 00));
        }

        [Fact]
        public void ParkBeforeDailyStart_LeaveNextDay_AfterDailyStart()
        {
            TimeSpan dailyStay = ParkingTimeHelper.GetDailyStay(
                new(2023, 3, 5, 0, 00, 00),
                new(2023, 3, 6, 1, 30, 00), dailyHourStart, overnightHourStart);

            Assert.Equal(dailyStay, new(1, 30, 00));
        }

        [Fact]
        public void ParkBeforeDailyStart_LeaveNextDay_AfterDailyEnd()
        {
            TimeSpan dailyStay = ParkingTimeHelper.GetDailyStay(
                new(2023, 3, 5, 0, 00, 00),
                new(2023, 3, 6, 3, 30, 00), dailyHourStart, overnightHourStart);

            Assert.Equal(dailyStay, new(2, 00, 00));
        }

        [Fact]
        public void ParkAfterDailyStart_LeaveNextDay_BeforeDailyStart()
        {
            TimeSpan dailyStay = ParkingTimeHelper.GetDailyStay(
                new(2023, 3, 5, 1, 30, 00),
                new(2023, 3, 6, 0, 00, 00), dailyHourStart, overnightHourStart);

            Assert.Equal(dailyStay, new(0, 30, 00));
        }

        [Fact]
        public void ParkAfterDailyStart_LeaveNextDay_AfterDailyStart()
        {
            TimeSpan dailyStay = ParkingTimeHelper.GetDailyStay(
                new(2023, 3, 5, 1, 30, 00),
                new(2023, 3, 6, 1, 30, 00), dailyHourStart, overnightHourStart);

            Assert.Equal(dailyStay, new(1, 00, 00));
        }

        [Fact]
        public void ParkAfterDailyStart_LeaveNextDay_AfterDailyEnd()
        {
            TimeSpan dailyStay = ParkingTimeHelper.GetDailyStay(
                new(2023, 3, 5, 1, 30, 00),
                new(2023, 3, 6, 3, 30, 00), dailyHourStart, overnightHourStart);

            Assert.Equal(dailyStay, new(1, 30, 00));
        }

        [Fact]
        public void ParkAfterDailyEnd_LeaveNextDay_BeforeDailyStart()
        {
            TimeSpan dailyStay = ParkingTimeHelper.GetDailyStay(
                new(2023, 3, 5, 2, 00, 00),
                new(2023, 3, 6, 0, 00, 00), dailyHourStart, overnightHourStart);

            Assert.Equal(dailyStay, new(0, 00, 00));
        }

        [Fact]
        public void ParkAfterDailyEnd_LeaveNextDay_AfterDailyStart()
        {
            TimeSpan dailyStay = ParkingTimeHelper.GetDailyStay(
                new(2023, 3, 5, 2, 00, 00),
                new(2023, 3, 6, 1, 30, 00), dailyHourStart, overnightHourStart);

            Assert.Equal(dailyStay, new(0, 30, 00));
        }

        [Fact]
        public void ParkAfterDailyEnd_LeaveNextDay_AfterDailyEnd()
        {
            TimeSpan dailyStay = ParkingTimeHelper.GetDailyStay(
                new(2023, 3, 5, 2, 00, 00),
                new(2023, 3, 6, 3, 30, 00), dailyHourStart, overnightHourStart);

            Assert.Equal(dailyStay, new(1, 00, 00));
        }
    }
}