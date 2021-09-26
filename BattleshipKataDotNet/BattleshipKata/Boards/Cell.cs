using BattleshipKata.Ships;

namespace BattleshipKata.Boards
{
    public class Cell
    {
        public Cell(Ship ship)
        {
            Ship = ship;

            Status = ship == null ? CellStatus.Water : CellStatus.Destoyer;
        }

        public Ship Ship { get; }
        public CellStatus Status { get; private set; }

        public static Cell Empty() => new Cell(Ship.Empty());

        public void Fire()
        {
            Status = Ship.Shot()
                ? CellStatus.Hit
                : CellStatus.Failed;
        }
    }
}