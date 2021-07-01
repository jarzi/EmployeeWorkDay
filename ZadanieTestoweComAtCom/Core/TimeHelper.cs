using System;

namespace ZadanieTestoweComAtCom.Core
{
    public static class TimeHelper
    {
        private const string DateFormat = "yyyy-MM-dd";
        private const string TimeFormat = "HH:mm:ss";
        private const string ShortTimeFormat = "HH:mm";

        public static DateTime GetDateTimeFromCsv(string csv, ushort index)
        {
            return DateTime.ParseExact(csv.Split(FileHelper.Separator)[index], DateFormat, System.Globalization.CultureInfo.InvariantCulture);
        }
        
        public static DateTime GetTimeFromCsv(string csv, ushort index)
        {
            return DateTime.ParseExact(csv.Split(FileHelper.Separator)[index], TimeFormat, System.Globalization.CultureInfo.InvariantCulture);
        }
        
        public static DateTime GetHourMinutesTimeFromCsv(string csv, ushort index)
        {
            return string.IsNullOrEmpty(csv.Split(FileHelper.Separator)[index]) ? DateTime.MinValue : DateTime.ParseExact(csv.Split(FileHelper.Separator)[index], ShortTimeFormat, System.Globalization.CultureInfo.InvariantCulture);
        }
        
        public static TimeSpan DateTimeToTimeSpan(DateTime? dateTime)
        {
            return !dateTime.HasValue ? TimeSpan.Zero : new TimeSpan(0, dateTime.Value.Hour, dateTime.Value.Minute, dateTime.Value.Second, dateTime.Value.Millisecond);
        }
    }
}