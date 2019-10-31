using System;

namespace LRogue
{
    internal abstract class Creature : IDrawable
    {
        public ConsoleColor Color { get; set; } = ConsoleColor.Green;

        public string Symbol { get; } = " C ";

        public Cell Cell { get; }

        public Creature(Cell cell, string symbol)
        {
            Cell = cell;
            Symbol = symbol;
        }
    }
}