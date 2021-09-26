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
        public CellStatus Status { get; private set; }

        public void Fire()
        {
        }

        public static Cell WaterCell() => new Cell(null);
    }
}