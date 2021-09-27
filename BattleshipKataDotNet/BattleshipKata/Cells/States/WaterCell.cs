namespace BattleshipKata.Cells.States
{
    public class WaterCell : CellState
    {
        public WaterCell(Cell cell) : base(cell)
        {
        }

        public override void Fire() => Cell.UpdateState(new FailedCell(Cell));

        public override CellStatus GetState() => CellStatus.Water;
    }
}