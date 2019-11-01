using System;
using System.Collections.Generic;
using System.Linq;

namespace LRogue
{
    internal class Map
    {
        public int Width { get; }
        public int Height { get; }

        //TODO: Make Comment
        private Cell[,] cells;

        public List<Creature> Creatures { get; set; } = new List<Creature>();

        public Map(int width, int height)
        {
            Width = width;
            Height = height;

            cells = new Cell[height, width];

            for (int y = 0; y < height; y++)
            {
                
                for (int x = 0; x < width; x++)
                {
                    cells[y, x] = new Cell(y, x);
                }
            }
        }

        internal Cell GetCell(int y, int x)
        {
            return cells[y, x];
        }

        internal void Move(Creature creature, int a, bool Yaxis)
        {
            var obj = Creatures.FirstOrDefault(c => c.Cell == creature.Cell);
            if (Yaxis)
            {
                Console.WriteLine($"Y: {obj.Cell.PosY}");
                obj.Cell.PosY += a;
                Console.WriteLine($"Y: {obj.Cell.PosY}");
            } else
            {
                Console.WriteLine($"X: {obj.Cell.PosX}");
                obj.Cell.PosX += a;
                Console.WriteLine($"X: {obj.Cell.PosX}");
            }
        }
    }
}