using System;

namespace NascarRace.Tires
{
    class SoftTires: Tires
    {
        public SoftTires()
        {
            TireWear = 100;
            UsedLaps = 0;
            SpeedModifier = 45;
        }

        public void UseTire(Tires tire)
        {
            tire.TireWear -= 15;


        }
        public override string ToString()
        {
            return "S";
        }
    }
}
