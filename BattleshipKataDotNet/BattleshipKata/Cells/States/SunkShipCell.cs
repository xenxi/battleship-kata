namespace BattleshipKata.Cells.States
{
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
}