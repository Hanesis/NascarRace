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
                    newTire =new MediumTires();
                    break;
                case SoftTires _:
                    newTire = new SoftTires();
                    break;
            }

            racer.Car.Tires = newTire;
            racer.Car.ActualMaxSpeed = racer.Car.MaxSpeed + newTire.SpeedModifier;
            racer.LapTime += TimeSpan.FromSeconds(8);
            racer.TotalTime += TimeSpan.FromSeconds(8);
        }
    }
}
