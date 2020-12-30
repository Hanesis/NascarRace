using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using NascarRace.Tires;

namespace NascarRace
{
    class Racer
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Car Car{ get; set; }
        public double ActualForm { get; set; }
        public TimeSpan LapTime { get; set; }
        public TimeSpan TotalTime { get; set; }
        public List<double> CubeThrows { get; set; }
        public double PenaltyTimeStack{ get; set; }
        private Cube Cube;

        public Racer(int id, string name, double fuelLoad, Tires.Tires tires)
        {
            ID = id;
            Name = name;
            Cube = new Cube();
            Car = CreateDefaultCarWithTires(fuelLoad, tires);
            CubeThrows = new List<double>();
        }

        private Car CreateDefaultCarWithTires(double fuel, Tires.Tires tires)
        {
            return new Car(fuel, tires, 150);
        }


        public TimeSpan Drive(Circuit circuit)
        {
            Car.UseTire(circuit.Length);
            Car.UseFuel(circuit.Length);

            ApplyFuelWightSpeedPenalty();
            ApplyTireWearSpeedPenalty();
            CalculateActualMaxSpeed();

            var lapTimeRaw = GetBaseRawLapTime(circuit.Length);
            lapTimeRaw = ApplyActualFormIndex(lapTimeRaw);
            var lapTime = Helper.RawToTimeSpan(lapTimeRaw);

            LapTime = lapTime;
            TotalTime += lapTime;

            return lapTime;
        }

        private double ApplyActualFormIndex(double rawLapTime)
        {
            ActualForm = Cube.Roll(3,8) * 2.5;//lower is better
            CubeThrows.Add(ActualForm);
            var penaltyTime = ActualForm / 6000.0;
            PenaltyTimeStack += penaltyTime;
            return rawLapTime + penaltyTime;
        }
        private void CalculateActualMaxSpeed()
        {
            Car.ActualMaxSpeed = Car.BasicSpeed + Car.Tires.SpeedModifier - Car.TiresPerformanceReduction - Car.FuelPerformanceReduction;
            Car.ActualMaxSpeed = Math.Round(Car.ActualMaxSpeed, 2);

            if (Car.ActualMaxSpeed < Car.BasicSpeed)
            {
                Car.ActualMaxSpeed = Car.BasicSpeed;
            }

            if (Car.Tires.IsPunctured)
            {
                Car.ActualMaxSpeed = 100;
            }

            if (Car.IsOutOfFuel)
            {
                Car.ActualMaxSpeed = 50;
            }
        }

        private void ApplyFuelWightSpeedPenalty()
        {
            Car.FuelPerformanceReduction = Math.Round(Car.ActualFuel / 5, 2);
        }

        private void ApplyTireWearSpeedPenalty()
        {
            Car.TiresPerformanceReduction = Math.Round(Car.Tires.SpeedModifier / Car.Tires.TireWear * 6.5, 3);
            
        }

        private double GetBaseRawLapTime(int lapLength)
        {
            return lapLength / 1000.0 / Car.ActualMaxSpeed;
        }
    }
}
