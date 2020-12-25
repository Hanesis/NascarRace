using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace NascarRace
{
    class Car
    {
        public int MaxFuel { get; set; }
        public int ActualFuel { get; set; }
        public Tires Tires { get; set; }
        public int MaxSpeed { get; set; }
        public double PerformanceReduction { get; set; }

        public Car(int maxFuel, int actualFuel, Tires tires, int maxSpeed, double performanceReduction)
        {
            MaxFuel = maxFuel;
            ActualFuel = actualFuel;
            Tires = tires;
            MaxSpeed = maxSpeed;
            PerformanceReduction = performanceReduction;
        }
        

    }
}
