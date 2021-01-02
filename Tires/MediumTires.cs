namespace NascarRace.Tires
{
    class MediumTires : Tires
    {
        public MediumTires()
        {
            TireWear = 100;
            UsedLaps = 0;
            SpeedModifier = 28;
            TireWearPer3km = 7;
            TireSpeedMofierPer3km = 3;
            IsPunctured = false;
        }

        public override string ToString()
        {
            return "M";
        }
    }
}
