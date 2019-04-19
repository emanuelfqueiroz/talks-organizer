using System;
using System.Linq;

namespace TalkProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            new TalkFactory().GetSessionCollection();
            Console.ReadLine();
        }
    }
}
