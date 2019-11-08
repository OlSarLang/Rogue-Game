using System;
using System.Linq;

namespace LRogue
{
    internal static class UI
    {
        internal static void Draw(Map map)
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

                    IDrawable drawable = map.Creatures.CreatureAt(cell) ?? (IDrawable) cell.Items.FirstOrDefault() ?? cell;

                    Console.ForegroundColor = drawable?.Color ?? ConsoleColor.White;
                    Console.Write(drawable?.Symbol);
                }
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("|\n");
            }

            Console.WriteLine(" ¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯ ");
        }

        internal static void Clear()
        {
            Console.SetCursorPosition(0, 0);
            Console.CursorVisible = false;
        }
    }
}