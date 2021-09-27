using BattleshipKata.Ships;

namespace BattleshipKata.Cells.States
{
    public class TouchedShipCell : CellState
    {
        private readonly Ship ship;

        public TouchedShipCell(Cell cell, Ship ship) : base(cell)
        {
            this.ship = ship;
        }

        public override void Fire()
        {
        }

        public override CellStatus GetState() 
            => ship.IsSunk()
                ? CellStatus.Sunk
                : CellStatus.Hit;
    }
}