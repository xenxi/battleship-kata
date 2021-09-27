using BattleshipKata.Ships;
using System;

namespace BattleshipKata.Boards
{
    public abstract class CellState
    {
        protected CellState(Cell cell)
        {
            Cell = cell;
        }

        protected Cell Cell { get; }

        public abstract void Fire();

        public abstract CellStatus GetState();
    }

    public class FailedCell : CellState
    {
        public FailedCell(Cell cell) : base(cell)
        {
        }

        public override void Fire()
        {
        }

        public override CellStatus GetState() => CellStatus.Failed;
    }

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

    public class SunkShipCell : CellState
    {
        public SunkShipCell(Cell cell) : base(cell)
        {
        }

        public override void Fire()
        {
        }

        public override CellStatus GetState()
        {
            return CellStatus.Sunk;
        }
    }

    public class TouchedShipCell : CellState
    {
        public TouchedShipCell(Cell cell) : base(cell)
        {
        }

        public override void Fire()
        {
        }

        public override CellStatus GetState() => CellStatus.Hit;
    }

    public class WaterCell : CellState
    {
        public WaterCell(Cell cell) : base(cell)
        {
        }

        public override void Fire() => Cell.UpdateState(new FailedCell(Cell));

        public override CellStatus GetState() => CellStatus.Water;
    }
}