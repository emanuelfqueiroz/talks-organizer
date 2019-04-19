using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace TalkProject.Model
{
    public class SessionCollection
    {
        public List<Session> Sessions { get; set; }

        public SessionCollection(List<Session> sessions)
        {
            Sessions = sessions;
        }

        public int Duration { get { return Sessions.Sum(p => p.Duration); } }

        public bool IsFull
        {
            get { return Sessions.Any(x => x.IsFull); }
        }
        public bool IsLow
        {
            get { return Sessions.Any(x => x.IsLow); }
        }
        public bool IsOver
        {
            get { return Sessions.Any(x => x.IsOver); }
        }
        public bool IsValid
        {
            get { return !IsLow && !IsOver; }
        }
        public int LeftMinutes
        {
            get { return Sessions.Sum(x => x.LeftMinutes); }
        }
    }
}
