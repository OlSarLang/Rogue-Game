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
                while (true)
                {
                    DrawMap();
                    GetPlayerCommand(true);
                }
            }

            //draw map
            //get command
            //execute action
            //draw map
            //Enemy actions
            //draw map
            while (gameInProgress) ;
        }

        private void GetPlayerCommand(bool input)
        {
            Console.WriteLine("Use your arrow keys to move.");
            while (input)
            {
                var key = Console.ReadKey(true).Key;

                switch (key)
                {
                    //TODO Fastnar vid 0 och 10, tänk om logiken.
                    case ConsoleKey.UpArrow:
                        if(hero.Cell.PosY -1 < 0 || hero.Cell.PosY + 1 > 10){
                            break;
                        }
                        map.Move(hero, -1, true);
                        input = false;
                        break;
                    case ConsoleKey.DownArrow:
                        if (hero.Cell.PosY - 1 < 0 || hero.Cell.PosY + 1 > 10)
                        {
                            break;
                        }
                        map.Move(hero, 1, true);
                        input = false;
                        break;
                    case ConsoleKey.LeftArrow:
                        if (hero.Cell.PosX -1 < 0 || hero.Cell.PosX + 1 > 10)
                        {
                            break;
                        }
                        map.Move(hero, -1, false);
                        input = false;
                        break;
                    case ConsoleKey.RightArrow:
                        if (hero.Cell.PosX - 1 < 0 || hero.Cell.PosX + 1 > 10)
                        {
                            break;
                        }
                        map.Move(hero, 1, false);
                        input = false;
                        break;
                    default:
                        Console.WriteLine("Invalid input, try again");
                        break;
                }
            }
        }


        private void DrawMap()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            for (int y = 0; y < map.Height; y++)
            {
                if (y == 0)
                {
                    Console.Write("  ");
                    for (int x = 0; x < map.Width; x++)
                    {
                        Console.Write(" " + x + " ");
                    }
                    Console.WriteLine("");
                }
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write($"{y}");
                Console.Write("|");
                
                for (int x = 0; x < map.Width; x++)
                {
                    var cell = map.GetCell(y, x);
                    IDrawable drawable = cell;

                    foreach (var creature in map.Creatures)
                    {
                        if(creature.Cell == cell)
                        {
                            //TODO: Ritar den ut den lokala hero istället för instansen i Map?
                            //Console.Write($"cell pos: {cell.PosY} {cell.PosX}");
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
            
            Console.WriteLine(" ¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯ ");
        }

        private void Initialize()
        {
            //TODO: Read from config later
            map = new Map(width: 10, height: 10);
            var heroCell = map.GetCell(5, 5);
            hero = new Hero(heroCell);
            map.Creatures.Add(hero);
        }
    }
}