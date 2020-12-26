namespace NascarRace.Tires
{
    class HardTires : ITires
    {
        public double TireWear { get; set; }
        public int UsedLaps { get; set; }
        public int SpeedModifier { get; set; }

        public HardTires()
        {
            TireWear = 100;
            UsedLaps = 0;
            SpeedModifier = 0;
        }
        string ITires.ToString()
        {
            return "H";
        }
    }

}
