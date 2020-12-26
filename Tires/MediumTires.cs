namespace NascarRace.Tires
{
    class MediumTires : ITires
    {
        public double TireWear { get; set; }
        public int UsedLaps { get; set; }
        public int SpeedModifier { get; set; }

        public MediumTires()
        {
            TireWear = 100;
            UsedLaps = 0;
            SpeedModifier = 10;
        }
    }
}
