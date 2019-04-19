using System;
using System.Linq;
using TalkProject.Model;

namespace TalkProject
{
    class Program
    {
        static void Main(string[] args)
        {
            var startDay = new DateTime(2019, 06, 1);
            var factory = new TalkFactory(startDay, "talks.json", 10000);
            var collection = factory.GetSessionCollection();
            PrintCollection(collection);
            Console.ReadLine();
        }

        private static void PrintCollection(SessionCollection best)
        {
            if (best is null)
            {
                Console.WriteLine(" Melhor resultado não encontrado \n");
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

    }
}
