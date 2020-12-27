using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;
using NascarRace.Tires;

namespace NascarRace
{
    class Competition
    {
        public string Name { get; set; }
        public Circuit Circuit { get; set; }
        public List<Racer> Grid{ get; set; }
        public Competition(string name, Circuit circuit, List<Racer> grid)
        {
            Name = name;
            Circuit = circuit;
            Grid = grid;
        }

        public void StartCompetition()
        {
            PrintStartingIntro();

            Console.WriteLine("Starting The Race!");
            
            var laps = 1;
            do
            {
                Console.Write("PitLaneCommand:");
                var command = Console.ReadLine();
                DriveGrid();
                UsePitLane(command);
                PrintActualLapsTimes(laps);
                PrintActualStandings(laps);

                laps++;

            } while (laps != Circuit.TotalRounds);
        }

        private void UsePitLane(string command)
        {
            if (command == "") return;

            var pitLane = new PitLane();
            //91 H 35 - number 91 will use Hard tires and tank 35l of fuel
            var commandList = command.Split();

            var racerInPitLane = Grid.Find(racer => racer.ID.ToString() == commandList[0]);
            Tires.Tires newTires = null;

            switch (commandList[1])
            {
                case "H":
                    newTires = new HardTires();
                    break;
                case "M":
                    newTires = new MediumTires();
                    break;
                case "S":
                    newTires = new SoftTires();
                    break;
                default: 
                    Console.Write("Invalid tire type");
                    break;
            }

            pitLane.ChangeTires(racerInPitLane,newTires);

            racerInPitLane.LapTime += TimeSpan.FromSeconds(20);
            racerInPitLane.TotalTime += TimeSpan.FromSeconds(20);

            Console.Write("Racer {0} was in PitLane and has new Tires: {1}", racerInPitLane.Name, newTires);
        }

        private void PrintStartingIntro()
        {
            Console.WriteLine("Competition {0} intro", Name);

            Console.WriteLine("Racers on the grid are:");

            foreach (var racer in Grid)
            {
                Console.WriteLine($"{racer.ID} - {racer.Name} ({racer.Car.Tires})");
            }
        }

        private void DriveGrid()
        {
            foreach (var racer in Grid)
            {
                racer.Drive(Circuit);
            }
        }

        private void PrintActualStandings(int lap)
        {
            Console.WriteLine($"Standings after {lap} laps are:");

            Grid.Sort((x, y) => x.TotalTime.CompareTo(y.TotalTime));

            foreach (var racer in Grid)
            {
                var position = Grid.FindIndex(a => a.Name == racer.Name);

                Console.WriteLine($"{position + 1}. {racer.ID} - {racer.Name}, TotalTime: {TimeSpanToString(racer.TotalTime)} {racer.Car.Tires} - {racer.Car.Tires.TireWear}% - maxSpeed: {racer.Car.MaxSpeed} - PR: {racer.Car.PerformanceReduction}");
            }
        }

        private void PrintActualLapsTimes(int lap)
        {
            Console.WriteLine();
            Console.WriteLine($"Lap {lap} times are:");

            foreach (var racer in Grid)
            {
                Console.WriteLine($"Racer: {racer.Name}, LapTime: {TimeSpanToString(racer.LapTime)}");
            }
        }

        private static string TimeSpanToString(TimeSpan lapTime)
        {
            var t = $@"{lapTime:mm\:ss\.fff}";

            return t;
        }
    }
}
