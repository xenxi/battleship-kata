using BattleshipKata.Cells;

namespace BattleshipKata.Cells.States
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
}