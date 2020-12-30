using System;
using NascarRace.Tires;

namespace NascarRace
{
    class Car
    {
        public int MaxFuel { get; set; }
        public double ActualFuel { get; set; }
        public Tires.Tires Tires { get; set; }
        public double BasicSpeed { get; set; }
        public double ActualMaxSpeed { get; set; }
        public double FuelUsagePer1Km { get; set; }
        public double FuelPerformanceReduction { get; set; }
        public double TiresPerformanceReduction { get; set; }
        public bool IsOutOfFuel { get; set; }

        public Car(double actualFuel, Tires.Tires tires, int basicSpeed)
        {
            MaxFuel = 50;
            ActualFuel = actualFuel;
            Tires = tires;
            BasicSpeed = basicSpeed;
            ActualMaxSpeed = basicSpeed + tires.SpeedModifier;
            FuelUsagePer1Km = 0.89;
            IsOutOfFuel = false;
        }

        public void UseFuel(int circuitLength)
        {
            CheckFuelLvl(circuitLength);
            if (IsOutOfFuel) return;
            
            ActualFuel -= circuitLength * FuelUsagePer1Km / 1000;
        }

        public void CheckFuelLvl(int circuitLength)
        {
            var minimumFuel = circuitLength * FuelUsagePer1Km / 1000;
            if (ActualFuel >= minimumFuel) return;

            IsOutOfFuel = true;
        }

        public void UseTire(int circuitLength)
        {
            Tires.CheckForPuncture();

            if (Tires.IsPunctured) return;
            switch (Tires)
            {
                case HardTires _:
                    Tires.TireWear -= circuitLength / 1000.0;
                    break;
                case MediumTires _:
                    Tires.TireWear -= circuitLength / 1000.0 * 1.8;
                    break;
                case SoftTires _:
                    Tires.TireWear -= circuitLength / 1000 * 3;
                    break;
            }
            Tires.TireWear = Math.Round(Tires.TireWear);
        }
    }
}
