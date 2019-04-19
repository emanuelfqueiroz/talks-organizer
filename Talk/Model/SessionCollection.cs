using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace TalkProject.Model
{
    public class SessionCollection
    {
        public List<Session> Sessions { get; set; }

        public SessionCollection(List<Session> sessions) => Sessions = sessions;

        public int Duration => Sessions.Sum(p => p.Duration);
        public int LeftMinutes => Sessions.Sum(x => x.LeftMinutes);

        public bool IsAnyLow => Sessions.Take(Sessions.Count - 1).Any(x => x.IsLow);
        public bool NeedToBalance => IsValid && Sessions.Last().IsLow;
        public bool IsAnyOver => Sessions.Any(x => x.IsOver);
        public bool IsValid => !IsAnyLow && !IsAnyOver;
    }
}
