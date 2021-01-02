namespace NascarRace.Tires
{
    class HardTires : Tires
    {
        public HardTires()
        {
            TireWear = 100;
            UsedLaps = 0;
            SpeedModifier = 24;
            TireWearPer3km = 3;
            TireSpeedMofierPer3km = 2;
            IsPunctured = false;
        }

        public override string ToString()
        {
            return "H";
        }
    }

}
