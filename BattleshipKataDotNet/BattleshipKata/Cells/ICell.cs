using BattleshipKata.Cells.States;

namespace BattleshipKata.Cells
{
    public interface ICell
    {
        CellStatus Status { get; }
    }
}