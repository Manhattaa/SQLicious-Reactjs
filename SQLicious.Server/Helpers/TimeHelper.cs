namespace SQLicious.Server.Helpers
{
    public class TimeHelper
    {
        public static DateTime DateTimeHelper(DateTime dateTime)
        {
            return dateTime.Date.AddHours(dateTime.Hour).AddMinutes(dateTime.Minute);
        }
    }
}
