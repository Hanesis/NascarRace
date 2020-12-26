using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace NascarRace
{
    class Racer
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Car Car{ get; set; }
        public int ActualForm { get; set; }
        public TimeSpan LapTime { get; set; }
        public TimeSpan TotalTime { get; set; }
        private Cube Cube;

    public Racer(int id, string name, Cube cube)
        {
            ID = id;
            Name = name;
            Cube = cube;
            Car = CreateDefaultCar();
        }

        private Car CreateDefaultCar()
        {
            return new Car(300, 300, new Tires(), 150, 0);
        }


        public TimeSpan Drive(Circuit circuit)
        {
            var lap = GetBaseRawLapTime(circuit.Length);
            
            lap = ApplyActualFormIndex(lap);
            
            var lapTime = RawToTimeSpan(lap);

            LapTime = lapTime;
            TotalTime += lapTime;

            return lapTime;
        }

        private double ApplyActualFormIndex(double rawLapTime)
        {
            var formIndex = Cube.Roll10To16();//lower is better
            return rawLapTime + formIndex / 10000.0;
        }

        private double GetBaseRawLapTime(int lapLength)
        {
            return lapLength / 1000.0 / Car.MaxSpeed;
        }
        
        private static TimeSpan RawToTimeSpan(double rawLapTime)
        {
            return TimeSpan.FromHours(rawLapTime);
        }
    }
}
