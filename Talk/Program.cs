using System;
using System.Linq;

namespace TalkProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            new TalkFactory().GetTalks().ForEach(x=>Console.WriteLine($" {x.Title} + {x.Duration}min \n"));
            Console.ReadLine();
        }
    }
}
