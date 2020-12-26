using System;
using System.Collections.Generic;
using System.Text;

namespace NascarRace.Tires
{
    interface ITires
    {
        double TireWear { get; set; }
        int UsedLaps { get; set; }
        int SpeedModifier { get; set; }

        
    }
}
