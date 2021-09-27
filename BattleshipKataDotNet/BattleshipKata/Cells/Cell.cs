using BattleshipKata.Cells.States;
using BattleshipKata.Ships;

namespace BattleshipKata.Cells
{
    public class Cell : ICell
    {
        private CellState state;

        public Cell(Ship ship)
        {
            Ship = ship;
            state = new ShipCell(this, ship);
        }

        private Cell()
        {
            Ship = new NullShip();
            state = new WaterCell(this);
        }
        public Ship Ship { get; }

        public CellStatus Status => CalculeStatus();

        public static Cell Empty() => new Cell();

        public void Fire()
        {
            state.Fire();
        }

        internal void UpdateState(CellState newState) => state = newState;

        private CellStatus CalculeStatus()
        {
            if (Ship.IsSunk())
                return CellStatus.Sunk;

            return state.GetState();
        }
    }
}