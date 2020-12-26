using System;
using NascarRace.Tires;

namespace NascarRace
{
    class Car
    {
        public int MaxFuel { get; set; }
        public int ActualFuel { get; set; }
        public Tires.Tires Tires { get; set; }
        public double MaxSpeed { get; set; }
        public double PerformanceReduction { get; set; }

        public Car(int maxFuel, int actualFuel, Tires.Tires tires, int maxSpeed, double performanceReduction)
        {
            MaxFuel = maxFuel;
            ActualFuel = actualFuel;
            Tires = tires;
            MaxSpeed = maxSpeed + tires.SpeedModifier;
            PerformanceReduction = performanceReduction;
        }

        public void UseTire()
        {
            switch (Tires)
            {
                case HardTires _:
                    Tires.TireWear -= 3;
                    break;
                case MediumTires _:
                    Tires.TireWear -= 7;
                    break;
                case SoftTires _:
                    Tires.TireWear -= 12;
                    break;
            }

            var s = Tires.SpeedModifier * (Tires.TireWear / 100)/3;
            MaxSpeed -= s;
        }
    }
}
