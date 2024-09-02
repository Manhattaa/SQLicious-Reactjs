namespace SQLicious.Server.Helpers
{
    public class TimeHelper
    {
        //Handles and resets time so we wont have to worry about the clutter
        public static DateTime DateTimeHelper(DateTime dateTime)
        {
            return dateTime.Date.AddHours(dateTime.Hour).AddMinutes(dateTime.Minute);
        }
    }
}
