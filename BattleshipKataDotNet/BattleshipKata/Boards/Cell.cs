using BattleshipKata.Ships;

namespace BattleshipKata.Boards
{
    public class Cell
    {
        public Cell(Ship ship)
        {
            Ship = ship;

            if (ship.Type == ShipType.NullShip)
            {
                Status = CellStatus.Water;
            }
            else if (ship.Type == ShipType.Carrier)
            {
                Status = CellStatus.Carrier;
            }
            else if (ship.Type == ShipType.GunShip)
            {
                Status = CellStatus.GunShip;
            }
            else
            {
                Status = CellStatus.Destoyer;
            }
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