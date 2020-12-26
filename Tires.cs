using System;
using System.Collections.Generic;
using System.Text;

namespace NascarRace
{
    class Tires
    {
        public TireTypeEnum TireType { get; set; }
        private double TireWear { get; set; }
        private int TireWearIndex { get; set; }

        public Tires(TireTypeEnum tireType)
        {
            TireType = tireType;
        }

        public Tires()
        {
            
        }

        public enum TireTypeEnum
        {
            Soft = 0,
            Medium = 1,
            Hard = 2,
        }
    }
}
