namespace BattleshipKata.Cells.States
{
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
}