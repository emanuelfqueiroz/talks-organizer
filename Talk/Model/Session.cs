using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace TalkProject.Model
{
    public class Session
    {
        public DateTime Start { get; set; }
        public int MaxMinutes { get; set; }
        public int MinMinutes { get; set; }
        public List<Talk> Talks { get; private set; } = new List<Talk>();

        public int Duration { get; private set; }
       
        public bool IsFull
        {
            get { return Duration == MaxMinutes; }
        }
        public bool IsLow
        {
            get { return Duration < MinMinutes; }
        }
        public bool IsOver
        {
            get { return Duration > MaxMinutes; }
        }
        public bool IsValid
        {
            get { return !IsLow && !IsOver; }
        }
        public int LeftMinutes
        {
            get { return MaxMinutes - Duration;  }
        }


        public Session( int minMinutes, int maxMinutes, DateTime start)
        {
            MaxMinutes = maxMinutes;
            MinMinutes = minMinutes;
            Start = start;
        }

        private void LoadProperties()
        {
           Duration = Talks.Sum(x => x.Duration);
        }
        public void AddTalk(Talk t)
        {
            Talks.Add(t);
            LoadProperties();
        }
    }
}
