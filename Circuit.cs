using System;
using System.Collections.Generic;
using System.Text;

namespace NascarRace
{
    class Circuit
    {
        public int Length { get; set; }
        public int TotalRounds { get; set; }

        public Circuit(int length, int totalRounds)
        {
            Length = length;
            TotalRounds = totalRounds;
        }
    }
}
