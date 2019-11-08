using System;
using System.Collections.Generic;
using System.Text;

namespace LRogue.Creatures
{
    class Ogre : Creature
    {
        public Ogre(Cell cell) : base(cell, " O ")
        {
            Color = ConsoleColor.Cyan;
            Health = 125;
            Damage = 25;
        }
    }
}
