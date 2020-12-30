﻿using System;

namespace NascarRace.Tires
{
    class SoftTires: Tires
    {
        public SoftTires()
        {
            TireWear = 100;
            UsedLaps = 0;
            SpeedModifier = 39;
            IsPunctured = false;
        }

        public override string ToString()
        {
            return "S";
        }
    }
}
