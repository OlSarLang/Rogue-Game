using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LRogue
{
    static class Extensions
    {
        public static IDrawable CreatureAt(this List<Creature> creatures, Cell cell)
        {
            return creatures.FirstOrDefault(c => c.Cell == cell);
        }
    }
}
