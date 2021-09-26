using BattleshipKata.Ships;

namespace BattleshipKata.Boards
{
    public class Cell : ICell
    {
        private bool fired;

        public Cell(Ship ship)
        {
            Ship = ship;

            fired = false;
        }

        public Ship Ship { get; }

        public CellStatus Status => CalculeStatus();

        public static Cell Empty() => new Cell(Ship.Empty());

        public void Fire()
        {
            Ship.Shot();
            fired = true;
        }

        private CellStatus CalculeStatus()
        {
            if (fired)
            {
                if (Ship.Type == ShipType.NullShip)
                    return CellStatus.Failed;

                if (Ship.State == ShipStatus.Touched)
                    return CellStatus.Hit;

                if (Ship.State == ShipStatus.Sunken)
                    return CellStatus.Sunk;
            }

            switch (Ship.Type)
            {
                case ShipType.Carrier:
                    return CellStatus.Carrier;

                case ShipType.Destroyer:
                    return CellStatus.Destoyer;

                case ShipType.GunShip:
                    return CellStatus.GunShip;
            }

            return CellStatus.Water;
        }
    }
}