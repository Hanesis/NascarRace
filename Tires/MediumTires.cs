namespace NascarRace.Tires
{
    class MediumTires : Tires
    {
        public MediumTires()
        {
            TireWear = 100;
            UsedLaps = 0;
            SpeedModifier = 32;
            IsPunctured = false;
        }

        public override string ToString()
        {
            return "M";
        }
    }
}
