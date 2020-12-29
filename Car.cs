using System;
using NascarRace.Tires;

namespace NascarRace
{
    class Car
    {
        public int MaxFuel { get; set; }
        public int ActualFuel { get; set; }
        public Tires.Tires Tires { get; set; }
        public double BasicSpeed { get; set; }
        public double ActualMaxSpeed { get; set; }
        public double PerformanceReduction { get; set; }
        public bool IsDnf { get; set; }

        public Car(int actualFuel, Tires.Tires tires, int basicSpeed)
        {
            MaxFuel = 35;
            ActualFuel = actualFuel;
            Tires = tires;
            BasicSpeed = basicSpeed;
            ActualMaxSpeed = basicSpeed + tires.SpeedModifier;
            IsDnf = false;
        }
        
        public void UseTire(int circuitLength)
        {
            Tires.CheckForPuncture();

            if (!Tires.IsPunctured)
            {

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
                PerformanceReduction = Math.Round(Tires.SpeedModifier / Tires.TireWear * 6.5, 3);
                ActualMaxSpeed -= Math.Round(PerformanceReduction, 3);
                ActualMaxSpeed = Math.Round(ActualMaxSpeed, 2);
                if (ActualMaxSpeed < BasicSpeed + 10)
                {
                    ActualMaxSpeed = BasicSpeed + 10;
                }
            }
            else
            {
                ActualMaxSpeed = 50;
            }
        }}
}
