using System;


namespace ProductAvailability.Core
{
    public class DateService : IDateService
    {
        public DateTime ParseLongDateFormat(string date)
        {
            var newDateString = date.Substring(0, 4)
                         .Replace("nd", "")
                         .Replace("th", "")
                         .Replace("rd", "")
                         .Replace("st", "")
                         + date.Substring(4);
            return Convert.ToDateTime(newDateString);
        }
    }
}
