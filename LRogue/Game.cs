using System;

namespace LRogue
{
    internal class Game
    {
        private Map map;
        private Hero hero;
        private bool gameInProgress;

        public Game()
        {

        }

        internal void Run()
        {
            Initialize();
            Play();
        }

        private void Play()
        {

            do
            {
                DrawMap();

            }

            //draw map
            //get command
            //execute action
            //draw map
            //Enemy actions
            //draw map
            while (gameInProgress) ;
        }

        private void DrawMap()
        {
            Console.WriteLine(" ______________________________ ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            for (int y = 0; y < map.Height; y++)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("|");
                for (int x = 0; x < map.Width; x++)
                {
                    var cell = map.GetCell(y, x);
                    //Console.ForegroundColor = cell?.Color ?? ConsoleColor.White;
                    //Console.Write(cell?.Symbol);
                    IDrawable drawable = cell;

                    foreach (var creature in map.Creatures)
                    {
                        if(creature.Cell == cell)
                        {
                            drawable = creature;
                            break;
                        }
                    }

                    Console.ForegroundColor = drawable?.Color ?? ConsoleColor.White;
                    Console.Write(drawable?.Symbol);
                }
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("|\n");
            }
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(" ¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯ ");
        }

        private void Initialize()
        {
            //TODO: Read from config later
            map = new Map(width: 10, height: 10);
            var heroCell = map.GetCell(0, 0);
            hero = new Hero(heroCell);
            map.Creatures.Add(hero);
        }
    }
}