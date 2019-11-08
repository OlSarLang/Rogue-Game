

namespace LRogue
{
    internal class Hero : Creature
    {
        public LimitedList<Item> BackPack { get; set; }
        public Hero(Cell cell) : base (cell, " H ")
        {
            Damage = 25;
            Color = System.ConsoleColor.Yellow;
            BackPack = new LimitedList<Item>(2);
        }
    }
}