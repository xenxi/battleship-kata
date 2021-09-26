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

            printer.Print("0|   |   |   |   |   |   |   |   |   |   |");
            printer.Print("1|   |   |   |   |   |   |   |   |   |   |");
            printer.Print("2|   |   |   |   |   |   |   |   |   |   |");
            printer.Print("3|   |   |   |   |   |   |   |   |   |   |");
            printer.Print("4|   |   |   |   |   |   |   |   |   |   |");
            printer.Print("5|   |   |   |   |   |   |   |   |   |   |");
            printer.Print("6|   |   |   |   |   |   |   |   |   |   |");
            printer.Print("7|   |   |   |   |   |   |   |   |   |   |");
            printer.Print("8|   |   |   |   |   |   |   |   |   |   |");
        }
    }
}