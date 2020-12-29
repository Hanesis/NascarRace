namespace NascarRace.Tires
{
    class MediumTires : Tires
    {
        public MediumTires()
        {
            TireWear = 100;
            UsedLaps = 0;
            SpeedModifier = 33;
            IsPunctured = false;
        }

        public override string ToString()
        {
            return "M";
        }
    }
}
