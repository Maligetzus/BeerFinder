using System;

namespace BeerDB
{
    public struct HourMinute
    {
        public int Hour { get; set; }
        public int Minute { get; set; }

        public HourMinute(int hour, int minute)
        {
            if (hour > 23 || hour < 0 || minute > 60 || minute < 0)
            {
                throw new ArgumentOutOfRangeException("Have a look at your watch. Does it tell you something?");
            }
            Hour = hour;
            Minute = minute;
        }

        public override bool Equals(Object item)
        {
            if (item == null)
            {
                return false;
            }
            if (!(item is HourMinute))
            {
                return false;
            }
            return Hour==((HourMinute)item).Hour;
        }

        public override int GetHashCode()
        {
            return Hour.GetHashCode()+Minute.GetHashCode();
        }
    }
}
