﻿using System;

namespace NascarRace.Tires
{
    class SoftTires: Tires
    {
        public SoftTires()
        {
            TireWear = 100;
            UsedLaps = 0;
            SpeedModifier = 36;
        }

        public override string ToString()
        {
            return "S";
        }
    }
}
