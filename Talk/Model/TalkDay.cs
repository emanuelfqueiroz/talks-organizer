using System;
using System.Collections.Generic;
using System.Text;

namespace TalkProject.Model
{
    class TalkDay
    {
        public List<TalkSession> Sessions { get; set; }

        public TalkDay(List<TalkSession> sessions)
        {
            Sessions = sessions;
        }
    }
}
