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
       
        public int Roll(int min, int max)
        {
            return Random.Next(min, max);
        }
    }
}
