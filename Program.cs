using System;
using System.Collections.Generic;
using NascarRace.Tires;

namespace NascarRace
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Preparing Race!");

            var circuit = new Circuit(3000, 25);
            var grid = new List<Racer>();

            var cube1 = new Cube();

            var racer1 = new Racer(1,"Hanes", new HardTires());
            var racer2 = new Racer(2, "Lucie", new MediumTires());
            var racer3 = new Racer(2, "Tomáš", new SoftTires());

            grid.Add(racer1);
            grid.Add(racer2);
            grid.Add(racer3);

            var competition = new Competition("Indiana Championship", circuit, grid);

            competition.StartCompetition();

            Console.ReadKey();
        }
    }
}
