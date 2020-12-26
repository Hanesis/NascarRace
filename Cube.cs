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
       
        public int Roll1To6()
        {
            return Random.Next(1, CubeSites + 1);
        }
        public int Roll10To16()
        {
            return Random.Next(10, 16);
        }
    }
}
