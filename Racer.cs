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

        public Racer(int id, string name, Tires.Tires tires)
        {
            ID = id;
            Name = name;
            Cube = new Cube();
            Car = CreateDefaultCarWithTires(tires);
            CubeThrows = new List<double>();
        }

        private Car CreateDefaultCarWithTires(Tires.Tires tires)
        {
            return new Car(300, 300, tires, 150);
        }


        public TimeSpan Drive(Circuit circuit)
        {
            var lap = GetBaseRawLapTime(circuit.Length);
            lap = ApplyActualFormIndex(lap);
            var lapTime = Helper.RawToTimeSpan(lap);
            
            Car.UseTire();

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

        private double GetBaseRawLapTime(int lapLength)
        {
            return lapLength / 1000.0 / Car.ActualMaxSpeed;
        }
    }
}
