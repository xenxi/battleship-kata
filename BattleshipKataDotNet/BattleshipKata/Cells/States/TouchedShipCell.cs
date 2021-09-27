namespace BattleshipKata.Cells.States
{
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
}