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
            switch (Ship.State)
            {
                case ShipStatus.NotTouched:
                    {
                        switch (Ship.Type)
                        {
                            case ShipType.NullShip:
                                return CellStatus.Water;

                            case ShipType.Carrier:
                                return CellStatus.Carrier;

                            case ShipType.Destroyer:
                                return CellStatus.Destoyer;

                            case ShipType.GunShip:
                                return CellStatus.GunShip;
                        }
                        break;
                    }
                case ShipStatus.Touched:
                    return CellStatus.Hit;

                case ShipStatus.Sunken:
                    return CellStatus.Sunk;
            }

            return CellStatus.Water;
        }
    }
}