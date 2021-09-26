using BattleshipKata.Boards;

namespace BattleshipKata.Printers
{
    public interface IBoardPrinter
    {
        void Print(ICell[,] cells);
    }
}