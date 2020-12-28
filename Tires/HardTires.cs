namespace NascarRace.Tires
{
    class HardTires : Tires
    {
        public HardTires()
        {
            TireWear = 100;
            UsedLaps = 0;
            SpeedModifier = 29;
            IsPunctured = false;
        }

        public override string ToString()
        {
            return "H";
        }
    }

}
