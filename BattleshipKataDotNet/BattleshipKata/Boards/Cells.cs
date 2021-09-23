using BattleshipKata.ValueObjects;
using System.Collections.Generic;
using System.Linq;

namespace BattleshipKata.Boards
{
    internal class Cells
    {
        private readonly Size size;

        public Cells(Size size)
        {
            this.size = size;
        }

        public bool Contains(IList<Coordinates> coordinates)
        {
            return coordinates.All(x => Contains(x));
        }

        private bool Contains(Coordinates x)
        {
            return !size.IsOutsideBoard(x);
        }
    }
}