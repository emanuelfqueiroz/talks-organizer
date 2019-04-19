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

        public SessionCollection GetSessionCollection()
        {
            var talks = GetTalks();
            var i = 0;
            SessionCollection best = null;
            while (i < 10000000)
            {
                i++;
                talks = Shuffle(talks);
                SessionCollection c = CreateSessionCollection(talks);
                if (c.IsValid)
                {
                    if (best is null)
                    {

                        best = c;

                    }
                    if (c.LeftMinutes < best.LeftMinutes)
                    {

                        best = c;
                    }
                }
                else
                {
                    
                }
               
            }
            PrintStatus(best);
            return best;
            
        }

        private static void PrintStatus(SessionCollection best)
        {
            if(best is null)
            {
                return;
            }
            Console.WriteLine("-------------------------\n");
            Console.WriteLine($"Left Minutes: {best.LeftMinutes}\n");
            foreach (var item in best.Sessions)
            {
                Console.WriteLine($"    Start {item.Start} ----Left: {item.LeftMinutes}-\n");
                foreach (var talk in item.Talks)
                {
                    Console.WriteLine($"      Talks {talk.Title} -----\n");
                }
            }
        }

        private SessionCollection CreateSessionCollection(List<Talk> talks)
        {
          
            var start = new DateTime(2019, 06, 1);
            var dayFactory = new Factories.Day(start);

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
