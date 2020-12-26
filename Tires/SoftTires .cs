using System;

namespace NascarRace.Tires
{
    class SoftTires: ITires
    {
        public double TireWear { get; set; }
        public int UsedLaps { get; set; }
        public int SpeedModifier { get; set; }

        public SoftTires()
        {
            TireWear = 100;
            UsedLaps = 0;
            SpeedModifier = 20;
        }

        string ITires.ToString()
        {
            return "S";
        }
    }
}
