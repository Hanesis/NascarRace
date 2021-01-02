using System;

namespace NascarRace.Tires
{
    class SoftTires: Tires
    {
        public SoftTires()
        {
            TireWear = 100;
            UsedLaps = 0;
            SpeedModifier = 38;
            TireWearPer3km = 11;
            TireSpeedMofierPer3km = 5;
            IsPunctured = false;
        }

        public override string ToString()
        {
            return "S";
        }
    }
}
