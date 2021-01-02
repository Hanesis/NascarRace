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
            var lapTimeRaw = GetBaseRawLapTime(circuit.Length);
            //lapTimeRaw = ApplyActualFormIndex(lapTimeRaw);
            ApplyTireWearSpeedPenalty();
            CalculateActualMaxSpeed(circuit.Length);

            var lapTime = Helper.RawToTimeSpan(lapTimeRaw);
            LapTime = lapTime;
            TotalTime += lapTime;

            Car.UseTire(circuit.Length);
            Car.UseFuel(circuit.Length);

            return lapTime;
        }

        private double ApplyActualFormIndex(double rawLapTime)
        {
            ActualForm = Cube.Roll(3,8) * 1.5;//lower is better
            CubeThrows.Add(ActualForm);
            var penaltyTime = ActualForm / 6000.0;
            PenaltyTimeStack += penaltyTime;
            return rawLapTime + penaltyTime;
        }
        private void CalculateActualMaxSpeed(int lapLength)
        {
            Car.ActualMaxSpeed = Car.BasicSpeed + Car.Tires.SpeedModifier - Car.TiresPerformanceReduction;
            Car.ActualMaxSpeed = Math.Round(Car.ActualMaxSpeed, 1);

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
                var minimumFuel = lapLength * Car.FuelUsagePer1Km / 1000;
                
                Car.ActualMaxSpeed = Math.Round(Car.ActualFuel / minimumFuel * Car.ActualMaxSpeed,1);
                Car.ActualFuel = 0.1;
            }
        }

        private double ApplyFuelWeightSpeedPenalty()
        {
            return Math.Round(Car.ActualFuel * Car.FuelWeightSpeedPenaltyOn1L/3600, 5);
        }

        private void ApplyTireWearSpeedPenalty()
        {
            Car.TiresPerformanceReduction += Car.Tires.TireSpeedMofierPer3km;
        }

        private double GetBaseRawLapTime(int lapLength)
        {
            var fuelWeightSpeedPenalty = ApplyFuelWeightSpeedPenalty();
            var baseLapTime = lapLength / 1000.0 / Car.ActualMaxSpeed;

            return baseLapTime + fuelWeightSpeedPenalty;
        }
    }
}
