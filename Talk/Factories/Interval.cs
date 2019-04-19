using System;
using System.Collections.Generic;
using System.Text;

namespace TalkProject.Factories
{
    class Interval
    {
        public int Min { get; set; }
        public int Max { get; set; }
        public int Hour { get; set; }

        public Interval(int min, int max, int hour)
        {
            Min = min;
            Max = max;
            Hour = hour;
        }
    }
}
