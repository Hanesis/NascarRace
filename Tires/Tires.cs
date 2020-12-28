using System;

namespace NascarRace.Tires
{
    class Tires
    {
        public double TireWear { get; set; }
        public int UsedLaps { get; set; }
        public int SpeedModifier { get; set; }
        public bool IsPunctured { get; set; }

        public override string ToString()
        {
            throw new NotImplementedException();
        }

        public void CheckForPuncture()
        {
            if (TireWear >= 50) return;
            if (IsPunctured) return;

            var random = new Random();
            
            if (!(random.Next(100) > TireWear * 2.5)) return;
            
            IsPunctured = true;
            TireWear = 1;
        }
    }
}
