using System;
using System.Collections.Generic;
using System.Text;

namespace NascarRace
{
    public static class Helper
    {
        public static string TimeSpanToStringMinutes(TimeSpan time)
        {
            return $@"{time:mm\:ss\.ff}";
        }
        public static string TimeSpanToStringSec(TimeSpan time)
        {
            return $@"{time:ss\.ff}";
        }

        public static string TimeInDoubleToString(double time)
        {
            return $@"{RawToTimeSpan(time):mm\:ss\.ff}";
        }

        public static TimeSpan RawToTimeSpan(double rawTime)
        {
            return TimeSpan.FromHours(rawTime);
        }
    }
}
