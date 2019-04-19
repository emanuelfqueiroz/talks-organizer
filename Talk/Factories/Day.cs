using System;
using System.Linq;
using System.Collections.Generic;
using TalkProject.Model;

namespace TalkProject.Factories
{
    internal class Day
    {
        public DateTime Start { get; private set; }
        private DateTime CurrentDay { get; set; }
        public List<Interval> Intervals { get; private set; } = new List<Interval>();
        private int indexInterval = 0;
        public List<Session> Sessions { get; private set; } = new List<Session>();
        public Day(DateTime start)
        {
            Start = start;
            CurrentDay = start;
            Intervals.Add(new Interval(160, 180, 9));
            Intervals.Add(new Interval(180, 240, 13));
            indexInterval = 0;
        }
        private void NextStep()
        {
            indexInterval++;
            if (indexInterval > Intervals.Count - 1)
            {
                indexInterval = 0;
                CurrentDay.AddDays(1);
            }
        }

        public Session NextSession()
        {
            if (Sessions.Count > 0)
            {
                NextStep();
            }
            var interval = Intervals[indexInterval];
            var dtSession = CurrentDay.AddHours(interval.Hour);
            Sessions.Add( new Session(interval.Min, interval.Max, dtSession));
            return Sessions.Last();
        }
    }
}
