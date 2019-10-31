using System;

namespace LRogue
{
    internal interface IDrawable
    {
        ConsoleColor Color { get; set; }
        string Symbol { get; }
    }
}