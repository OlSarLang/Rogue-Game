using System;
using System.Collections.Generic;

namespace LRogue
{
    internal class Cell : IDrawable
    {
        public List<Item> Items { get; set; } = new List<Item>();

        public string Symbol => " . ";

        public ConsoleColor Color { get; set; }
        public int PosX { get; set; }
        public int PosY { get; set; }

        public Cell(int y, int x)
        {
            PosY = y;
            PosX = x;
            Color = ConsoleColor.Red;
        }
    }
}