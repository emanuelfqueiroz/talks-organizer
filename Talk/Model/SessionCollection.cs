﻿using System;
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

        public bool IsAnyLow
        {
            get { return Sessions.Take(Sessions.Count-1).Any(x => x.IsLow); } //When last Session is lower than ideal
        }
        public bool NeedToBalance
        {
            get { return IsValid && Sessions.Last().IsLow; }
        }
        public bool IsAnyOver
        {
            get { return Sessions.Any(x => x.IsOver); }
        }
        public bool IsValid
        {
            get { return !IsAnyLow && !IsAnyOver; }
        }
        public int LeftMinutes
        {
            get { return Sessions.Sum(x => x.LeftMinutes); }
        }
    }
}
