using System;
using NascarRace.Tires;

namespace NascarRace
{
    class PitLane
    {
        public TimeSpan PitLaneEnterTime { get; set; }
        public TimeSpan PitLaneCrewTime { get; set; }
        public TimeSpan MaintainTime { get; set; }
        public Tires.Tires NewTires { get; set; }

        public PitLane(int pitLaneTime)
        {
            PitLaneEnterTime = TimeSpan.FromSeconds(pitLaneTime);
        }

        public void ChangeTires(Racer racer, string newTiresType)
        {
            NewTires = null;

            switch (newTiresType.ToUpper())
            {
                case "H":
                    NewTires = new HardTires();
                    break;
                case "M":
                    NewTires = new MediumTires();
                    break;
                case "S":
                    NewTires = new SoftTires();
                    break;
                case "N":
                    NewTires = racer.Car.Tires;
                    break;
                default:
                    Console.Write("Invalid tire type");
                    break;
            }
            racer.Car.Tires = NewTires;
        }

        public void LoadFuel(Racer racer, double fuelLoad)
        {
            if (racer.Car.ActualFuel + fuelLoad >= racer.Car.MaxFuel)
            {
                racer.Car.ActualFuel = racer.Car.MaxFuel;
            }
            
            racer.Car.ActualFuel += fuelLoad;
            racer.Car.IsOutOfFuel = false;


        }
        public void GetPitLaneTime(Racer racer, double fuelLoad)
        {
            var cube = new Cube();
            
            PitLaneCrewTime = TimeSpan.FromSeconds(cube.Roll(5, 9));
            MaintainTime = TimeSpan.FromSeconds(fuelLoad / 1.5);

            if (MaintainTime <= TimeSpan.FromSeconds(8))
            {
                racer.LapTime += TimeSpan.FromSeconds(8) + PitLaneCrewTime + PitLaneEnterTime;
                racer.TotalTime += TimeSpan.FromSeconds(8) + PitLaneCrewTime + PitLaneEnterTime;
            }
            else
            {
                racer.LapTime += MaintainTime + PitLaneCrewTime + PitLaneEnterTime;
                racer.TotalTime += MaintainTime + PitLaneCrewTime + PitLaneEnterTime;
            }
        }
    }
}
