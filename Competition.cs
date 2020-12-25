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

        public Dictionary<Racer, TimeSpan> ActualLapTimes { get; set; }

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


            ActualLapTimes = new Dictionary<Racer, TimeSpan>();

            foreach (var racer in Grid)
            {
                var lapTime = racer.Drive(Circuit);

                ActualLapTimes.Add(racer, lapTime);
            }

            Console.WriteLine("Last lap times are:");

            foreach (var racersLap in ActualLapTimes)
            {
                Console.WriteLine($"Racer: {racersLap.Key.Name}, LapTime: {racersLap.Value}");
            }

        }
    }
}
