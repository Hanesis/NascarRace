using System;
using System.Collections.Generic;
using System.Text;

namespace NascarRace
{
    class Tires
    {
        public TireTypeEnum TireType { get; set; }
        public double TireWear { get; set; }
        public int TireWearIndex { get; set; }

        public enum TireTypeEnum
        {
            Soft = 0,
            Medium = 1,
            Hard = 2,
        }
    }
}
