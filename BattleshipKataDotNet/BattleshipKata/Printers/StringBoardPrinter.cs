using BattleshipKata.Boards;
using System.Linq;

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
            var columnNumbers = Enumerable.Range(0, cells.GetLength(0));

            printer.Print($" | {string.Join(" | ", columnNumbers)} |");
        }
    }
}