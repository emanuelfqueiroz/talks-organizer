using Newtonsoft.Json.Linq;
using System;
using TalkProject.Model;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace TalkProject
{
    class TalkFactory
    {
       
        public List<Talk> GetTalks()
        {
            var JSON = System.IO.File.ReadAllText("talks.json");
            return new Utils.JSON().DeserializeToList<Talk>(JSON);
        }

        public List<TalkSession> GetSessions()
        {
            var talks = GetTalks().OrderBy(x=>x.Duration);
            return null;
            
        }

    }
}
