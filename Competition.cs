using System;
using System.Collections.Generic;
using System.Linq;
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
                PrintDamageInfo();
                UsePitLane(command);
                PrintActualLapsTimes(laps);
                PrintActualStandings(laps);
                laps++;
            } while (laps != Circuit.TotalRounds + 1);

            PrintFinalStandings();
        }

        private void UsePitLane(string command)
        {
            if (command == "") return;

            //91 H 35 - number 91 will use Hard tires and tank 35l of fuel
            //91 H 0 - number 91 will use Hard tires
            //91 N 35 - number 91 will tank 35l of fuel
            var commandList = command.Split();

            var racerInPitLane = Grid.Find(racer => racer.ID.ToString() == commandList[0]);

            Circuit.PitLane.ChangeTires(racerInPitLane, commandList[1]);
            Circuit.PitLane.LoadFuel(racerInPitLane, Convert.ToDouble(commandList[2]));
            Circuit.PitLane.GetPitLaneTime(racerInPitLane, Convert.ToDouble(commandList[2]));

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Racer {0} was in pitLane - New fuel load: {1}l Tires: {2} (Crew time: {3}s, Maintain time {4}s)", racerInPitLane.Name, Math.Round(racerInPitLane.Car.ActualFuel), Circuit.PitLane.NewTires, Helper.TimeSpanToStringSec(Circuit.PitLane.PitLaneCrewTime), Helper.TimeSpanToStringSec(Circuit.PitLane.MaintainTime));
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        private void PrintStartingIntro()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
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
                Console.WriteLine($"{position + 1}. {racer.ID} - {racer.Name}, TotalTime: {Helper.TimeSpanToStringMinutes(racer.TotalTime)}, Average Form: {Math.Round(racer.CubeThrows.Average(),2)}, BonusTimeIndex: {Helper.TimeInDoubleToString(racer.PenaltyTimeStack)}");
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
                Console.WriteLine($"{position + 1}. {racer.ID} - {racer.Name}, TotalTime: {Helper.TimeSpanToStringMinutes(racer.TotalTime)} F:{Math.Round(racer.Car.ActualFuel,1)}l - {racer.Car.Tires}:{racer.Car.Tires.TireWear}% = maxSpeed: {racer.Car.ActualMaxSpeed}");
            }
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        private void PrintActualLapsTimes(int lap)
        {
            Console.WriteLine();
            Console.WriteLine($"Lap {lap} times are:");

            Grid.Sort((x, y) => x.TotalTime.CompareTo(y.TotalTime));

            foreach (var racer in Grid)
            {
                Console.WriteLine($"{racer.ID} - {racer.Name}, LapTime: {Helper.TimeSpanToStringMinutes(racer.LapTime)} ({racer.ActualForm})");
            }
        }

        private void PrintDamageInfo()
        {
            if (Grid.Any(r => r.Car.Tires.IsPunctured) || Grid.Any(r => r.Car.IsOutOfFuel))
            {
                foreach (var racer in Grid)
                {
                    if (racer.Car.Tires.IsPunctured)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine($"Racer: {racer.ID} - {racer.Name} has damaged tire!");
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    if (racer.Car.IsOutOfFuel)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine($"Racer: {racer.ID} - {racer.Name} is out of fuel!");
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                }
            }
            Console.WriteLine();
        }
    }
}
