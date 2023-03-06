namespace Core.Services.Helpers
{
    public class ParkingTimeHelper
    {
        public static (int dailyStayInHours, int overnightStayInHours) GetDailyAndOvernightTimesSpans(DateTime begining, TimeSpan dailyHourStart, TimeSpan overnightHourStart)
        {
            var leaveTime = DateTime.Now;

            var dailyStayTimeSpan = GetDailyStay(begining, leaveTime, dailyHourStart, overnightHourStart);
            var totalStayTimeSpan = leaveTime - begining;
            var nightStayTimeSpan = totalStayTimeSpan - dailyStayTimeSpan;

            return ((int)Math.Ceiling(dailyStayTimeSpan.TotalHours), (int)Math.Ceiling(nightStayTimeSpan.TotalHours));
        }

        public static TimeSpan GetDailyStay(DateTime parkTime, DateTime leaveTime, TimeSpan dailyHourStart, TimeSpan overnightHourStart)
        {
            if (parkTime == leaveTime)
            {
                return TimeSpan.Zero;
            }

            if (parkTime.Date == leaveTime.Date)
            {
                if (leaveTime.TimeOfDay.Ticks <= dailyHourStart.Ticks || parkTime.TimeOfDay.Ticks >= overnightHourStart.Ticks)
                {
                    return TimeSpan.Zero;
                }

                long totalWorkTimeTicks = Math.Min(overnightHourStart.Ticks, leaveTime.TimeOfDay.Ticks) - Math.Max(dailyHourStart.Ticks, parkTime.TimeOfDay.Ticks);
                return TimeSpan.FromTicks(totalWorkTimeTicks);
            }

            int totalFullDaysParked = (int)(leaveTime.Date - parkTime.Date).TotalDays - 1;
            TimeSpan dailyWorkTime = TimeSpan.FromDays(1)
                - dailyHourStart
                - (TimeSpan.FromDays(1) - overnightHourStart);

            long fullDaysDailyTicks = totalFullDaysParked * dailyWorkTime.Ticks;
            long firstDayDailyTimeTicks = Math.Min(dailyWorkTime.Ticks, Math.Max(0, overnightHourStart.Ticks - parkTime.TimeOfDay.Ticks));
            long lastDayDailyTimeTicks = Math.Min(dailyWorkTime.Ticks, Math.Max(0, leaveTime.TimeOfDay.Ticks - dailyHourStart.Ticks));

            return TimeSpan.FromTicks(firstDayDailyTimeTicks + fullDaysDailyTicks + lastDayDailyTimeTicks);
        }
    }
}
