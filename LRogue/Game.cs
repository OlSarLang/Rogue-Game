using LRogue.Creatues;
using LRogue.Creatures;
using System;
using System.Collections.Generic;
using System.Linq;

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
                    DrawMap();
                    AITurn();
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
                        Move(hero, Direction.N);
                        input = false;
                        break;
                    case ConsoleKey.DownArrow:
                        Move(hero, Direction.S);
                        input = false;
                        break;
                    case ConsoleKey.LeftArrow:
                        Move(hero, Direction.W);
                        input = false;
                        break;
                    case ConsoleKey.RightArrow:
                        Move(hero, Direction.E);
                        input = false;
                        break;
                    case ConsoleKey.P:
                        PickUp();
                        break;
                    case ConsoleKey.I:
                        Inventory();
                        break;
                    case ConsoleKey.Q:
                        gameInProgress = false;
                        break;
                    case ConsoleKey.A:
                        Attack(hero, VicinityOfCreature(hero));
                        break;
                    default:
                        Console.WriteLine("Invalid input, try again");
                        break;
                }
            }
        }

        private void Inventory()
        {
            foreach (var item in hero.BackPack)
            {
                Console.WriteLine(item);
            }
        }

        private void PickUp()
        {
            var items = hero.Cell.Items;
            var item = items.FirstOrDefault();
            if (item == null) return;
            if (hero.BackPack.Add(item)) items.Remove(item);
        }

        private void Move(Creature creature, Position movement)
        {
            Position newPosition = creature.Cell.Position + movement;
            Cell newCell = map.GetCell(newPosition);
            if (newCell != null) creature.Cell = newCell;
        }

        private void Attack(Creature attacker, Creature defender)
        {
            if(attacker == hero)
            {
                
            }
        }
        private void AITurn()
        {
            Random rnd = new Random();
            int cInt = rnd.Next(0, map.Creatures.Count);
            while(map.Creatures[cInt] == hero)
            {
                cInt = rnd.Next(0, map.Creatures.Count);
            }
            Creature c = map.Creatures[cInt];
            Creature goalCreature = map.Creatures.FirstOrDefault(c => c.Cell == hero.Cell);
            Position goalPos = goalCreature.Cell.Position;

            if(goalPos.X > c.Cell.Position.X + 1)
            {
                Move(c, Direction.E);
            } else if (goalPos.X < c.Cell.Position.X - 1)
            {
                Move(c, Direction.W);
            }
            else
            {
                Attack(c, hero);
            }

            if (goalPos.Y > c.Cell.Position.Y + 1)
            {
                Move(c, Direction.S);
            }
            else if (goalPos.Y < c.Cell.Position.Y - 1)
            {
                Move(c, Direction.N);
            }
            else
            {
                Attack(c, hero);
            }
        }

        private Creature VicinityOfCreature(Creature creature)
        {
            Creature nearbyCreature;

            if(creature == hero)
            {

            }
            return nearbyCreature;
        }

        private void DrawMap()
        {
            UI.Clear();
            UI.Draw(map);
        }

        private void Initialize()
        {
            //TODO: Read from config later
            map = new Map(width: 10, height: 10);
            var heroCell = map.GetCell(5, 5);
            hero = new Hero(heroCell);
            map.Creatures.Add(hero);
            map.Creatures.Add(new Goblin(map.GetCell(4, 4)));
            map.Creatures.Add(new Goblin(map.GetCell(3, 6)));
            map.Creatures.Add(new Goblin(map.GetCell(6, 5)));
            map.Creatures.Add(new Ogre(map.GetCell(9, 1)));
            map.Creatures.Add(new Ogre(map.GetCell(3, 8)));

            map.GetCell(3, 3).Items.Add(Item.Coin());
            map.GetCell(7, 2).Items.Add(Item.Hat());

        }
    }
}