using System;
using System.Collections.Generic;
using System.Text;

namespace NascarRace
{
    class Circuit
    {
        public int Length { get; set; }
        public int TotalRounds { get; set; }
        public int PitLaneEnterTime { get; set; }
        public PitLane PitLane { get; set; }

        public Circuit(int length, int totalRounds, int pitLaneTime)
        {
            Length = length;
            TotalRounds = totalRounds;
            PitLaneEnterTime = pitLaneTime;
            PitLane = new PitLane(PitLaneEnterTime);
        }
    }
}
