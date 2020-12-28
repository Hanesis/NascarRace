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
        public double ActualMaxSpeed { get; set; }
        public double PerformanceReduction { get; set; }
        public bool IsDnf { get; set; }

        public Car(int maxFuel, int actualFuel, Tires.Tires tires, int maxSpeed)
        {
            MaxFuel = maxFuel;
            ActualFuel = actualFuel;
            Tires = tires;
            MaxSpeed = maxSpeed;
            ActualMaxSpeed = maxSpeed + tires.SpeedModifier;
            IsDnf = false;
        }

        public void UseTire()
        {
            Tires.CheckForPuncture();

            if (!Tires.IsPunctured)
            {

                switch (Tires)
                {
                    case HardTires _:
                        Tires.TireWear -= 3;
                        break;
                    case MediumTires _:
                        Tires.TireWear -= 6;
                        break;
                    case SoftTires _:
                        Tires.TireWear -= 9;
                        break;
                }

                PerformanceReduction = Math.Round(Tires.SpeedModifier / Tires.TireWear * 6.5, 3);
                ActualMaxSpeed -= Math.Round(PerformanceReduction, 3);
                ActualMaxSpeed = Math.Round(ActualMaxSpeed, 2);
            }
            else
            {
                ActualMaxSpeed = 50;
            }
        }
    }
}
