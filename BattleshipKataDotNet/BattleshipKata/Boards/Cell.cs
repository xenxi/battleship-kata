using BattleshipKata.Ships;

namespace BattleshipKata.Boards
{
    public class Cell
    {
        public Cell(Ship ship)
        {
            Ship = ship;

            Status = ship.Type == ShipType.NullShip ? CellStatus.Water : CellStatus.Destoyer;
        }

        public Ship Ship { get; }
        public CellStatus Status { get; private set; }

        public static Cell Empty() => new Cell(Ship.Empty());

        public void Fire()
        {
            if (Ship.Shot())
            {
                if (Ship.State == ShipStatus.Sunken)
                {
                    Status = CellStatus.Sunk;
                }
                else
                {
                    Status = CellStatus.Hit;
                }
            }
            else
            {
                Status = CellStatus.Failed;
            }
        }
    }
}