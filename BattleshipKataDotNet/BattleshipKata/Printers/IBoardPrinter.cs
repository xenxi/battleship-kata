using BattleshipKata.Cells;

namespace BattleshipKata.Printers
{
    public interface IBoardPrinter
    {
        void Print(ICell[,] cells);
    }
}