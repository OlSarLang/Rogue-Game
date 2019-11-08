using System;

namespace LRogue
{
    internal abstract class Creature : IDrawable
    {
        public ConsoleColor Color { get; set; } = ConsoleColor.Green;

        public string Symbol { get; } = " C ";

        public Cell Cell { get; set; }


        private int health;
        public int Health
        {
            get { return health; }
            set
            {
                if (health + value > Maxhealth) health = Maxhealth;
                else health = value;
            }
        }
        public int Maxhealth { get; set; } = 100;
        public bool IsDead => Health <= 0;
        public int Damage { get; set; }

        public Creature(Cell cell, string symbol)
        {
            Cell = cell;
            Symbol = symbol;
            health = Maxhealth;
        }
    }
}