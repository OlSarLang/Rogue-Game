using System;

namespace LRogue
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();

            game.Run();

            Console.WriteLine("Tanks for paying");
            Console.ReadKey();
        }
    }
}
