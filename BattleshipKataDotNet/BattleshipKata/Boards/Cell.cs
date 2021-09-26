using BattleshipKata.Ships;

namespace BattleshipKata.Boards
{
    public class Cell
    {
        public Cell(Ship ship)
        {
            Ship = ship;
        }

        public Ship Ship { get; }
    }
}