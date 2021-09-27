using BattleshipKata.Ships;
using System;

namespace BattleshipKata.Cells.States
{
    public class ShipCell : CellState
    {
        private readonly Ship ship;

        public ShipCell(Cell cell, Ship ship) : base(cell)
        {
            this.ship = ship;
        }

        public override void Fire()
        {
            ship.Shot();

            if (ship.IsSunk())
                Cell.UpdateState(new SunkShipCell(Cell));
            else
                Cell.UpdateState(new TouchedShipCell(Cell));
        }

        public override CellStatus GetState()
        {
            return ship.Type switch
            {
                ShipType.Carrier => CellStatus.Carrier,
                ShipType.Destroyer => CellStatus.Destoyer,
                ShipType.GunShip => CellStatus.GunShip,
                _ => throw new InvalidOperationException(),
            };
        }
    }
}