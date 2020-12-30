namespace NascarRace.Tires
{
    class HardTires : Tires
    {
        public HardTires()
        {
            TireWear = 100;
            UsedLaps = 0;
            SpeedModifier = 27;
            IsPunctured = false;
        }

        public override string ToString()
        {
            return "H";
        }
    }

}
