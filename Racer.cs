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
        public int ActualPosition { get; set; }
        private Cube Cube;

    public Racer(int id, string name)
        {
            ID = id;
            Name = name;
            Cube = new Cube();
            Car = CreateDefaultCar();
        }

        private Cube CreateNewCube()
        {
            return new Cube();
        }
        private Car CreateDefaultCar()
        {
            return new Car(300, 300, new Tires(), 150, 0);
        }


        public TimeSpan Drive(Circuit circuit)
        {
            var lap = GetBaseRawLapTime(circuit.Length);
            
            lap = ApplyActualFormIndex(lap);
            
            return RawToTimeSpan(lap);
        }

        private double ApplyActualFormIndex(double rawLapTime)
        {
            var formIndex = Cube.Roll();//lower is better
            var newLapTime = rawLapTime + (formIndex / 1000.0);

            return Math.Round(newLapTime, 3);
        }

        private double GetBaseRawLapTime(int lapLength)
        {
            return lapLength / 1000.0 / Car.MaxSpeed;
        }
        
        private TimeSpan RawToTimeSpan(double rawLapTime)
        {
            return TimeSpan.FromHours(rawLapTime);
        }
    }
}
