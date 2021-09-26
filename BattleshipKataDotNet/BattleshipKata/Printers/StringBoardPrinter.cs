using BattleshipKata.Boards;

namespace BattleshipKata.Printers
{
    public class StringBoardPrinter : IBoardPrinter
    {
        private readonly IStringPrinter printer;

        public StringBoardPrinter(IStringPrinter printer)
        {
            this.printer = printer;
        }

        public void Print(ICell[,] cells)
        {
            printer.Print(" | 0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 |");
        }
    }
}