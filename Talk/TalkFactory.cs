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
        public DateTime StartDay { get; set; }
        public int MaxTries { get; set; }
        public string File { get; set; }

        public TalkFactory(DateTime startDay, string file, int maxTries)
        {
            StartDay = startDay;
            MaxTries = maxTries;
            File = file;
        }

        public List<Talk> GetTalks()
        {
            var json = System.IO.File.ReadAllText(File);
            return new Utils.JSON().DeserializeToList<Talk>(json);
        }

        public SessionCollection GetSessionCollection()
        {
            var talks = GetTalks();
            var i = 0;
            SessionCollection best = null;
            while (i < MaxTries)
            {
                i++;
                talks = Shuffle(talks);
                SessionCollection current = CreateSessionCollection(talks);
                if (current.IsValid)
                {
                    if (best is null)
                    {
                        best = current;
                    }
                    else
                    {
                        if (current.LeftMinutes < best.LeftMinutes)
                        {
                            best = current;
                        }
                        else if (current.LeftMinutes == best.LeftMinutes //Escolha as melhores caracteristicas
                             && current.Sessions.Count(x => x.IsFull) > best.Sessions.Count(x => x.IsFull))
                        {
                            best = current;
                        }
                    }
                }
               
            }
            return best;
        }

        private SessionCollection CreateSessionCollection(List<Talk> talks)
        {
            var dayFactory = new Factories.Day(StartDay);
            var current = dayFactory.NextSession();

            for (var i=0;  i < talks.Count - 1; i++)
            {
                var talk = talks[i];
                                
                if(current.LeftMinutes >= talk.Duration)
                {
                    current.AddTalk(talk);
                    continue;
                }
                else
                {
                    current = dayFactory.NextSession();
                    current.AddTalk(talk);
                }
            }
            return new SessionCollection(dayFactory.Sessions);
        }

        private List<Talk> Shuffle(List<Talk> talks)
        {
            return talks.OrderBy(a => Guid.NewGuid()).ToList();
        }

    }
}
