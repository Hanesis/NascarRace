using System;
using NascarRace.Tires;

namespace NascarRace
{
    class PitLane
    {
        public void ChangeTires(Racer racer, Tires.Tires newTiresType)
        {
            Tires.Tires newTire = null;

            switch (newTiresType)
            {
                case HardTires _:
                    newTire = new HardTires();
                    break;
                case MediumTires _:
                    newTire = new MediumTires();
                    break;
                case SoftTires _:
                    newTire = new SoftTires();
                    break;
            }

            racer.Car.Tires = newTire;
            racer.LapTime += TimeSpan.FromSeconds(8);
            racer.TotalTime += TimeSpan.FromSeconds(8);
        }

        public void LoadFuel(Racer racer, double fuelLoad)
        {
            if (racer.Car.ActualFuel + fuelLoad >= racer.Car.MaxFuel)
            {
                racer.Car.ActualFuel = racer.Car.MaxFuel;
            }
            
            racer.Car.ActualFuel += fuelLoad;

            var fuelTime = fuelLoad / 4;
            racer.LapTime += TimeSpan.FromSeconds(fuelTime);
            racer.TotalTime += TimeSpan.FromSeconds(fuelTime);
            racer.Car.IsOutOfFuel = false;
        }
    }
}
