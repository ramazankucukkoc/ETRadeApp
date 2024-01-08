namespace ETRadeApp.Core.Extensions
{
    public static class DateTimeExtensions
    {
        public static DateTime ConvertToTimeZoneTurkey(this DateTime dateTime)
        {
                TimeZoneInfo targetTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Turkey Standard Time");
                return TimeZoneInfo.ConvertTimeFromUtc(dateTime, targetTimeZone);
        }
    }
}
