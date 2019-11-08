using System;
using System.Collections.Generic;

namespace LRogue
{
    internal class Cell : IDrawable
    {
        public List<Item> Items { get; set; } = new List<Item>();

        public string Symbol => " . ";

        public ConsoleColor Color { get; set; }

        public Position Position { get; }

        public Cell(Position p)
        {
            Position = p;
            Color = ConsoleColor.Red;
        }
    }
}