using System;
using System.Collections.Generic;
using System.Text;

namespace NascarRace
{
    class Cube
    {
        private Random Random;
        private int CubeSites;

        public Cube()
        {
            Random = new Random();
            CubeSites = 6;
        }
        public Cube(int cubeSites)
        {
            Random = new Random();
            CubeSites = cubeSites;
        }

        public int Roll()
        {
            return Random.Next(1, CubeSites + 1);
        }
    }
}
