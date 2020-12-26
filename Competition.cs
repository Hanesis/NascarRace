using System;
using System.Collections.Generic;
using System.Text;

namespace NascarRace
{
    class Competition
    {
        public string Name { get; set; }
        public Circuit Circuit { get; set; }
        public List<Racer> Grid{ get; set; }

        public Dictionary<Racer, TimeSpan> GridPosition { get; set; }

        public Competition(string name, Circuit circuit, List<Racer> grid)
        {
            Name = name;
            Circuit = circuit;
            Grid = grid;
        }

        public void StartCompetition()
        {
            Console.WriteLine("Competition {0} intro", Name);

            Console.WriteLine("On the grid are:");

            foreach (var racer in Grid)
            {
                Console.WriteLine(racer.Name);
            }

            Console.WriteLine("Starting Race");
            
            var laps = 1;
            do
            {
                DriveAllGrid();
                PrintActualLapsTimes(laps);
                PrintActualStandings(laps);

                laps++;

            } while (laps != Circuit.TotalRounds);
        }

        private void DriveAllGrid()
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

                Console.WriteLine($"{position + 1}. {racer.Name}, TotalTime: {TimeSpanToString(racer.TotalTime)} {racer.Car.Tires.TireType}");
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
