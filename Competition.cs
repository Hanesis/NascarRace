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

            PrintFinalStandings();
        }

        private void UsePitLane(string command)
        {
            if (command == "") return;

            var pitLane = new PitLane();
            //91 H 35 - number 91 will use Hard tires and tank 35l of fuel
            var commandList = command.Split();

            var racerInPitLane = Grid.Find(racer => racer.ID.ToString() == commandList[0]);
            Tires.Tires newTires = null;

            switch (commandList[1].ToUpper())
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

            racerInPitLane.LapTime += TimeSpan.FromSeconds(Circuit.PitLaneTime);
            racerInPitLane.TotalTime += TimeSpan.FromSeconds(Circuit.PitLaneTime);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Racer {0} was in PitLane and has new Tires: {1}", racerInPitLane.Name, newTires);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        private void PrintStartingIntro()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Competition intro:");
            Console.WriteLine("Circuit name: {0}", Name);
            Console.WriteLine("Circuit length: {0}", Circuit.Length);
            Console.WriteLine("Total round: {0}", Circuit.TotalRounds);
            Console.ForegroundColor = ConsoleColor.Gray;

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

        private void PrintFinalStandings()
        {
            Console.WriteLine($"Final standings are:");

            Grid.Sort((x, y) => x.TotalTime.CompareTo(y.TotalTime));

            Console.ForegroundColor = ConsoleColor.Yellow;

            foreach (var racer in Grid)
            {
                var position = Grid.FindIndex(a => a.Name == racer.Name);
                Console.WriteLine($"{position + 1}. {racer.ID} - {racer.Name}, TotalTime: {TimeSpanToString(racer.TotalTime)} ");
            }
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        private void PrintActualStandings(int lap)
        {
            Console.WriteLine($"Standings after {lap} laps are:");

            Grid.Sort((x, y) => x.TotalTime.CompareTo(y.TotalTime));

            Console.ForegroundColor = ConsoleColor.Blue;

            foreach (var racer in Grid)
            {
                var position = Grid.FindIndex(a => a.Name == racer.Name);
                Console.WriteLine($"{position + 1}. {racer.ID} - {racer.Name}, TotalTime: {TimeSpanToString(racer.TotalTime)} {racer.Car.Tires} - {racer.Car.Tires.TireWear}% - maxSpeed: {racer.Car.ActualMaxSpeed} - PR: {racer.Car.PerformanceReduction}");
            }
            Console.ForegroundColor = ConsoleColor.Gray;
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
